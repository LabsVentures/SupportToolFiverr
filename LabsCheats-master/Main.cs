// Decompiled with JetBrains decompiler
// Type: lmitp.Main
// Assembly: Support Tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7C2F509-6BDB-4CAE-AB6E-4A5371C4CE0D
// Assembly location: C:\Users\ethan\OneDrive\Desktop\Support_Tool.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace lmitp
{
  public class Main : Form
  {
    private bool mouseDown;
    private Point lastLocation;
    private IContainer components = (IContainer) null;
    private Button btnSystemInfo;
    private Button btnRedistributables;
    private Button btnWindowsSettings;
    private Panel mainpanel;
    private Button btnControls;
    private Button btnVirus;
    private Button button2;
    private Button button1;
    private Button button3;
    private Button button4;
    private Label label1;
    private Button button5;

    public Main() => this.InitializeComponent();

    public void loadform(object Form)
    {
      if (this.mainpanel.Controls.Count > 0)
        this.mainpanel.Controls.RemoveAt(0);
      Form form = Form as Form;
      form.TopLevel = false;
      form.Dock = DockStyle.Fill;
      this.mainpanel.Controls.Add((Control) form);
      this.mainpanel.Tag = (object) form;
      form.Show();
    }

    private void btnVirus_Click(object sender, EventArgs e)
    {
      this.loadform((object) new anticv());
      this.btnVirus.BackColor = Color.Black;
      this.btnSystemInfo.BackColor = Color.FromArgb(20, 20, 20);
      this.btnRedistributables.BackColor = Color.FromArgb(20, 20, 20);
      this.btnControls.BackColor = Color.FromArgb(20, 20, 20);
      this.button3.BackColor = Color.FromArgb(20, 20, 20);
      this.button5.BackColor = Color.FromArgb(20, 20, 20);
      this.btnWindowsSettings.BackColor = Color.FromArgb(20, 20, 20);
    }

    private void btnSystemInfo_Click(object sender, EventArgs e)
    {
      this.loadform((object) new systeminfo());
      this.btnSystemInfo.BackColor = Color.Black;
      this.btnVirus.BackColor = Color.FromArgb(20, 20, 20);
      this.btnRedistributables.BackColor = Color.FromArgb(20, 20, 20);
      this.btnControls.BackColor = Color.FromArgb(20, 20, 20);
      this.button3.BackColor = Color.FromArgb(20, 20, 20);
      this.button5.BackColor = Color.FromArgb(20, 20, 20);
      this.btnWindowsSettings.BackColor = Color.FromArgb(20, 20, 20);
    }

    private void btnWindowsSettings_Click(object sender, EventArgs e)
    {
      this.loadform((object) new windowssettings());
      this.btnWindowsSettings.BackColor = Color.Black;
      this.btnVirus.BackColor = Color.FromArgb(20, 20, 20);
      this.btnSystemInfo.BackColor = Color.FromArgb(20, 20, 20);
      this.btnRedistributables.BackColor = Color.FromArgb(20, 20, 20);
      this.btnControls.BackColor = Color.FromArgb(20, 20, 20);
      this.button3.BackColor = Color.FromArgb(20, 20, 20);
      this.button5.BackColor = Color.FromArgb(20, 20, 20);
    }

    private void btnControls_Click(object sender, EventArgs e)
    {
      this.loadform((object) new controls());
      this.btnControls.BackColor = Color.Black;
      this.btnVirus.BackColor = Color.FromArgb(20, 20, 20);
      this.btnSystemInfo.BackColor = Color.FromArgb(20, 20, 20);
      this.btnRedistributables.BackColor = Color.FromArgb(20, 20, 20);
      this.button3.BackColor = Color.FromArgb(20, 20, 20);
      this.btnWindowsSettings.BackColor = Color.FromArgb(20, 20, 20);
      this.button5.BackColor = Color.FromArgb(20, 20, 20);
    }

    private void btnRedistributables_Click(object sender, EventArgs e)
    {
      this.loadform((object) new redist());
      this.btnRedistributables.BackColor = Color.Black;
      this.btnVirus.BackColor = Color.FromArgb(20, 20, 20);
      this.btnSystemInfo.BackColor = Color.FromArgb(20, 20, 20);
      this.btnControls.BackColor = Color.FromArgb(20, 20, 20);
      this.button3.BackColor = Color.FromArgb(20, 20, 20);
      this.button5.BackColor = Color.FromArgb(20, 20, 20);
      this.btnWindowsSettings.BackColor = Color.FromArgb(20, 20, 20);
    }

    private void button2_Click(object sender, EventArgs e) => Process.Start("https://labscheats.com/");

    private void button1_Click(object sender, EventArgs e) => Process.Start("https://bit.ly/LabsCheats");

    private void button3_Click(object sender, EventArgs e)
    {
      this.loadform((object) new gameboosters());
      this.button3.BackColor = Color.Black;
      this.btnVirus.BackColor = Color.FromArgb(20, 20, 20);
      this.btnSystemInfo.BackColor = Color.FromArgb(20, 20, 20);
      this.btnRedistributables.BackColor = Color.FromArgb(20, 20, 20);
      this.btnControls.BackColor = Color.FromArgb(20, 20, 20);
      this.btnWindowsSettings.BackColor = Color.FromArgb(20, 20, 20);
      this.button5.BackColor = Color.FromArgb(20, 20, 20);
    }

    private void Main_FormClosing(object sender, FormClosingEventArgs e)
    {
      Directory.CreateDirectory("C:\\TempFold");
      DirectoryInfo directoryInfo = new DirectoryInfo("C:\\TempFold");
      directoryInfo.Attributes &= ~FileAttributes.ReadOnly;
      directoryInfo.Delete(true);
    }

    private void button4_Click(object sender, EventArgs e) => Application.Exit();

    private void panel1_MouseDown(object sender, MouseEventArgs e)
    {
      this.mouseDown = true;
      this.lastLocation = e.Location;
    }

    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
      if (!this.mouseDown)
        return;
      Point location = this.Location;
      int x = location.X - this.lastLocation.X + e.X;
      location = this.Location;
      int y = location.Y - this.lastLocation.Y + e.Y;
      this.Location = new Point(x, y);
      this.Update();
    }

    private void panel1_MouseUp(object sender, MouseEventArgs e) => this.mouseDown = false;

    private void Main_Load(object sender, EventArgs e)
    {
      this.btnSystemInfo.BackColor = Color.Black;
      this.loadform((object) new systeminfo());
    }

    private void button5_Click(object sender, EventArgs e)
    {
      this.loadform((object) new cleaners());
      this.button5.BackColor = Color.Black;
      this.button3.BackColor = Color.FromArgb(20, 20, 20);
      this.btnVirus.BackColor = Color.FromArgb(20, 20, 20);
      this.btnSystemInfo.BackColor = Color.FromArgb(20, 20, 20);
      this.btnRedistributables.BackColor = Color.FromArgb(20, 20, 20);
      this.btnControls.BackColor = Color.FromArgb(20, 20, 20);
      this.btnWindowsSettings.BackColor = Color.FromArgb(20, 20, 20);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Main));
      this.button5 = new Button();
      this.button1 = new Button();
      this.button2 = new Button();
      this.button3 = new Button();
      this.btnControls = new Button();
      this.btnVirus = new Button();
      this.btnSystemInfo = new Button();
      this.btnRedistributables = new Button();
      this.btnWindowsSettings = new Button();
      this.label1 = new Label();
      this.button4 = new Button();
      this.mainpanel = new Panel();
      Panel panel1 = new Panel();
      Panel panel2 = new Panel();
      panel1.SuspendLayout();
      panel2.SuspendLayout();
      this.SuspendLayout();
      panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      panel1.BackColor = Color.FromArgb(20, 20, 20);
      panel1.Controls.Add((Control) this.button5);
      panel1.Controls.Add((Control) this.button1);
      panel1.Controls.Add((Control) this.button2);
      panel1.Controls.Add((Control) this.button3);
      panel1.Controls.Add((Control) this.btnControls);
      panel1.Controls.Add((Control) this.btnVirus);
      panel1.Controls.Add((Control) this.btnSystemInfo);
      panel1.Controls.Add((Control) this.btnRedistributables);
      panel1.Controls.Add((Control) this.btnWindowsSettings);
      panel1.Location = new Point(5, 47);
      panel1.Name = "panelside";
      panel1.Size = new Size(640, 310);
      panel1.TabIndex = 0;
      this.button5.BackColor = Color.FromArgb(20, 20, 20);
      this.button5.BackgroundImageLayout = ImageLayout.Zoom;
      this.button5.FlatAppearance.BorderSize = 0;
      this.button5.FlatStyle = FlatStyle.Flat;
      this.button5.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.button5.ForeColor = Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.button5.ImageAlign = ContentAlignment.MiddleLeft;
      this.button5.Location = new Point(410, 3);
      this.button5.Name = "button5";
      this.button5.Size = new Size(66, 42);
      this.button5.TabIndex = 9;
      this.button5.Text = "Cleaners";
      this.button5.UseVisualStyleBackColor = false;
      this.button5.Click += new EventHandler(this.button5_Click);
      this.button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.button1.BackColor = Color.FromArgb(20, 20, 20);
      this.button1.BackgroundImageLayout = ImageLayout.Zoom;
      this.button1.FlatAppearance.BorderSize = 0;
      this.button1.FlatStyle = FlatStyle.Flat;
      this.button1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button1.ForeColor = Color.White;
      this.button1.Image = (Image) componentResourceManager.GetObject("button1.Image");
      this.button1.ImageAlign = ContentAlignment.MiddleLeft;
      this.button1.Location = new Point(556, 4);
      this.button1.Name = "button1";
      this.button1.Size = new Size(38, 40);
      this.button1.TabIndex = 4;
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.button2.BackColor = Color.FromArgb(20, 20, 20);
      this.button2.BackgroundImageLayout = ImageLayout.Zoom;
      this.button2.FlatAppearance.BorderSize = 0;
      this.button2.FlatStyle = FlatStyle.Flat;
      this.button2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button2.ForeColor = Color.White;
      this.button2.Image = (Image) componentResourceManager.GetObject("button2.Image");
      this.button2.ImageAlign = ContentAlignment.MiddleLeft;
      this.button2.Location = new Point(595, 5);
      this.button2.Name = "button2";
      this.button2.Size = new Size(38, 39);
      this.button2.TabIndex = 5;
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.button3.BackColor = Color.FromArgb(20, 20, 20);
      this.button3.BackgroundImageLayout = ImageLayout.Zoom;
      this.button3.FlatAppearance.BorderSize = 0;
      this.button3.FlatStyle = FlatStyle.Flat;
      this.button3.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.button3.ForeColor = Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.button3.ImageAlign = ContentAlignment.MiddleLeft;
      this.button3.Location = new Point(137, 4);
      this.button3.Name = "button3";
      this.button3.Size = new Size(65, 41);
      this.button3.TabIndex = 8;
      this.button3.Text = "Game Boosters";
      this.button3.UseVisualStyleBackColor = false;
      this.button3.Click += new EventHandler(this.button3_Click);
      this.btnControls.BackColor = Color.FromArgb(20, 20, 20);
      this.btnControls.BackgroundImageLayout = ImageLayout.Zoom;
      this.btnControls.FlatAppearance.BorderSize = 0;
      this.btnControls.FlatStyle = FlatStyle.Flat;
      this.btnControls.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnControls.ForeColor = Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.btnControls.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnControls.Location = new Point(341, 4);
      this.btnControls.Name = "btnControls";
      this.btnControls.Size = new Size(66, 41);
      this.btnControls.TabIndex = 7;
      this.btnControls.Text = "Controls";
      this.btnControls.UseVisualStyleBackColor = false;
      this.btnControls.Click += new EventHandler(this.btnControls_Click);
      this.btnVirus.BackColor = Color.FromArgb(20, 20, 20);
      this.btnVirus.BackgroundImageLayout = ImageLayout.Zoom;
      this.btnVirus.FlatAppearance.BorderSize = 0;
      this.btnVirus.FlatStyle = FlatStyle.Flat;
      this.btnVirus.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnVirus.ForeColor = Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.btnVirus.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnVirus.Location = new Point(205, 3);
      this.btnVirus.Name = "btnVirus";
      this.btnVirus.Size = new Size(65, 42);
      this.btnVirus.TabIndex = 6;
      this.btnVirus.Text = "A.C. Virus";
      this.btnVirus.UseVisualStyleBackColor = false;
      this.btnVirus.Click += new EventHandler(this.btnVirus_Click);
      this.btnSystemInfo.BackColor = Color.FromArgb(20, 20, 20);
      this.btnSystemInfo.BackgroundImageLayout = ImageLayout.Zoom;
      this.btnSystemInfo.FlatAppearance.BorderSize = 0;
      this.btnSystemInfo.FlatStyle = FlatStyle.Flat;
      this.btnSystemInfo.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnSystemInfo.ForeColor = Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.btnSystemInfo.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnSystemInfo.Location = new Point(1, 3);
      this.btnSystemInfo.Name = "btnSystemInfo";
      this.btnSystemInfo.Size = new Size(65, 42);
      this.btnSystemInfo.TabIndex = 2;
      this.btnSystemInfo.Text = "System Info";
      this.btnSystemInfo.UseVisualStyleBackColor = false;
      this.btnSystemInfo.Click += new EventHandler(this.btnSystemInfo_Click);
      this.btnRedistributables.BackColor = Color.FromArgb(20, 20, 20);
      this.btnRedistributables.BackgroundImageLayout = ImageLayout.Zoom;
      this.btnRedistributables.FlatAppearance.BorderSize = 0;
      this.btnRedistributables.FlatStyle = FlatStyle.Flat;
      this.btnRedistributables.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnRedistributables.ForeColor = Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.btnRedistributables.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnRedistributables.Location = new Point(273, 4);
      this.btnRedistributables.Name = "btnRedistributables";
      this.btnRedistributables.Size = new Size(65, 41);
      this.btnRedistributables.TabIndex = 1;
      this.btnRedistributables.Text = "Needed Installs";
      this.btnRedistributables.UseVisualStyleBackColor = false;
      this.btnRedistributables.Click += new EventHandler(this.btnRedistributables_Click);
      this.btnWindowsSettings.BackColor = Color.FromArgb(20, 20, 20);
      this.btnWindowsSettings.BackgroundImageLayout = ImageLayout.Zoom;
      this.btnWindowsSettings.FlatAppearance.BorderSize = 0;
      this.btnWindowsSettings.FlatStyle = FlatStyle.Flat;
      this.btnWindowsSettings.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnWindowsSettings.ForeColor = Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.btnWindowsSettings.ImageAlign = ContentAlignment.MiddleLeft;
      this.btnWindowsSettings.Location = new Point(69, 3);
      this.btnWindowsSettings.Name = "btnWindowsSettings";
      this.btnWindowsSettings.Size = new Size(65, 42);
      this.btnWindowsSettings.TabIndex = 0;
      this.btnWindowsSettings.Text = "Windows Settings";
      this.btnWindowsSettings.UseVisualStyleBackColor = false;
      this.btnWindowsSettings.Click += new EventHandler(this.btnWindowsSettings_Click);
      panel2.BackColor = Color.FromArgb(20, 20, 20);
      panel2.Controls.Add((Control) this.label1);
      panel2.Controls.Add((Control) this.button4);
      panel2.Dock = DockStyle.Top;
      panel2.Location = new Point(0, 0);
      panel2.Name = "panel1";
      panel2.Size = new Size(651, 40);
      panel2.TabIndex = 9;
      panel2.MouseDown += new MouseEventHandler(this.panel1_MouseDown);
      panel2.MouseMove += new MouseEventHandler(this.panel1_MouseMove);
      panel2.MouseUp += new MouseEventHandler(this.panel1_MouseUp);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.label1.Location = new Point(11, 13);
      this.label1.Name = "label1";
      this.label1.Size = new Size(299, 20);
      this.label1.TabIndex = 1;
      this.label1.Text = "LABSCHEATS | SUPPORT TOOL";
      this.button4.FlatStyle = FlatStyle.Flat;
      this.button4.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button4.ForeColor = Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.button4.Location = new Point(612, 8);
      this.button4.Name = "button4";
      this.button4.Size = new Size(23, 27);
      this.button4.TabIndex = 0;
      this.button4.Text = "X";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new EventHandler(this.button4_Click);
      this.mainpanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.mainpanel.BackColor = Color.Black;
      this.mainpanel.Location = new Point(10, 97);
      this.mainpanel.Name = "mainpanel";
      this.mainpanel.Size = new Size(630, (int) byte.MaxValue);
      this.mainpanel.TabIndex = 2;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Black;
      this.ClientSize = new Size(651, 363);
      this.Controls.Add((Control) this.mainpanel);
      this.Controls.Add((Control) panel2);
      this.Controls.Add((Control) panel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (Main);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Support Tool";
      this.FormClosing += new FormClosingEventHandler(this.Main_FormClosing);
      this.Load += new EventHandler(this.Main_Load);
      panel1.ResumeLayout(false);
      panel2.ResumeLayout(false);
      panel2.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
