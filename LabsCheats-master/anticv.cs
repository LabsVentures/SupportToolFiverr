// Decompiled with JetBrains decompiler
// Type: lmitp.anticv
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
  public class anticv : Form
  {
    private IContainer components = (IContainer) null;
    private Label label2;
    private TextBox textBox3;
    private TextBox textBox2;
    private TextBox textBox1;
    private Label label3;
    private Label label1;
    private PictureBox pictureBox1;

    public anticv() => this.InitializeComponent();

    private void anticv_Load(object sender, EventArgs e)
    {
      using (RegistryKey registryKey1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
      {
        using (RegistryKey registryKey2 = registryKey1.OpenSubKey("SYSTEM\\ControlSet001\\Services\\vgc"))
        {
          if (registryKey2 == null)
          {
            this.textBox1.Text = "NOT INSTALLED";
            this.textBox1.BackColor = System.Drawing.Color.Green;
            this.textBox1.TextAlign = HorizontalAlignment.Center;
          }
          else
          {
            this.textBox1.Text = "INSTALLED";
            this.textBox1.BackColor = System.Drawing.Color.Red;
            this.textBox1.TextAlign = HorizontalAlignment.Center;
          }
        }
      }
      using (RegistryKey registryKey3 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
      {
        using (RegistryKey registryKey4 = registryKey3.OpenSubKey("SOFTWARE\\Classes\\faceitac"))
        {
          if (registryKey4 == null)
          {
            this.textBox2.Text = "NOT INSTALLED";
            this.textBox2.BackColor = System.Drawing.Color.Green;
            this.textBox2.TextAlign = HorizontalAlignment.Center;
          }
          else
          {
            this.textBox2.Text = "INSTALLED";
            this.textBox2.BackColor = System.Drawing.Color.Red;
            this.textBox2.TextAlign = HorizontalAlignment.Center;
          }
        }
      }
      using (RegistryKey registryKey5 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
      {
        using (RegistryKey registryKey6 = registryKey5.OpenSubKey("SOFTWARE\\Microsoft\\Security Center\\Provider\\Av\\{23007AD3-69FE-687C-2629-D584AFFAF72B}"))
        {
          if (registryKey6 == null)
          {
            this.textBox3.Text = "NOT INSTALLED";
            this.textBox3.BackColor = System.Drawing.Color.Green;
            this.textBox3.TextAlign = HorizontalAlignment.Center;
          }
          else
          {
            this.textBox3.Text = "INSTALLED";
            this.textBox3.BackColor = System.Drawing.Color.Red;
            this.textBox3.TextAlign = HorizontalAlignment.Center;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (anticv));
      this.label2 = new Label();
      this.textBox3 = new TextBox();
      this.textBox2 = new TextBox();
      this.textBox1 = new TextBox();
      this.label3 = new Label();
      this.label1 = new Label();
      this.pictureBox1 = new PictureBox();
      Label label = new Label();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      label.Anchor = AnchorStyles.None;
      label.AutoSize = true;
      label.BackColor = System.Drawing.Color.Black;
      label.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      label.ForeColor = System.Drawing.Color.White;
      label.Location = new Point(5, 58);
      label.Name = "label8";
      label.Size = new Size(74, 18);
      label.TabIndex = 22;
      label.Text = "Face IT";
      this.label2.Anchor = AnchorStyles.None;
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = System.Drawing.Color.DimGray;
      this.label2.Location = new Point(319, 291);
      this.label2.Name = "label2";
      this.label2.Size = new Size(0, 37);
      this.label2.TabIndex = 3;
      this.textBox3.Location = new Point(155, 82);
      this.textBox3.Name = "textBox3";
      this.textBox3.ReadOnly = true;
      this.textBox3.Size = new Size(200, 20);
      this.textBox3.TabIndex = 28;
      this.textBox2.Location = new Point(155, 56);
      this.textBox2.Name = "textBox2";
      this.textBox2.ReadOnly = true;
      this.textBox2.Size = new Size(200, 20);
      this.textBox2.TabIndex = 27;
      this.textBox1.Location = new Point(155, 30);
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.Size = new Size(200, 20);
      this.textBox1.TabIndex = 26;
      this.label3.Anchor = AnchorStyles.None;
      this.label3.AutoSize = true;
      this.label3.BackColor = System.Drawing.Color.Black;
      this.label3.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = System.Drawing.Color.White;
      this.label3.Location = new Point(5, 84);
      this.label3.Name = "label3";
      this.label3.Size = new Size(138, 18);
      this.label3.TabIndex = 24;
      this.label3.Text = "Malware Bytes";
      this.label1.Anchor = AnchorStyles.None;
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.Color.Black;
      this.label1.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new Point(5, 32);
      this.label1.Name = "label1";
      this.label1.Size = new Size(134, 18);
      this.label1.TabIndex = 23;
      this.label1.Text = "Riot Vanguard";
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
      this.Controls.Add((Control) this.textBox3);
      this.Controls.Add((Control) this.textBox2);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) label);
      this.Controls.Add((Control) this.label2);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (anticv);
      this.Text = nameof (anticv);
      this.Load += new EventHandler(this.anticv_Load);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
