// Decompiled with JetBrains decompiler
// Type: lmitp.controls
// Assembly: Support Tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7C2F509-6BDB-4CAE-AB6E-4A5371C4CE0D
// Assembly location: C:\Users\ethan\OneDrive\Desktop\Support_Tool.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace lmitp
{
  public class controls : Form
  {
    private IContainer components = (IContainer) null;
    private Button button1;
    private Button button2;
    private Button button6;
    private Button button7;
    private Button button8;
    private Button button9;
    private Button button10;
    private Button button11;
    private Button button12;
    private Button button13;
    private Button button14;
    private Button button3;
    private Button button4;
    private PictureBox pictureBox1;

    public controls() => this.InitializeComponent();

    private static void Extract(
      string nameSpace,
      string outDirectory,
      string internalFilePath,
      string resourceName)
    {
      using (Stream manifestResourceStream = Assembly.GetCallingAssembly().GetManifestResourceStream(nameSpace + "." + (internalFilePath == "" ? "" : internalFilePath + ".") + resourceName))
      {
        using (BinaryReader binaryReader = new BinaryReader(manifestResourceStream))
        {
          using (FileStream output = new FileStream(outDirectory + "\\" + resourceName, FileMode.OpenOrCreate))
          {
            using (BinaryWriter binaryWriter = new BinaryWriter((Stream) output))
              binaryWriter.Write(binaryReader.ReadBytes((int) manifestResourceStream.Length));
          }
        }
      }
    }

    private void button7_Click(object sender, EventArgs e) => Process.Start("https://drive.google.com/file/d/1SFBUr1FhaK2MoLxOF7js8iBRxsvgxHov");

    private void button6_Click(object sender, EventArgs e)
    {
      Directory.CreateDirectory("C:\\TempFold");
      controls.Extract("SupportTool", "C:\\TempFold", "Programs", "revosetup.exe");
      Process.Start("C:\\TempFold\\revosetup.exe");
    }

    private void button8_Click(object sender, EventArgs e)
    {
      Directory.CreateDirectory("C:\\TempFold");
      controls.Extract("SupportTool", "C:\\TempFold", "Programs", "Wub.exe");
      Process.Start("C:\\TempFold\\Wub.exe");
    }

    private void button10_Click(object sender, EventArgs e)
    {
      Directory.CreateDirectory("C:\\TempFold");
      controls.Extract("SupportTool", "C:\\TempFold", "Programs", "vcredist_2013_x64.exe");
      Process.Start("C:\\TempFold\\vcredist_2013_x64.exe");
    }

    private void button11_Click(object sender, EventArgs e)
    {
      Directory.CreateDirectory("C:\\TempFold");
      controls.Extract("SupportTool", "C:\\TempFold", "Programs", "vcredist_2013_x86.exe");
      Process.Start("C:\\TempFold\\vcredist_2013_x86.exe");
    }

    private void button12_Click(object sender, EventArgs e)
    {
      Directory.CreateDirectory("C:\\TempFold");
      controls.Extract("SupportTool", "C:\\TempFold", "Programs", "vcredist_15.22_x64.exe");
      Process.Start("C:\\TempFold\\vcredist_15.22_x64.exe");
    }

    private void button13_Click(object sender, EventArgs e)
    {
      Directory.CreateDirectory("C:\\TempFold");
      controls.Extract("SupportTool", "C:\\TempFold", "Programs", "vcredist_15.22_x86.exe");
      Process.Start("C:\\TempFold\\vcredist_15.22_x86.exe");
    }

    private void button9_Click(object sender, EventArgs e)
    {
      Directory.CreateDirectory("C:\\TempFold");
      controls.Extract("SupportTool", "C:\\TempFold", "Programs", "dxwebsetup.exe");
      Process.Start("C:\\TempFold\\dxwebsetup.exe");
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Directory.CreateDirectory("C:\\TempFold");
      controls.Extract("SupportTool", "C:\\TempFold", "Programs", "dControl.exe");
      Process.Start("C:\\TempFold\\dControl.exe");
    }

    private void button2_Click(object sender, EventArgs e) => Process.Start("https://down.amanvpn.net/2022/tom/tomvpn-win-2.5.0-46.exe");

    private void button14_Click(object sender, EventArgs e)
    {
      Directory.CreateDirectory("C:\\TempFold");
      controls.Extract("SupportTool", "C:\\TempFold", "Programs", "temp.exe");
      Process.Start("C:\\TempFold\\temp.exe");
      Thread.Sleep(1000);
    }

    private void button3_Click(object sender, EventArgs e) => new Process()
    {
      StartInfo = new ProcessStartInfo()
      {
        FileName = "cmd.exe",
        Verb = "runas",
        Arguments = "/K dism.exe /Online /Disable-Feature:Microsoft-Hyper-V"
      }
    }.Start();

    private void button4_Click(object sender, EventArgs e) => new Process()
    {
      StartInfo = new ProcessStartInfo()
      {
        FileName = "cmd.exe",
        Verb = "runas",
        Arguments = "/K dism.exe /Online /Enable-Feature:Microsoft-Hyper-V /All"
      }
    }.Start();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (controls));
      this.button1 = new Button();
      this.button2 = new Button();
      this.button6 = new Button();
      this.button7 = new Button();
      this.button8 = new Button();
      this.button9 = new Button();
      this.button10 = new Button();
      this.button11 = new Button();
      this.button12 = new Button();
      this.button13 = new Button();
      this.button14 = new Button();
      this.button3 = new Button();
      this.button4 = new Button();
      this.pictureBox1 = new PictureBox();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      this.button1.FlatStyle = FlatStyle.Flat;
      this.button1.ForeColor = Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.button1.Location = new Point(12, 20);
      this.button1.Name = "button1";
      this.button1.Size = new Size(130, 30);
      this.button1.TabIndex = 4;
      this.button1.Text = "Defender Control";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.button2.FlatStyle = FlatStyle.Flat;
      this.button2.ForeColor = Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.button2.Location = new Point(12, 112);
      this.button2.Name = "button2";
      this.button2.Size = new Size(130, 30);
      this.button2.TabIndex = 6;
      this.button2.Text = "Tom VPN";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.button6.FlatStyle = FlatStyle.Flat;
      this.button6.ForeColor = Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.button6.Location = new Point(12, 158);
      this.button6.Name = "button6";
      this.button6.Size = new Size(130, 30);
      this.button6.TabIndex = 11;
      this.button6.Text = "Revo Uninstaller";
      this.button6.UseVisualStyleBackColor = true;
      this.button6.Click += new EventHandler(this.button6_Click);
      this.button7.FlatStyle = FlatStyle.Flat;
      this.button7.ForeColor = Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.button7.Location = new Point(12, 204);
      this.button7.Name = "button7";
      this.button7.Size = new Size(130, 30);
      this.button7.TabIndex = 12;
      this.button7.Text = "2004 ISO";
      this.button7.UseVisualStyleBackColor = true;
      this.button7.Click += new EventHandler(this.button7_Click);
      this.button8.FlatStyle = FlatStyle.Flat;
      this.button8.ForeColor = Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.button8.Location = new Point(12, 66);
      this.button8.Name = "button8";
      this.button8.Size = new Size(130, 30);
      this.button8.TabIndex = 13;
      this.button8.Text = "Win Update Control";
      this.button8.UseVisualStyleBackColor = true;
      this.button8.Click += new EventHandler(this.button8_Click);
      this.button9.FlatStyle = FlatStyle.Flat;
      this.button9.ForeColor = Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.button9.Location = new Point(166, 20);
      this.button9.Name = "button9";
      this.button9.Size = new Size(130, 30);
      this.button9.TabIndex = 14;
      this.button9.Text = "Update DirectX";
      this.button9.UseVisualStyleBackColor = true;
      this.button9.Click += new EventHandler(this.button9_Click);
      this.button10.FlatStyle = FlatStyle.Flat;
      this.button10.ForeColor = Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.button10.Location = new Point(166, 66);
      this.button10.Name = "button10";
      this.button10.Size = new Size(130, 30);
      this.button10.TabIndex = 15;
      this.button10.Text = "Update VC 2013 x64";
      this.button10.UseVisualStyleBackColor = true;
      this.button10.Click += new EventHandler(this.button10_Click);
      this.button11.FlatStyle = FlatStyle.Flat;
      this.button11.ForeColor = Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.button11.Location = new Point(166, 112);
      this.button11.Name = "button11";
      this.button11.Size = new Size(130, 30);
      this.button11.TabIndex = 16;
      this.button11.Text = "Update VC 2013 x86";
      this.button11.UseVisualStyleBackColor = true;
      this.button11.Click += new EventHandler(this.button11_Click);
      this.button12.FlatStyle = FlatStyle.Flat;
      this.button12.ForeColor = Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.button12.Location = new Point(166, 158);
      this.button12.Name = "button12";
      this.button12.Size = new Size(130, 30);
      this.button12.TabIndex = 17;
      this.button12.Text = "Update VC 15/22 x64";
      this.button12.UseVisualStyleBackColor = true;
      this.button12.Click += new EventHandler(this.button12_Click);
      this.button13.FlatStyle = FlatStyle.Flat;
      this.button13.ForeColor = Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.button13.Location = new Point(166, 204);
      this.button13.Name = "button13";
      this.button13.Size = new Size(130, 30);
      this.button13.TabIndex = 18;
      this.button13.Text = "Update VC 15/22 x86";
      this.button13.UseVisualStyleBackColor = true;
      this.button13.Click += new EventHandler(this.button13_Click);
      this.button14.FlatStyle = FlatStyle.Flat;
      this.button14.ForeColor = Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.button14.Location = new Point(322, 20);
      this.button14.Name = "button14";
      this.button14.Size = new Size(130, 30);
      this.button14.TabIndex = 19;
      this.button14.Text = "Virtualization Test";
      this.button14.UseVisualStyleBackColor = true;
      this.button14.Click += new EventHandler(this.button14_Click);
      this.button3.FlatStyle = FlatStyle.Flat;
      this.button3.ForeColor = Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.button3.Location = new Point(322, 66);
      this.button3.Name = "button3";
      this.button3.Size = new Size(130, 30);
      this.button3.TabIndex = 48;
      this.button3.Text = "Disable Hyper-V";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new EventHandler(this.button3_Click);
      this.button4.FlatStyle = FlatStyle.Flat;
      this.button4.ForeColor = Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.button4.Location = new Point(322, 112);
      this.button4.Name = "button4";
      this.button4.Size = new Size(130, 30);
      this.button4.TabIndex = 49;
      this.button4.Text = "Enable Hyper-V";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new EventHandler(this.button4_Click);
      this.pictureBox1.Image = (Image) componentResourceManager.GetObject("pictureBox1.Image");
      this.pictureBox1.Location = new Point(490, 105);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(140, 150);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 50;
      this.pictureBox1.TabStop = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Black;
      this.ClientSize = new Size(630, (int) byte.MaxValue);
      this.ControlBox = false;
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.button4);
      this.Controls.Add((Control) this.button3);
      this.Controls.Add((Control) this.button14);
      this.Controls.Add((Control) this.button13);
      this.Controls.Add((Control) this.button12);
      this.Controls.Add((Control) this.button11);
      this.Controls.Add((Control) this.button10);
      this.Controls.Add((Control) this.button9);
      this.Controls.Add((Control) this.button8);
      this.Controls.Add((Control) this.button7);
      this.Controls.Add((Control) this.button6);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (controls);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = nameof (controls);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
