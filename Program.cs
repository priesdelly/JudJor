using CommandLine;
using JudJor.Model;
using JudJor.Properties;
using JudJor.View;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace JudJor;

internal static class Program
{

    public static bool ARGS_HIDDEN = false;
    public static bool ARGS_DEBUG = false;

    /// <summary>
    /// The entry point of the application.
    /// </summary>
    /// <param name="args">Command line arguments.</param>
    [STAThread]
    private static void Main(string[] args)
    {
        // Prevent duplicate instances
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
    private MainForm _mainForm = new();


    /// <summary>
    /// Initializes a new instance of the <see cref="MainApplicationContext"/> class.
    /// Parses the application arguments, creates a system tray icon, and shows the main form if the arguments are not hidden.
    /// </summary>
    /// <param name="args">The command line arguments.</param>
    public MainApplicationContext(string[] args)
    {
        ParseArgs(args);
        CreateTrayIcon();

        if (!Program.ARGS_HIDDEN)
        {
            _mainForm.Show();
        }
    }

    /// <summary>
    /// Parses the application arguments.
    /// </summary>
    /// <param name="args">The command line arguments.</param>
    private void ParseArgs(string[] args)
    {
        //Parse application arguments
        Parser.Default
            .ParseArguments<ArgsOption>(args)
            .WithParsed<ArgsOption>(o =>
            {
                if (o.Hidden)
                {
                    Program.ARGS_HIDDEN = true;
                }

                if (o.Debug)
                {
                    Program.ARGS_DEBUG = true;
                }
            });
    }

    /// <summary>
    /// Creates a system tray icon with a menu that contains two items: "Show" and "Exit".
    /// The "Show" item displays the main form, while the "Exit" item exits the application.
    /// </summary>
    private void CreateTrayIcon()
    {
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
    }

    private void TrayIcon_OnShow(object sender, EventArgs e)
    {
        if (_mainForm.IsDisposed)
        {
            _mainForm = new();
        }

        if (!_mainForm.Visible)
        {
            _mainForm.Show();
        }

        _mainForm.WindowState = FormWindowState.Normal;
        _mainForm.ShowInTaskbar = true;
        _mainForm.Activate();
    }

    private void TrayIcon_OnExit(object sender, EventArgs e)
    {
        Application.Exit();
    }
}