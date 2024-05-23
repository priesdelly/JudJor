using CommandLine;
using JudJor.Model;
using JudJor.Properties;
using JudJor.View;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace JudJor;

internal static class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        //Prevent duplicate instances
        var processName = AppDomain.CurrentDomain.FriendlyName;
        var exists = Process.GetProcessesByName(processName).Length > 1;

        if (exists)
        {
            Application.Exit();
            return;
        }

        ApplicationConfiguration.Initialize();
        Application.Run(new MainApplicationContext(args));
    }
}

public class MainApplicationContext : ApplicationContext
{
    private MainForm mainForm;
    private bool ArgsHidden;

    public MainApplicationContext(string[] args)
    {

        //Parse application arguments
        Parser.Default
            .ParseArguments<ArgsOption>(args)
            .WithParsed<ArgsOption>(o =>
            {
                if (o.Hidden)
                {
                    ArgsHidden = true;
                }
            });

        // Create a simple tray menu with only one item.
        var trayMenu = new ContextMenuStrip();
        trayMenu.Items.Add(Resources.TrayIcon_Menu_Show, null, TrayIcon_OnShow);
        trayMenu.Items.Add(Resources.TrayIcon_Menu_Exit, null, TrayIcon_OnExit);

        // Create a tray icon.
        var trayIcon = new NotifyIcon()
        {
            Icon = Resources.AppIcon,
            Text = Resources.TrayIcon_Title,
            ContextMenuStrip = trayMenu,
            BalloonTipIcon = ToolTipIcon.Info,
            BalloonTipTitle = "Still running",
            BalloonTipText = "JudJor is still running in system tray",
            Visible = true
        };

        trayIcon.MouseDoubleClick -= TrayIcon_OnShow;
        trayIcon.MouseDoubleClick += TrayIcon_OnShow;

        mainForm = new(); 
        mainForm.Resize -= MainForm_Resize;
        mainForm.Resize += MainForm_Resize;
        if (!ArgsHidden)
        {
            mainForm.Show();
        }
    }

    private void TrayIcon_OnShow(object sender, EventArgs e)
    {
        if (mainForm.IsDisposed)
        {
            mainForm = new();
        }

        if (!mainForm.Visible)
        {
            mainForm.Show();
        }

        mainForm.WindowState = FormWindowState.Normal;
        mainForm.ShowInTaskbar = true;
        mainForm.Activate();
    }

    private void TrayIcon_OnExit(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void MainForm_Resize(object sender, EventArgs e)
    {
        if (mainForm.WindowState == FormWindowState.Minimized)
        {
            mainForm.Hide();
        }
    }
}