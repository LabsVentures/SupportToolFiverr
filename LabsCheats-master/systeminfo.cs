// Decompiled with JetBrains decompiler
// Type: lmitp.systeminfo
// Assembly: Support Tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7C2F509-6BDB-4CAE-AB6E-4A5371C4CE0D
// Assembly location: C:\Users\ethan\OneDrive\Desktop\Support_Tool.exe

using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Management;
using System.Windows.Forms;

namespace lmitp
{
  public class systeminfo : Form
  {
    private IContainer components = (IContainer) null;
    private PictureBox pictureBox1;
    private TextBox textBox10;
    private Label label10;
    private TextBox textBox9;
    private Label label9;
    private TextBox textBox8;
    private TextBox textBox7;
    private TextBox textBox6;
    private TextBox textBox5;
    private TextBox textBox4;
    private TextBox textBox3;
    private TextBox textBox2;
    private TextBox textBox1;
    private Label label8;
    private Label label7;
    private Label label2;
    private Label label6;
    private Label label5;
    private Label label4;
    private Label label3;
    private Label label1;

    public systeminfo() => this.InitializeComponent();

    private void systeminfo_Load(object sender, EventArgs e)
    {
      ManagementObjectSearcher managementObjectSearcher1 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
      ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_MotherboardDevice");
      ManagementObjectSearcher managementObjectSearcher3 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM win32_processor");
      ManagementObjectSearcher managementObjectSearcher4 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");
      foreach (ManagementObject managementObject in managementObjectSearcher1.Get())
        this.textBox8.Text = new systeminfo.MotherBoard()
        {
          MBSN = managementObject["SerialNumber"].ToString()
        }.MBSN;
      foreach (ManagementObject managementObject in managementObjectSearcher1.Get())
        this.textBox6.Text = new systeminfo.MotherBoardMan()
        {
          MBMa = managementObject["Manufacturer"].ToString()
        }.MBMa;
      foreach (ManagementObject managementObject in managementObjectSearcher1.Get())
        this.textBox7.Text = new systeminfo.MotherBoardModel()
        {
          MBmodel = managementObject["Product"].ToString()
        }.MBmodel;
      foreach (ManagementObject managementObject in managementObjectSearcher3.Get())
        this.textBox2.Text = new systeminfo.CPU()
        {
          CPUSN = managementObject["processorID"].ToString()
        }.CPUSN;
      foreach (ManagementObject managementObject in managementObjectSearcher3.Get())
        this.textBox1.Text = new systeminfo.CPUN()
        {
          CPUNa = managementObject["Name"].ToString()
        }.CPUNa;
      ManagementObjectCollection instances = new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances();
      string empty = string.Empty;
      foreach (ManagementObject managementObject in instances)
      {
        if (empty == string.Empty && (bool) managementObject["IPEnabled"])
          empty = managementObject["MacAddress"].ToString();
        managementObject.Dispose();
      }
      this.textBox3.Text = empty;
      ManagementObjectCollection objectCollection = new ManagementObjectSearcher(new ManagementScope(), new ObjectQuery("SELECT Capacity FROM Win32_PhysicalMemory")).Get();
      long num1 = 0;
      foreach (ManagementBaseObject managementBaseObject in objectCollection)
      {
        long int64 = Convert.ToInt64(managementBaseObject["Capacity"]);
        num1 += int64;
      }
      this.textBox4.Text = (num1 / 1024L / 1024L / 1024L).ToString() + " GB";
      int num2 = 0;
      foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher(new ManagementScope(), new ObjectQuery("SELECT MemoryDevices FROM Win32_PhysicalMemoryArray")).Get())
        num2 = Convert.ToInt32(managementBaseObject["MemoryDevices"]);
      this.textBox5.Text = num2.ToString();
      this.textBox9.Text = (string) Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion")?.GetValue("ProductName");
      foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("select * from Win32_VideoController").Get())
        this.textBox10.Text = managementBaseObject["Name"]?.ToString() ?? "";
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (systeminfo));
      this.pictureBox1 = new PictureBox();
      this.textBox10 = new TextBox();
      this.label10 = new Label();
      this.textBox9 = new TextBox();
      this.label9 = new Label();
      this.textBox8 = new TextBox();
      this.textBox7 = new TextBox();
      this.textBox6 = new TextBox();
      this.textBox5 = new TextBox();
      this.textBox4 = new TextBox();
      this.textBox3 = new TextBox();
      this.textBox2 = new TextBox();
      this.textBox1 = new TextBox();
      this.label8 = new Label();
      this.label7 = new Label();
      this.label2 = new Label();
      this.label6 = new Label();
      this.label5 = new Label();
      this.label4 = new Label();
      this.label3 = new Label();
      this.label1 = new Label();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      this.pictureBox1.Image = (Image) componentResourceManager.GetObject("pictureBox1.Image");
      this.pictureBox1.Location = new Point(490, 105);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(140, 150);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 48;
      this.pictureBox1.TabStop = false;
      this.textBox10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.textBox10.BackColor = System.Drawing.Color.Black;
      this.textBox10.ForeColor = System.Drawing.Color.White;
      this.textBox10.Location = new Point(119, 180);
      this.textBox10.Name = "textBox10";
      this.textBox10.ReadOnly = true;
      this.textBox10.Size = new Size(238, 20);
      this.textBox10.TabIndex = 70;
      this.textBox10.TextAlign = HorizontalAlignment.Center;
      this.label10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.label10.AutoSize = true;
      this.label10.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label10.ForeColor = System.Drawing.Color.White;
      this.label10.Location = new Point(17, 180);
      this.label10.Name = "label10";
      this.label10.Size = new Size(39, 16);
      this.label10.TabIndex = 69;
      this.label10.Text = "GPU";
      this.textBox9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.textBox9.BackColor = System.Drawing.Color.Black;
      this.textBox9.ForeColor = System.Drawing.Color.White;
      this.textBox9.Location = new Point(392, 70);
      this.textBox9.Name = "textBox9";
      this.textBox9.ReadOnly = true;
      this.textBox9.Size = new Size(214, 20);
      this.textBox9.TabIndex = 68;
      this.textBox9.TextAlign = HorizontalAlignment.Center;
      this.label9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.label9.AutoSize = true;
      this.label9.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label9.ForeColor = System.Drawing.Color.White;
      this.label9.Location = new Point(430, 50);
      this.label9.Name = "label9";
      this.label9.Size = new Size(130, 16);
      this.label9.TabIndex = 67;
      this.label9.Text = "Operating System";
      this.textBox8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.textBox8.BackColor = System.Drawing.Color.Black;
      this.textBox8.ForeColor = System.Drawing.Color.White;
      this.textBox8.Location = new Point(119, 128);
      this.textBox8.Name = "textBox8";
      this.textBox8.ReadOnly = true;
      this.textBox8.Size = new Size(238, 20);
      this.textBox8.TabIndex = 66;
      this.textBox8.TextAlign = HorizontalAlignment.Center;
      this.textBox7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.textBox7.BackColor = System.Drawing.Color.Black;
      this.textBox7.ForeColor = System.Drawing.Color.White;
      this.textBox7.Location = new Point(119, 154);
      this.textBox7.Name = "textBox7";
      this.textBox7.ReadOnly = true;
      this.textBox7.Size = new Size(238, 20);
      this.textBox7.TabIndex = 65;
      this.textBox7.TextAlign = HorizontalAlignment.Center;
      this.textBox6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.textBox6.BackColor = System.Drawing.Color.Black;
      this.textBox6.ForeColor = System.Drawing.Color.White;
      this.textBox6.Location = new Point(119, 102);
      this.textBox6.Name = "textBox6";
      this.textBox6.ReadOnly = true;
      this.textBox6.Size = new Size(238, 20);
      this.textBox6.TabIndex = 64;
      this.textBox6.TextAlign = HorizontalAlignment.Center;
      this.textBox5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.textBox5.BackColor = System.Drawing.Color.Black;
      this.textBox5.ForeColor = System.Drawing.Color.White;
      this.textBox5.Location = new Point(521, 27);
      this.textBox5.Name = "textBox5";
      this.textBox5.ReadOnly = true;
      this.textBox5.Size = new Size(85, 20);
      this.textBox5.TabIndex = 63;
      this.textBox5.TextAlign = HorizontalAlignment.Center;
      this.textBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.textBox4.BackColor = System.Drawing.Color.Black;
      this.textBox4.ForeColor = System.Drawing.Color.White;
      this.textBox4.Location = new Point(392, 27);
      this.textBox4.Name = "textBox4";
      this.textBox4.ReadOnly = true;
      this.textBox4.Size = new Size(85, 20);
      this.textBox4.TabIndex = 62;
      this.textBox4.TextAlign = HorizontalAlignment.Center;
      this.textBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.textBox3.BackColor = System.Drawing.Color.Black;
      this.textBox3.ForeColor = System.Drawing.Color.White;
      this.textBox3.Location = new Point(189, 70);
      this.textBox3.Name = "textBox3";
      this.textBox3.ReadOnly = true;
      this.textBox3.Size = new Size(168, 20);
      this.textBox3.TabIndex = 61;
      this.textBox3.TextAlign = HorizontalAlignment.Center;
      this.textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.textBox2.BackColor = System.Drawing.Color.Black;
      this.textBox2.ForeColor = System.Drawing.Color.White;
      this.textBox2.Location = new Point(12, 70);
      this.textBox2.Name = "textBox2";
      this.textBox2.ReadOnly = true;
      this.textBox2.Size = new Size(147, 20);
      this.textBox2.TabIndex = 60;
      this.textBox2.TextAlign = HorizontalAlignment.Center;
      this.textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.textBox1.BackColor = System.Drawing.Color.Black;
      this.textBox1.ForeColor = System.Drawing.Color.White;
      this.textBox1.Location = new Point(12, 28);
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.Size = new Size(345, 20);
      this.textBox1.TabIndex = 59;
      this.textBox1.TextAlign = HorizontalAlignment.Center;
      this.label8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.label8.AutoSize = true;
      this.label8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label8.ForeColor = System.Drawing.Color.White;
      this.label8.Location = new Point(501, 8);
      this.label8.Name = "label8";
      this.label8.Size = new Size(137, 16);
      this.label8.TabIndex = 58;
      this.label8.Text = "RAM Slots (In Use)";
      this.label7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.label7.AutoSize = true;
      this.label7.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = System.Drawing.Color.White;
      this.label7.Location = new Point(384, 8);
      this.label7.Name = "label7";
      this.label7.Size = new Size(105, 16);
      this.label7.TabIndex = 57;
      this.label7.Text = "RAM Capacity";
      this.label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = System.Drawing.Color.White;
      this.label2.Location = new Point(223, 51);
      this.label2.Name = "label2";
      this.label2.Size = new Size(113, 16);
      this.label2.TabIndex = 56;
      this.label2.Text = "M.A.C. Address";
      this.label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label6.ForeColor = System.Drawing.Color.White;
      this.label6.Location = new Point(11, 51);
      this.label6.Name = "label6";
      this.label6.Size = new Size(142, 16);
      this.label6.TabIndex = 55;
      this.label6.Text = "Processor (CPU) ID";
      this.label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = System.Drawing.Color.White;
      this.label5.Location = new Point(17, 128);
      this.label5.Name = "label5";
      this.label5.Size = new Size(70, 16);
      this.label5.TabIndex = 54;
      this.label5.Text = "MOBO ID";
      this.label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = System.Drawing.Color.White;
      this.label4.Location = new Point(17, 102);
      this.label4.Name = "label4";
      this.label4.Size = new Size(88, 16);
      this.label4.TabIndex = 53;
      this.label4.Text = "MOBO Man.";
      this.label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = System.Drawing.Color.White;
      this.label3.Location = new Point(17, 155);
      this.label3.Name = "label3";
      this.label3.Size = new Size(94, 16);
      this.label3.TabIndex = 52;
      this.label3.Text = "MOBOModel";
      this.label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new Point(118, 9);
      this.label1.Name = "label1";
      this.label1.Size = new Size(123, 16);
      this.label1.TabIndex = 51;
      this.label1.Text = "Processor (CPU)";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new Size(630, (int) byte.MaxValue);
      this.Controls.Add((Control) this.textBox10);
      this.Controls.Add((Control) this.label10);
      this.Controls.Add((Control) this.textBox9);
      this.Controls.Add((Control) this.label9);
      this.Controls.Add((Control) this.textBox8);
      this.Controls.Add((Control) this.textBox7);
      this.Controls.Add((Control) this.textBox6);
      this.Controls.Add((Control) this.textBox5);
      this.Controls.Add((Control) this.textBox4);
      this.Controls.Add((Control) this.textBox3);
      this.Controls.Add((Control) this.textBox2);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.label8);
      this.Controls.Add((Control) this.label7);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.pictureBox1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (systeminfo);
      this.Text = "reportsform";
      this.Load += new EventHandler(this.systeminfo_Load);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private class MotherBoard
    {
      private string MBserialNo = (string) null;

      public string MBSN
      {
        get => this.MBserialNo;
        set => this.MBserialNo = value;
      }
    }

    private class MotherBoardMan
    {
      private string MBMan = (string) null;

      public string MBMa
      {
        get => this.MBMan;
        set => this.MBMan = value;
      }
    }

    private class MotherBoardModel
    {
      private string MBModel = (string) null;

      public string MBmodel
      {
        get => this.MBModel;
        set => this.MBModel = value;
      }
    }

    private class CPU
    {
      private string CPUserialNo = (string) null;

      public string CPUSN
      {
        get => this.CPUserialNo;
        set => this.CPUserialNo = value;
      }
    }

    private class CPUN
    {
      private string CPUname = (string) null;

      public string CPUNa
      {
        get => this.CPUname;
        set => this.CPUname = value;
      }
    }
  }
}
