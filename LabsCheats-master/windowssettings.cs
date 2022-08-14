// Decompiled with JetBrains decompiler
// Type: lmitp.windowssettings
// Assembly: Support Tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7C2F509-6BDB-4CAE-AB6E-4A5371C4CE0D
// Assembly location: C:\Users\ethan\OneDrive\Desktop\Support_Tool.exe

using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace lmitp
{
  public class windowssettings : Form
  {
    private IContainer components = (IContainer) null;
    private Label label2;
    private Label label3;
    private Label label4;
    private TextBox textBox1;
    private TextBox textBox2;
    private TextBox textBox3;
    private TextBox textBox4;
    private Button button1;
    private Button button2;
    private TextBox textBox5;
    private Label label5;
    private PictureBox pictureBox1;

    public windowssettings() => this.InitializeComponent();

    private void windowssettings_Load(object sender, EventArgs e)
    {
      object obj1 = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "EnableLUA", (object) -1);
      if ((int) obj1 == 0)
      {
        this.textBox1.Text = "DISABLED";
        this.textBox1.BackColor = System.Drawing.Color.Green;
        this.textBox1.TextAlign = HorizontalAlignment.Center;
        this.button2.Visible = true;
      }
      else if ((int) obj1 == 1)
      {
        this.textBox1.Text = "ENABLED";
        this.textBox1.BackColor = System.Drawing.Color.Red;
        this.textBox1.TextAlign = HorizontalAlignment.Center;
        this.button1.Visible = true;
      }
      object obj2 = Registry.GetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\SecureBoot", "UEFISecureBootEnabled", (object) -1);
      if ((int) obj2 == 0)
      {
        this.textBox2.Text = "DISABLED";
        this.textBox2.BackColor = System.Drawing.Color.Green;
        this.textBox2.TextAlign = HorizontalAlignment.Center;
      }
      else if ((int) obj2 == 1)
      {
        this.textBox2.Text = "ENABLED";
        this.textBox2.BackColor = System.Drawing.Color.Red;
        this.textBox2.TextAlign = HorizontalAlignment.Center;
      }
      else if ((int) obj2 != 0)
      {
        this.textBox2.Text = "NOT SUPPORTED";
        this.textBox2.BackColor = System.Drawing.Color.Green;
        this.textBox2.TextAlign = HorizontalAlignment.Center;
      }
      else if ((int) obj2 != 1)
      {
        this.textBox2.Text = "NOT SUPPORTED";
        this.textBox2.BackColor = System.Drawing.Color.Green;
        this.textBox2.TextAlign = HorizontalAlignment.Center;
      }
      this.textBox3.Text = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "DisplayVersion", (object) "").ToString();
      string name1 = "SOFTWARE\\Microsoft\\Windows Defender\\Real-Time Protection";
      string name2 = "DisableRealtimeMonitoring";
      RegistryKey registryKey1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
      if (registryKey1 != null)
      {
        object obj3 = registryKey1.OpenSubKey(name1).GetValue(name2);
        if (obj3 != null && obj3 is int)
        {
          if ((int) obj3 == 1)
          {
            this.textBox4.Text = "DISABLED";
            this.textBox4.BackColor = System.Drawing.Color.Green;
            this.textBox4.TextAlign = HorizontalAlignment.Center;
          }
          else
          {
            this.textBox4.Text = "ENABLED";
            this.textBox4.BackColor = System.Drawing.Color.Red;
            this.textBox4.TextAlign = HorizontalAlignment.Center;
          }
        }
        else
        {
          this.textBox4.Text = "ENABLED";
          this.textBox4.BackColor = System.Drawing.Color.Red;
          this.textBox4.TextAlign = HorizontalAlignment.Center;
        }
      }
      else
      {
        this.textBox4.Text = "DISABLED - NOT FOUND";
        this.textBox4.BackColor = System.Drawing.Color.Green;
        this.textBox4.TextAlign = HorizontalAlignment.Center;
      }
      string name3 = "SOFTWARE\\Microsoft\\Windows Defender";
      string name4 = "DisableAntiVirus";
      RegistryKey registryKey2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
      if (registryKey2 != null)
      {
        object obj4 = registryKey2.OpenSubKey(name3).GetValue(name4);
        if (obj4 != null && obj4 is int)
        {
          if ((int) obj4 == 1)
          {
            this.textBox5.Text = "DISABLED";
            this.textBox5.BackColor = System.Drawing.Color.Green;
            this.textBox5.TextAlign = HorizontalAlignment.Center;
          }
          else
          {
            this.textBox5.Text = "ENABLED";
            this.textBox5.BackColor = System.Drawing.Color.Red;
            this.textBox5.TextAlign = HorizontalAlignment.Center;
          }
        }
        else
        {
          this.textBox5.Text = "ENABLED";
          this.textBox5.BackColor = System.Drawing.Color.Red;
          this.textBox5.TextAlign = HorizontalAlignment.Center;
        }
      }
      else
      {
        this.textBox5.Text = "DISABLED - NOT FOUND";
        this.textBox5.BackColor = System.Drawing.Color.Green;
        this.textBox5.TextAlign = HorizontalAlignment.Center;
      }
      this.textBox2.TextAlign = HorizontalAlignment.Center;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      try
      {
        this.DisableUAC();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error: " + ex?.ToString());
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      try
      {
        this.EnableUAC();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error: " + ex?.ToString());
      }
    }

    private void DisableUAC()
    {
      Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "EnableLUA", (object) 0);
      Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "ConsentPromptBehaviorAdmin", (object) 0);
      Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "PromptOnSecureDesktop", (object) 0);
      Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Action Center\\Checks\\{C8E6F269-B90A-4053-A3BE-499AFCEC98C4}.check.0", "CheckSetting", (object) this.StringToByteArray("23004100430042006C006F00620000000000000000000000010000000000000000000000"), RegistryValueKind.Binary);
    }

    private void EnableUAC()
    {
      Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "EnableLUA", (object) 1);
      Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "ConsentPromptBehaviorAdmin", (object) 1);
      Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "PromptOnSecureDesktop", (object) 1);
      Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Action Center\\Checks\\{C8E6F269-B90A-4053-A3BE-499AFCEC98C4}.check.0", "CheckSetting", (object) this.StringToByteArray("23004100430042006C006F00620000000000000000000000010000000000000000000000"), RegistryValueKind.Binary);
    }

    private byte[] StringToByteArray(string hex) => Enumerable.Range(0, hex.Length).Where<int>((Func<int, bool>) (x => x % 2 == 0)).Select<int, byte>((Func<int, byte>) (x => Convert.ToByte(hex.Substring(x, 2), 16))).ToArray<byte>();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (windowssettings));
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.textBox1 = new TextBox();
      this.textBox2 = new TextBox();
      this.textBox3 = new TextBox();
      this.textBox4 = new TextBox();
      this.button1 = new Button();
      this.button2 = new Button();
      this.textBox5 = new TextBox();
      this.label5 = new Label();
      this.pictureBox1 = new PictureBox();
      Label label = new Label();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      label.Anchor = AnchorStyles.None;
      label.AutoSize = true;
      label.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      label.ForeColor = System.Drawing.Color.White;
      label.Location = new Point(2, 61);
      label.Name = "label1";
      label.Size = new Size(115, 18);
      label.TabIndex = 1;
      label.Text = "Secure Boot";
      this.label2.Anchor = AnchorStyles.None;
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = System.Drawing.Color.White;
      this.label2.Location = new Point(2, 35);
      this.label2.Name = "label2";
      this.label2.Size = new Size(45, 18);
      this.label2.TabIndex = 2;
      this.label2.Text = "UAC";
      this.label3.Anchor = AnchorStyles.None;
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = System.Drawing.Color.White;
      this.label3.Location = new Point(2, 84);
      this.label3.Name = "label3";
      this.label3.Size = new Size(159, 18);
      this.label3.TabIndex = 3;
      this.label3.Text = "Windows Version";
      this.label4.Anchor = AnchorStyles.None;
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = System.Drawing.Color.White;
      this.label4.Location = new Point(2, 108);
      this.label4.Name = "label4";
      this.label4.Size = new Size(194, 18);
      this.label4.TabIndex = 4;
      this.label4.Text = "Real-Time Protection";
      this.textBox1.Location = new Point(212, 28);
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.Size = new Size(200, 20);
      this.textBox1.TabIndex = 6;
      this.textBox1.TextAlign = HorizontalAlignment.Center;
      this.textBox2.Location = new Point(212, 54);
      this.textBox2.Name = "textBox2";
      this.textBox2.ReadOnly = true;
      this.textBox2.Size = new Size(200, 20);
      this.textBox2.TabIndex = 7;
      this.textBox2.TextAlign = HorizontalAlignment.Center;
      this.textBox3.Location = new Point(212, 80);
      this.textBox3.Name = "textBox3";
      this.textBox3.ReadOnly = true;
      this.textBox3.Size = new Size(200, 20);
      this.textBox3.TabIndex = 8;
      this.textBox3.TextAlign = HorizontalAlignment.Center;
      this.textBox4.Location = new Point(212, 106);
      this.textBox4.Name = "textBox4";
      this.textBox4.ReadOnly = true;
      this.textBox4.Size = new Size(200, 20);
      this.textBox4.TabIndex = 9;
      this.textBox4.TextAlign = HorizontalAlignment.Center;
      this.button1.Location = new Point(418, 25);
      this.button1.Name = "button1";
      this.button1.Size = new Size(90, 23);
      this.button1.TabIndex = 10;
      this.button1.Text = "DISABLE";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Visible = false;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.button2.Location = new Point(418, 25);
      this.button2.Name = "button2";
      this.button2.Size = new Size(90, 23);
      this.button2.TabIndex = 11;
      this.button2.Text = "ENABLE";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Visible = false;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.textBox5.Location = new Point(212, 132);
      this.textBox5.Name = "textBox5";
      this.textBox5.ReadOnly = true;
      this.textBox5.Size = new Size(200, 20);
      this.textBox5.TabIndex = 13;
      this.textBox5.TextAlign = HorizontalAlignment.Center;
      this.label5.Anchor = AnchorStyles.None;
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = System.Drawing.Color.White;
      this.label5.Location = new Point(2, 134);
      this.label5.Name = "label5";
      this.label5.Size = new Size(176, 18);
      this.label5.TabIndex = 12;
      this.label5.Text = "Windows Defender";
      this.pictureBox1.Image = (Image) componentResourceManager.GetObject("pictureBox1.Image");
      this.pictureBox1.Location = new Point(490, 105);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(140, 150);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 47;
      this.pictureBox1.TabStop = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new Size(630, (int) byte.MaxValue);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.textBox5);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.textBox4);
      this.Controls.Add((Control) this.textBox3);
      this.Controls.Add((Control) this.textBox2);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) label);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (windowssettings);
      this.Text = "dashboardform";
      this.Load += new EventHandler(this.windowssettings_Load);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
