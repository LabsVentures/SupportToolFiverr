// Decompiled with JetBrains decompiler
// Type: lmitp.redist
// Assembly: Support Tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7C2F509-6BDB-4CAE-AB6E-4A5371C4CE0D
// Assembly location: C:\Users\ethan\OneDrive\Desktop\Support_Tool.exe

using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace lmitp
{
  public class redist : Form
  {
    private IContainer components = (IContainer) null;
    private TextBox textBox4;
    private TextBox textBox3;
    private TextBox textBox2;
    private TextBox textBox1;
    private Label label4;
    private Label label3;
    private Label label1;
    private TextBox textBox5;
    private Label label2;
    private PictureBox pictureBox1;

    public redist() => this.InitializeComponent();

    private void redist_Load(object sender, EventArgs e)
    {
      using (RegistryKey registryKey1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
      {
        using (RegistryKey registryKey2 = registryKey1.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\{042d26ef-3dbe-4c25-95d3-4c1b11b235a7}"))
        {
          if (registryKey2 == null)
          {
            this.textBox1.Text = "NOT INSTALLED";
            this.textBox1.BackColor = System.Drawing.Color.Red;
            this.textBox1.TextAlign = HorizontalAlignment.Center;
          }
          else
          {
            this.textBox1.Text = "INSTALLED";
            this.textBox1.BackColor = System.Drawing.Color.Green;
            this.textBox1.TextAlign = HorizontalAlignment.Center;
          }
        }
      }
      using (RegistryKey registryKey3 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
      {
        using (RegistryKey registryKey4 = registryKey3.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\{9dff3540-fc85-4ed5-ac84-9e3c7fd8bece}"))
        {
          if (registryKey4 == null)
          {
            this.textBox2.Text = "NOT INSTALLED";
            this.textBox2.BackColor = System.Drawing.Color.Red;
            this.textBox2.TextAlign = HorizontalAlignment.Center;
          }
          else
          {
            this.textBox2.Text = "INSTALLED";
            this.textBox2.BackColor = System.Drawing.Color.Green;
            this.textBox2.TextAlign = HorizontalAlignment.Center;
          }
        }
      }
      using (RegistryKey registryKey5 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
      {
        using (RegistryKey registryKey6 = registryKey5.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\{2d507699-404c-4c8b-a54a-38e352f32cdd}"))
        {
          if (registryKey6 == null)
          {
            this.textBox3.Text = "NOT INSTALLED";
            this.textBox3.BackColor = System.Drawing.Color.Red;
            this.textBox3.TextAlign = HorizontalAlignment.Center;
          }
          else
          {
            this.textBox3.Text = "INSTALLED";
            this.textBox3.BackColor = System.Drawing.Color.Green;
            this.textBox3.TextAlign = HorizontalAlignment.Center;
          }
        }
      }
      using (RegistryKey registryKey7 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
      {
        using (RegistryKey registryKey8 = registryKey7.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\{817e21c1-6b3a-4bc1-8c49-67e4e1887b3a}"))
        {
          if (registryKey8 == null)
          {
            this.textBox4.Text = "NOT INSTALLED";
            this.textBox4.BackColor = System.Drawing.Color.Red;
            this.textBox4.TextAlign = HorizontalAlignment.Center;
          }
          else
          {
            this.textBox4.Text = "INSTALLED";
            this.textBox4.BackColor = System.Drawing.Color.Green;
            this.textBox4.TextAlign = HorizontalAlignment.Center;
          }
        }
      }
      using (RegistryKey registryKey9 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
      {
        using (RegistryKey registryKey10 = registryKey9.OpenSubKey("SOFTWARE\\Microsoft\\DirectX"))
        {
          if (registryKey10 == null)
          {
            this.textBox5.Text = "NOT INSTALLED";
            this.textBox5.BackColor = System.Drawing.Color.Red;
            this.textBox5.TextAlign = HorizontalAlignment.Center;
          }
          else
          {
            this.textBox5.Text = "V: " + new Version(registryKey10.GetValue("Version") as string)?.ToString();
            this.textBox5.BackColor = System.Drawing.Color.Green;
            this.textBox5.TextAlign = HorizontalAlignment.Center;
          }
        }
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (redist));
      this.textBox4 = new TextBox();
      this.textBox3 = new TextBox();
      this.textBox2 = new TextBox();
      this.textBox1 = new TextBox();
      this.label4 = new Label();
      this.label3 = new Label();
      this.label1 = new Label();
      this.textBox5 = new TextBox();
      this.label2 = new Label();
      this.pictureBox1 = new PictureBox();
      Label label = new Label();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      label.Anchor = AnchorStyles.None;
      label.AutoSize = true;
      label.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      label.ForeColor = System.Drawing.Color.White;
      label.Location = new Point(5, 57);
      label.Name = "label8";
      label.Size = new Size(120, 18);
      label.TabIndex = 13;
      label.Text = "VC 2013 X86";
      this.textBox4.BackColor = System.Drawing.Color.Gainsboro;
      this.textBox4.Location = new Point(155, 108);
      this.textBox4.Name = "textBox4";
      this.textBox4.ReadOnly = true;
      this.textBox4.Size = new Size(200, 20);
      this.textBox4.TabIndex = 21;
      this.textBox4.TextAlign = HorizontalAlignment.Center;
      this.textBox3.BackColor = System.Drawing.Color.Gainsboro;
      this.textBox3.Location = new Point(155, 82);
      this.textBox3.Name = "textBox3";
      this.textBox3.ReadOnly = true;
      this.textBox3.Size = new Size(200, 20);
      this.textBox3.TabIndex = 20;
      this.textBox3.TextAlign = HorizontalAlignment.Center;
      this.textBox2.BackColor = System.Drawing.Color.Gainsboro;
      this.textBox2.Location = new Point(155, 56);
      this.textBox2.Name = "textBox2";
      this.textBox2.ReadOnly = true;
      this.textBox2.Size = new Size(200, 20);
      this.textBox2.TabIndex = 19;
      this.textBox2.TextAlign = HorizontalAlignment.Center;
      this.textBox1.BackColor = System.Drawing.Color.Gainsboro;
      this.textBox1.Location = new Point(155, 30);
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.Size = new Size(200, 20);
      this.textBox1.TabIndex = 18;
      this.textBox1.TextAlign = HorizontalAlignment.Center;
      this.label4.Anchor = AnchorStyles.None;
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = System.Drawing.Color.White;
      this.label4.Location = new Point(5, 109);
      this.label4.Name = "label4";
      this.label4.Size = new Size(128, 18);
      this.label4.TabIndex = 16;
      this.label4.Text = "VC 15-22 X86";
      this.label3.Anchor = AnchorStyles.None;
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = System.Drawing.Color.White;
      this.label3.Location = new Point(5, 83);
      this.label3.Name = "label3";
      this.label3.Size = new Size(128, 18);
      this.label3.TabIndex = 15;
      this.label3.Text = "VC 15-22 X64";
      this.label1.Anchor = AnchorStyles.None;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new Point(5, 31);
      this.label1.Name = "label1";
      this.label1.Size = new Size(120, 18);
      this.label1.TabIndex = 14;
      this.label1.Text = "VC 2013 X64";
      this.textBox5.BackColor = System.Drawing.Color.Gainsboro;
      this.textBox5.Location = new Point(155, 134);
      this.textBox5.Name = "textBox5";
      this.textBox5.ReadOnly = true;
      this.textBox5.Size = new Size(200, 20);
      this.textBox5.TabIndex = 23;
      this.textBox5.TextAlign = HorizontalAlignment.Center;
      this.label2.Anchor = AnchorStyles.None;
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = System.Drawing.Color.White;
      this.label2.Location = new Point(5, 135);
      this.label2.Name = "label2";
      this.label2.Size = new Size(77, 18);
      this.label2.TabIndex = 22;
      this.label2.Text = "Direct X";
      this.pictureBox1.Image = (Image) componentResourceManager.GetObject("pictureBox1.Image");
      this.pictureBox1.Location = new Point(490, 105);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(140, 150);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 48;
      this.pictureBox1.TabStop = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new Size(630, (int) byte.MaxValue);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.textBox5);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.textBox4);
      this.Controls.Add((Control) this.textBox3);
      this.Controls.Add((Control) this.textBox2);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) label);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (redist);
      this.Load += new EventHandler(this.redist_Load);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
