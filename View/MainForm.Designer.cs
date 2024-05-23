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
        groupBox1 = new System.Windows.Forms.GroupBox();
        label1 = new System.Windows.Forms.Label();
        btnSplitRight = new System.Windows.Forms.Button();
        btnSplitLeft = new System.Windows.Forms.Button();
        groupBox2 = new System.Windows.Forms.GroupBox();
        groupBox1.SuspendLayout();
        SuspendLayout();
        // 
        // groupBox1
        // 
        groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        groupBox1.Controls.Add(label1);
        groupBox1.Controls.Add(btnSplitRight);
        groupBox1.Controls.Add(btnSplitLeft);
        groupBox1.Location = new System.Drawing.Point(12, 12);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new System.Drawing.Size(760, 185);
        groupBox1.TabIndex = 1;
        groupBox1.TabStop = false;
        groupBox1.Text = "Debug";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new System.Drawing.Point(6, 19);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(38, 15);
        label1.TabIndex = 0;
        label1.Text = "label1";
        // 
        // btnSplitRight
        // 
        btnSplitRight.Location = new System.Drawing.Point(656, 19);
        btnSplitRight.Name = "btnSplitRight";
        btnSplitRight.Size = new System.Drawing.Size(98, 35);
        btnSplitRight.TabIndex = 0;
        btnSplitRight.Text = "Split Right";
        btnSplitRight.UseVisualStyleBackColor = true;
        btnSplitRight.Click += btnSplitRight_Click;
        // 
        // btnSplitLeft
        // 
        btnSplitLeft.Location = new System.Drawing.Point(552, 19);
        btnSplitLeft.Name = "btnSplitLeft";
        btnSplitLeft.Size = new System.Drawing.Size(98, 35);
        btnSplitLeft.TabIndex = 0;
        btnSplitLeft.Text = "Split Left";
        btnSplitLeft.UseVisualStyleBackColor = true;
        btnSplitLeft.Click += btnSplitLeft_Click;
        // 
        // groupBox2
        // 
        groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        groupBox2.Location = new System.Drawing.Point(12, 228);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new System.Drawing.Size(756, 321);
        groupBox2.TabIndex = 2;
        groupBox2.TabStop = false;
        groupBox2.Text = "groupBox2";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(784, 561);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        MinimumSize = new System.Drawing.Size(800, 600);
        Name = "MainForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Judjor";
        FormClosed += MainForm_FormClosed;
        Load += MainForm_Load;
        Resize += MainForm_Resize;
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button btnSplitLeft;
    private System.Windows.Forms.Button btnSplitRight;
}
