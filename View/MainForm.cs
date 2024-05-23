using JudJor.Properties;
using System.Windows.Forms;

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
}

