using JudJor.Properties;
using System.Drawing;
using System.Text;
using System;
using System.Windows.Forms;
using JudJor.Repository;
using System.Linq;

namespace JudJor.View;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void MainForm_Load(object sender, System.EventArgs e)
    {
        Text = Resources.MainForm_Title;
        Icon = Resources.AppIcon;

        var timer = new Timer();
        timer.Interval = 500;
        timer.Tick -= Timer_Tick;
        timer.Tick += Timer_Tick;
        timer.Start();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        var hWnd = WindowAPI.GetForegroundWindow();
        if (hWnd == IntPtr.Zero)
        {
            return;
        }

        var windowText = new StringBuilder(256);
        _ = WindowAPI.GetWindowText(hWnd, windowText, windowText.Capacity);

        WindowAPI.GetWindowRect(hWnd, out Model.WindowRect rect);

        var screenArea = Screen.FromHandle(hWnd).WorkingArea;
        var screenWidth = screenArea.Width.ToString();
        var screenHeight = screenArea.Height.ToString();

        label1.Text = $"Title: {windowText}\nPosition: {rect.Location}\n Size: {rect.Size} \n Screen Width: {screenWidth} \n Screen Height: {screenHeight}";
    }

    private void MainForm_Resize(object sender, System.EventArgs e)
    {
        if (WindowState == FormWindowState.Minimized)
        {
            this.Hide();
        }
    }

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {

#if DEBUG
        Application.Exit();
#endif

    }

    private float[] ComputeValueFractions(float value, params float[] fractions)
    {
        if (fractions.Sum() != 1)
        {
            throw new ArgumentOutOfRangeException("Total fraactions must be 1");
        }

        return fractions.Select(f => value * f).ToArray();
    }

    //private void MaximizeHandle(IntPtr hWnd)
    //{
    //    var screenArea = Screen.FromHandle(hWnd).WorkingArea;
    //    WindowAPI.MoveWindow(hWnd, 0, 0, screenArea.Width, screenArea.Height + 25, true);
    //}

    private void SplitLeftHandle(IntPtr hWnd)
    {
        var screenArea = Screen.FromHandle(hWnd).WorkingArea;
        var widths = ComputeValueFractions(screenArea.Width, [0.5f, 0.5f]);
        WindowAPI.SetWindowPos(hWnd, 0, 0, 0, (int)widths[0], screenArea.Height, WindowAPI.SWP_SHOWWINDOW);
    }

    private void btnSplitLeft_Click(object sender, EventArgs e)
    {
        SplitLeftHandle(Handle);
    }
  
    private void btnSplitRight_Click(object sender, EventArgs e)
    {

    }
}
