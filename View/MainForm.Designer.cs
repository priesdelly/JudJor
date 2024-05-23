using JudJor.Properties;

namespace JudJor.View;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        SuspendLayout();
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(784, 561);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        MaximizeBox = false;
        MaximumSize = new System.Drawing.Size(800, 600);
        MinimumSize = new System.Drawing.Size(800, 600);
        Name = "MainForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Judjor";
        FormClosed += MainForm_FormClosed;
        Load += MainForm_Load;
        Resize += MainForm_Resize;
        ResumeLayout(false);
    }

    #endregion
}
