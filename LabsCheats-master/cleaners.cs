// Decompiled with JetBrains decompiler
// Type: lmitp.cleaners
// Assembly: Support Tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7C2F509-6BDB-4CAE-AB6E-4A5371C4CE0D
// Assembly location: C:\Users\ethan\OneDrive\Desktop\Support_Tool.exe

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace lmitp
{
  public class cleaners : Form
  {
    public List<string> folderPaths = new List<string>();
    private List<string> FilePaths = new List<string>();
    private List<string> HKLM = new List<string>();
    private List<string> HKCU = new List<string>();
    private string report;
    private IContainer components = (IContainer) null;
    private Button button3;
    private Button button4;
    private Button button5;
    private PictureBox pictureBox1;
    private Button button1;

    public cleaners() => this.InitializeComponent();

    private void AddRegistryKeyPath(string key)
    {
      if (key.Contains("HKEY_LOCAL_MACHINE\\"))
      {
        this.HKLM.Add(key.Replace("HKEY_LOCAL_MACHINE\\", ""));
      }
      else
      {
        if (!key.Contains("HKEY_CURRENT_USER\\"))
          return;
        this.HKCU.Add(key.Replace("HKEY_CURRENT_USER\\", ""));
      }
    }

    private void DeleteRegistryValue(string keyName, string value)
    {
      if (keyName.Contains("HKEY_LOCAL_MACHINE\\"))
      {
        keyName = keyName.Replace("HKEY_LOCAL_MACHINE\\", "");
        RegistryKey registryKey1;
        using (registryKey1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(keyName, true))
        {
          if (registryKey1 != null)
          {
            try
            {
              registryKey1.DeleteValue(value, true);
              this.report = this.report + "Deleted 32 bitReg Value \"" + value + "\" From key \"" + keyName + "\"\r\n";
            }
            catch (Exception ex)
            {
              this.report = this.report + "Error: 32 bit Reg Value not found: Value \"" + value + "\" From key \"" + keyName + "\"\r\n";
            }
          }
          else
            this.report = this.report + "Error: 32 bit Reg Value \"" + value + "\" Key not found \"" + keyName + "\"\r\n";
        }
        RegistryKey registryKey2;
        using (registryKey2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(keyName, true))
        {
          if (registryKey2 != null)
          {
            try
            {
              registryKey2.DeleteValue(value, true);
              this.report = this.report + "Deleted 64 bit Reg Value \"" + value + "\" From key \"" + keyName + "\"\r\n";
            }
            catch (Exception ex)
            {
              this.report = this.report + "Error: 64 bit Reg Value not found: Value \"" + value + "\" From key \"" + keyName + "\"\r\n";
            }
          }
          else
            this.report = this.report + "Error: 64 bit Reg Value \"" + value + "\" Key not found \"" + keyName + "\"\r\n";
        }
      }
      else
      {
        if (!keyName.Contains("HKEY_CURRENT_USER\\"))
          return;
        keyName = keyName.Replace("HKEY_CURRENT_USER\\", "");
        RegistryKey registryKey3;
        using (registryKey3 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32).OpenSubKey(keyName, true))
        {
          if (registryKey3 != null)
          {
            try
            {
              registryKey3.DeleteValue(value, true);
              this.report = this.report + "Deleted 32 bit Reg Value \"" + value + "\" From key \"" + keyName + "\"\r\n";
            }
            catch (Exception ex)
            {
              this.report = this.report + "Error: 32 bit Reg Value not found: Value \"" + value + "\" From key \"" + keyName + "\"\r\n";
            }
          }
          else
            this.report = this.report + "Error: 32 bit Reg Value \"" + value + "\" Key not found \"" + keyName + "\"\r\n";
        }
        RegistryKey registryKey4;
        using (registryKey4 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey(keyName, true))
        {
          if (registryKey4 != null)
          {
            try
            {
              registryKey4.DeleteValue(value, true);
              this.report = this.report + "Deleted 64 bit Reg Value \"" + value + "\" From key \"" + keyName + "\"\r\n";
            }
            catch (Exception ex)
            {
              this.report = this.report + "Error: 64 bit Reg Value not found: Value \"" + value + "\" From key \"" + keyName + "\"\r\n";
            }
          }
          else
            this.report = this.report + "Error: 64 bit Reg Value \"" + value + "\" Key not found \"" + keyName + "\"\r\n";
        }
      }
    }

    private void button3_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("The following BSG & EFT items will be deleted:" + Environment.NewLine + Environment.NewLine + "Registry Keys | Firewall Rules" + Environment.NewLine + "Temp Folders | Related Files" + Environment.NewLine + Environment.NewLine + "Do you wish to continue?", "EFT Trace Cleaning", MessageBoxButtons.YesNo) != DialogResult.Yes)
        return;
      this.AddRegistryKeyPath("HKEY_CURRENT_USER\\SOFTWARE\\Battlestate Games");
      this.AddRegistryKeyPath("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\UFH\\SHC");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\EscapeFromTarkov");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\{B0FDA062-7581-4D67-B085-C4E7C358037F}_is1");
      this.AddRegistryKeyPath("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Internet Explorer\\LowRegistry\\Audio\\PolicyConfig\\PropertyStore\\3d36c215_0");
      this.AddRegistryKeyPath("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\microphone\\NonPackaged\\C:#Battlestate Games#EFT#EscapeFromTarkov.exe");
      this.AddRegistryKeyPath("HKEY_CURRENT_USER\\System\\GameConfigStore\\Children\\0d4d4a9b-12c0-4fa8-ac36-2331fef9a4fb");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\SharedAccess\\Parameters\\FirewallPolicy\\FirewallRules");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\RADAR\\HeapLeakDetection\\DiagnosedApplications\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "A:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "A:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "A:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "A:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "A:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "A:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "A:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "A:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "A:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "A:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "A:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "A:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "A:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "B:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "B:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "B:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "B:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "B:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "B:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "B:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "B:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "B:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "B:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "B:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "B:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "B:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "C:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "C:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "C:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "C:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "C:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "C:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "C:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "C:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "C:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "C:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "C:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "C:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "C:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "D:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "D:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "D:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "D:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "D:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "D:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "D:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "D:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "D:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "D:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "D:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "D:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "D:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "E:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "E:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "E:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "E:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "E:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "E:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "E:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "E:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "E:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "E:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "E:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "E:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "E:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "F:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "F:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "F:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "F:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "F:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "F:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "F:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "F:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "F:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "F:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "F:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "F:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "F:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "G:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "G:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "G:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "G:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "G:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "G:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "G:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "G:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "G:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "G:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "G:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "G:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "G:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "H:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "H:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "H:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "H:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "H:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "H:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "H:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "H:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "H:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "H:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "H:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "H:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "H:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "I:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "I:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "I:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "I:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "I:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "I:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "I:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "I:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "I:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "I:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "I:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "I:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "I:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "J:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "J:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "J:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "J:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "J:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "J:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "J:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "J:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "J:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "J:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "J:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "J:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "J:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "K:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "K:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "K:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "K:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "K:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "K:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "K:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "K:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "K:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "K:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "K:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "K:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "K:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "L:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "L:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "L:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "L:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "L:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "L:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "L:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "L:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "L:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "L:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "L:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "L:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "L:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "M:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "M:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "M:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "M:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "M:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "M:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "M:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "M:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "M:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "M:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "M:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "M:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "M:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "N:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "N:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "N:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "N:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "N:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "N:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "N:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "N:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "N:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "N:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "N:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "N:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "N:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "O:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "O:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "O:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "O:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "O:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "O:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "O:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "O:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "O:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "O:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "O:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "O:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "O:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "P:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "P:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "P:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "P:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "P:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "P:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "P:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "P:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "P:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "P:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "P:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "P:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "P:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "Q:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "Q:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "Q:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "Q:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "Q:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "Q:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "Q:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "Q:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "Q:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "Q:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "Q:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "Q:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "Q:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "R:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "R:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "R:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "R:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "R:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "R:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "R:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "R:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "R:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "R:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "R:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "R:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "R:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "S:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "S:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "S:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "S:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "S:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "S:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "S:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "S:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "S:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "S:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "S:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "S:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "S:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "T:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "T:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "T:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "T:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "T:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "T:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "T:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "T:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "T:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "T:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "T:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "T:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "T:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "U:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "U:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "U:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "U:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "U:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "U:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "U:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "U:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "U:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "U:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "U:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "U:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "U:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "V:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "V:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "V:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "V:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "V:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "V:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "V:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "V:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "V:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "V:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "V:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "V:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "V:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "W:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "W:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "W:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "W:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "W:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "W:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "W:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "W:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "W:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "W:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "W:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "W:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "W:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "X:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "X:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "X:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "X:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "X:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "X:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "X:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "X:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "X:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "X:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "X:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "X:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "X:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "Y:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "Y:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "Y:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "Y:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "Y:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "Y:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "Y:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "Y:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "Y:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "Y:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "Y:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "Y:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "Y:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "Z:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "Z:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.ApplicationCompany");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "Z:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", "Z:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe.FriendlyAppName");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "Z:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "Z:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "Z:\\Battlestate Games\\EFT\\UnityCrashHandler64.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "Z:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", "Z:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "Z:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", "Z:\\Battlestate Games\\EFT\\EscapeFromTarkov.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppBadgeUpdated", "Z:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppLaunch", "Z:\\Battlestate Games\\BsgLauncher\\BsgLauncher.exe");
      this.folderPaths.Add("%localappdata%\\Battlestate Games");
      this.folderPaths.Add("%allusersprofile%\\Battlestate Games");
      this.folderPaths.Add("%appdata%\\..\\LocalLow\\Battlestate Games");
      this.folderPaths.Add("%appdata%\\Battlestate Games");
      this.folderPaths.Add("%temp%\\");
      this.folderPaths.Add("%appdata%\\..\\..\\Documents\\Escape from Tarkov");
      this.folderPaths.Add("%localappdata%\\NVIDIA\\NvBackend\\VisualOPSData\\escape_from_tarkov");
      this.folderPaths.Add("%localappdata%\\NVIDIA\\NvBackend\\ApplicationOntology\\data\\wrappers\\escape_from_tarkov");
      this.folderPaths.Add("A:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("B:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("C:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("D:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("E:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("F:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("G:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("H:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("I:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("J:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("K:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("L:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("M:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("N:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("O:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("P:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("Q:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("R:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("S:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("T:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("U:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("V:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("W:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("X:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("Y:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("Z:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("A:\\Battlestate Games");
      this.folderPaths.Add("B:\\Battlestate Games");
      this.folderPaths.Add("C:\\Battlestate Games");
      this.folderPaths.Add("D:\\Battlestate Games");
      this.folderPaths.Add("E:\\Battlestate Games");
      this.folderPaths.Add("F:\\Battlestate Games");
      this.folderPaths.Add("G:\\Battlestate Games");
      this.folderPaths.Add("H:\\Battlestate Games");
      this.folderPaths.Add("I:\\Battlestate Games");
      this.folderPaths.Add("J:\\Battlestate Games");
      this.folderPaths.Add("K:\\Battlestate Games");
      this.folderPaths.Add("L:\\Battlestate Games");
      this.folderPaths.Add("M:\\Battlestate Games");
      this.folderPaths.Add("N:\\Battlestate Games");
      this.folderPaths.Add("O:\\Battlestate Games");
      this.folderPaths.Add("P:\\Battlestate Games");
      this.folderPaths.Add("Q:\\Battlestate Games");
      this.folderPaths.Add("R:\\Battlestate Games");
      this.folderPaths.Add("S:\\Battlestate Games");
      this.folderPaths.Add("T:\\Battlestate Games");
      this.folderPaths.Add("U:\\Battlestate Games");
      this.folderPaths.Add("V:\\Battlestate Games");
      this.folderPaths.Add("W:\\Battlestate Games");
      this.folderPaths.Add("X:\\Battlestate Games");
      this.folderPaths.Add("Y:\\Battlestate Games");
      this.folderPaths.Add("Z:\\Battlestate Games");
      this.FilePaths.Add("%ProgramData%\\BSGLAUNCHER.EXE-90C71811.pf");
      RegistryKey registryKey1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
      foreach (string subkey in this.HKLM)
      {
        try
        {
          registryKey1.DeleteSubKeyTree(subkey, true);
          this.report = this.report + "DELETED 32bit: " + subkey + "\r\n";
        }
        catch (Exception ex)
        {
          this.report = this.report + "NOT FOUND 32bit: " + subkey + "\r\n";
        }
      }
      registryKey1.Close();
      RegistryKey registryKey2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
      foreach (string subkey in this.HKLM)
      {
        try
        {
          registryKey2.DeleteSubKeyTree(subkey, true);
          this.report = this.report + "DELETED 64bit: " + subkey + "\r\n";
        }
        catch (Exception ex)
        {
          this.report = this.report + "NOT FOUND 64bit: " + subkey + "\r\n";
        }
      }
      registryKey2.Close();
      RegistryKey registryKey3 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32);
      foreach (string subkey in this.HKCU)
      {
        try
        {
          registryKey3.DeleteSubKeyTree(subkey, true);
          this.report = this.report + "DELETED 32bit: " + subkey + "\r\n";
        }
        catch (Exception ex)
        {
          this.report = this.report + "NOT FOUND 32bit: " + subkey + "\r\n";
        }
      }
      registryKey3.Close();
      RegistryKey registryKey4 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
      foreach (string subkey in this.HKCU)
      {
        try
        {
          registryKey4.DeleteSubKeyTree(subkey, true);
          this.report = this.report + "DELETED 64bit: " + subkey + "\r\n";
        }
        catch (Exception ex)
        {
          this.report = this.report + "NOT FOUND 64bit: " + subkey + "\r\n";
        }
      }
      registryKey4.Close();
      foreach (string folderPath in this.folderPaths)
      {
        string path = Environment.ExpandEnvironmentVariables(folderPath);
        try
        {
          Directory.Delete(path, true);
          this.report = this.report + "DELETED: " + folderPath + "\r\n";
        }
        catch (Exception ex)
        {
          this.report = this.report + "File not found: " + folderPath + "\r\n";
        }
      }
      foreach (string filePath in this.FilePaths)
      {
        string path = Environment.ExpandEnvironmentVariables(filePath);
        try
        {
          File.Delete(path);
          this.report = this.report + "DELETED: " + filePath + "\r\n";
        }
        catch (Exception ex)
        {
          this.report = this.report + "File not found: " + filePath + "\r\n";
        }
      }
      int num = (int) MessageBox.Show("EFT Traces have been cleaned succesfully.");
    }

    private void button4_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("The following FN & EPIC GAMES Loader items will be deleted:" + Environment.NewLine + Environment.NewLine + "Registry Keys | Firewall Rules" + Environment.NewLine + "Temp Folders | Related Files" + Environment.NewLine + Environment.NewLine + "Please keep in mind that fortnite cleaners may or may not work and a windows reinstall may be needed" + Environment.NewLine + Environment.NewLine + "Do you wish to continue?", "FORTNITE Trace Cleaning", MessageBoxButtons.YesNo) != DialogResult.Yes)
        return;
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\SharedAccess\\Parameters\\FirewallPolicy\\FirewallRules");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\SharedAccess\\Parameters\\FirewallPolicy\\FirewallRules");
      this.AddRegistryKeyPath("HKEY_CLASSES_ROOT\\com.epicgames.eos");
      this.AddRegistryKeyPath("HKEY_CLASSES_ROOT\\com.epicgames.launcher");
      this.AddRegistryKeyPath("HKEY_CLASSES_ROOT\\discord-432980957394370572");
      this.AddRegistryKeyPath("HKEY_CLASSES_ROOT\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache");
      this.AddRegistryKeyPath("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\discord-432980957394370572");
      this.AddRegistryKeyPath("HKEY_CURRENT_USER\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache");
      this.AddRegistryKeyPath("HKEY_CURRENT_USER\\SOFTWARE\\Epic Games");
      this.AddRegistryKeyPath("HKEY_CURRENT_USER\\SOFTWARE\\Khronos");
      this.AddRegistryKeyPath("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Internet Explorer\\LowRegistry\\Audio\\PolicyConfig\\PropertyStore\\3b4d4ffc_0");
      this.AddRegistryKeyPath("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Internet Explorer\\LowRegistry\\Audio\\PolicyConfig\\PropertyStore\\67d5a7a_0");
      this.AddRegistryKeyPath("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Internet Explorer\\LowRegistry\\Audio\\PolicyConfig\\PropertyStore\\bae50c11_0");
      this.AddRegistryKeyPath("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\TypedPaths");
      this.AddRegistryKeyPath("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\UFH\\SHC");
      this.AddRegistryKeyPath("HKEY_CURRENT_USER\\System\\GameConfigStore\\Children\\6ad0a2e2-de70-4a5a-8a18-8d7320e5de2a");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SOFTWARE\\Classes\\com.epicgames.eos");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SOFTWARE\\Classes\\com.epicgames.launcher");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SOFTWARE\\Classes\\Installer\\Dependencies\\{F9C5C994-F6B9-4D75-B3E7-AD01B84073E9}");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SOFTWARE\\Classes\\Installer\\Products\\2D248857835180048A3E666FA560C125");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SOFTWARE\\Classes\\Installer\\Products\\72974CAFA6A1E6C4DAD79E5776494ACB");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SOFTWARE\\Classes\\Installer\\Features\\72974CAFA6A1E6C4DAD79E5776494ACB");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SOFTWARE\\Epic Games");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SOFTWARE\\EpicGames");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\{758842D2-1538-4008-A8E3-66F65A061C52}");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\{FAC47927-1A6A-4C6E-AD7D-E9756794A4BC}");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\bam\\State\\UserSettings\\S-1-5-21-839780351-3931343707-951711088-1001");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\EpicOnlineServices");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\EpicOnlineServices");
      this.AddRegistryKeyPath("HKEY_USERS\\S-1-5-21-839780351-3931343707-951711088-1001\\SOFTWARE\\Classes\\discord-432980957394370572");
      this.AddRegistryKeyPath("HKEY_USERS\\S-1-5-21-839780351-3931343707-951711088-1001\\SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache");
      this.AddRegistryKeyPath("HKEY_USERS\\S-1-5-21-839780351-3931343707-951711088-1001\\SOFTWARE\\Khronos");
      this.AddRegistryKeyPath("HKEY_USERS\\S-1-5-21-839780351-3931343707-951711088-1001\\SOFTWARE\\Microsoft\\Internet Explorer\\LowRegistry\\Audio\\PolicyConfig\\PropertyStore\\3b4d4ffc_0");
      this.AddRegistryKeyPath("HKEY_USERS\\S-1-5-21-839780351-3931343707-951711088-1001\\SOFTWARE\\Microsoft\\Internet Explorer\\LowRegistry\\Audio\\PolicyConfig\\PropertyStore\\67d5a7a_0");
      this.AddRegistryKeyPath("HKEY_USERS\\S-1-5-21-839780351-3931343707-951711088-1001\\SOFTWARE\\Microsoft\\Internet Explorer\\LowRegistry\\Audio\\PolicyConfig\\PropertyStore\\bae50c11_0");
      this.AddRegistryKeyPath("HKEY_USERS\\S-1-5-21-839780351-3931343707-951711088-1001\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched");
      this.AddRegistryKeyPath("HKEY_USERS\\S-1-5-21-839780351-3931343707-951711088-1001\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\UFH\\SHC");
      this.AddRegistryKeyPath("HKEY_USERS\\S-1-5-21-839780351-3931343707-951711088-1001\\System\\GameConfigStore\\Children\\6ad0a2e2-de70-4a5a-8a18-8d7320e5de2a");
      this.AddRegistryKeyPath("HKEY_USERS\\S-1-5-21-839780351-3931343707-951711088-1001_Classes\\discord-432980957394370572");
      this.AddRegistryKeyPath("HKEY_USERS\\S-1-5-21-839780351-3931343707-951711088-1001_Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SOFTWARE\\Classes\\Installer\\UpgradeCodes\\44F9670D954DF0540B48AC3E08267CB5");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\.NETFramework\\NGenQueue\\WIN32\\PersistedPriorities");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Installer\\UpgradeCodes\\44F9670D954DF0540B48AC3E08267CB5");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Installer\\UserData\\S-1-5-18\\Products\\72974CAFA6A1E6C4DAD79E5776494ACB");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\.NETFramework\\NGenQueue\\WIN32");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SOFTWARE\\EasyAntiCheat");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\EasyAntiCheat");
      this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\EasyAntiCheat");
      this.DeleteRegistryValue("HKEY_USERS\\S-1-5-21-839780351-3931343707-951711088-1001\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "EpicGamesLauncher");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "EpicGamesLauncher");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched", "{7C5A40EF-A0FB-4BFC-874A-C0F2E0B9FA8E}\\Epic Games\\Launcher\\Portal\\Binaries\\Win64\\EpicGamesLauncher.exe");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\StartupApproved\\Run", "EpicGamesLauncher");
      this.DeleteRegistryValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ApplicationAssociationToasts", "com.epicgames.launcher_com.epicgames.launcher");
      this.DeleteRegistryValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall", "{FAC47927-1A6A-4C6E-AD7D-E9756794A4BC}");
      this.DeleteRegistryValue("HKEY_CLASSES_ROOT\\Installer\\Dependencies", "{F9C5C994-F6B9-4D75-B3E7-AD01B84073E9}");
      this.DeleteRegistryValue("HKEY_CLASSES_ROOT\\Installer\\Products", "2D248857835180048A3E666FA560C125");
      this.DeleteRegistryValue("HKEY_CLASSES_ROOT\\Installer\\Products", "72974CAFA6A1E6C4DAD79E5776494ACB");
      this.folderPaths.Add("%temp%\\");
      this.folderPaths.Add("%localappdata%\\Epic Games");
      this.folderPaths.Add("%localappdata%\\EpicGamesLauncher");
      this.folderPaths.Add("A:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("B:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("C:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("D:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("E:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("F:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("G:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("H:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("I:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("J:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("K:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("L:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("M:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("N:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("O:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("P:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("Q:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("R:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("S:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("T:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("U:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("V:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("W:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("X:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("Y:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("Z:\\WINDOWS\\Prefetch");
      this.folderPaths.Add("A:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("B:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("C:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("D:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("E:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("F:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("G:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("H:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("I:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("J:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("K:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("L:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("M:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("N:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("O:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("P:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("Q:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("R:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("S:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("T:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("U:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("V:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("W:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("X:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("Y:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("Z:\\Program Files (x86)\\Epic Games");
      this.folderPaths.Add("A:\\Program Files\\Epic Games");
      this.folderPaths.Add("B:\\Program Files\\Epic Games");
      this.folderPaths.Add("C:\\Program Files\\Epic Games");
      this.folderPaths.Add("D:\\Program Files\\Epic Games");
      this.folderPaths.Add("E:\\Program Files\\Epic Games");
      this.folderPaths.Add("F:\\Program Files\\Epic Games");
      this.folderPaths.Add("G:\\Program Files\\Epic Games");
      this.folderPaths.Add("H:\\Program Files\\Epic Games");
      this.folderPaths.Add("I:\\Program Files\\Epic Games");
      this.folderPaths.Add("J:\\Program Files\\Epic Games");
      this.folderPaths.Add("K:\\Program Files\\Epic Games");
      this.folderPaths.Add("L:\\Program Files\\Epic Games");
      this.folderPaths.Add("M:\\Program Files\\Epic Games");
      this.folderPaths.Add("N:\\Program Files\\Epic Games");
      this.folderPaths.Add("O:\\Program Files\\Epic Games");
      this.folderPaths.Add("P:\\Program Files\\Epic Games");
      this.folderPaths.Add("Q:\\Program Files\\Epic Games");
      this.folderPaths.Add("R:\\Program Files\\Epic Games");
      this.folderPaths.Add("S:\\Program Files\\Epic Games");
      this.folderPaths.Add("T:\\Program Files\\Epic Games");
      this.folderPaths.Add("U:\\Program Files\\Epic Games");
      this.folderPaths.Add("V:\\Program Files\\Epic Games");
      this.folderPaths.Add("W:\\Program Files\\Epic Games");
      this.folderPaths.Add("X:\\Program Files\\Epic Games");
      this.folderPaths.Add("Y:\\Program Files\\Epic Games");
      this.folderPaths.Add("Z:\\Program Files\\Epic Games");
      this.folderPaths.Add("A:\\ProgramData\\Epic");
      this.folderPaths.Add("B:\\ProgramData\\Epic");
      this.folderPaths.Add("C:\\ProgramData\\Epic");
      this.folderPaths.Add("D:\\ProgramData\\Epic");
      this.folderPaths.Add("E:\\ProgramData\\Epic");
      this.folderPaths.Add("F:\\ProgramData\\Epic");
      this.folderPaths.Add("G:\\ProgramData\\Epic");
      this.folderPaths.Add("H:\\ProgramData\\Epic");
      this.folderPaths.Add("I:\\ProgramData\\Epic");
      this.folderPaths.Add("J:\\ProgramData\\Epic");
      this.folderPaths.Add("K:\\ProgramData\\Epic");
      this.folderPaths.Add("L:\\ProgramData\\Epic");
      this.folderPaths.Add("M:\\ProgramData\\Epic");
      this.folderPaths.Add("N:\\ProgramData\\Epic");
      this.folderPaths.Add("O:\\ProgramData\\Epic");
      this.folderPaths.Add("P:\\ProgramData\\Epic");
      this.folderPaths.Add("Q:\\ProgramData\\Epic");
      this.folderPaths.Add("R:\\ProgramData\\Epic");
      this.folderPaths.Add("S:\\ProgramData\\Epic");
      this.folderPaths.Add("T:\\ProgramData\\Epic");
      this.folderPaths.Add("U:\\ProgramData\\Epic");
      this.folderPaths.Add("V:\\ProgramData\\Epic");
      this.folderPaths.Add("W:\\ProgramData\\Epic");
      this.folderPaths.Add("X:\\ProgramData\\Epic");
      this.folderPaths.Add("Y:\\ProgramData\\Epic");
      this.folderPaths.Add("Z:\\ProgramData\\Epic");
      RegistryKey registryKey1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
      foreach (string subkey in this.HKLM)
      {
        try
        {
          registryKey1.DeleteSubKeyTree(subkey, true);
          this.report = this.report + "DELETED 32bit: " + subkey + "\r\n";
        }
        catch (Exception ex)
        {
          this.report = this.report + "NOT FOUND 32bit: " + subkey + "\r\n";
        }
      }
      registryKey1.Close();
      RegistryKey registryKey2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
      foreach (string subkey in this.HKLM)
      {
        try
        {
          registryKey2.DeleteSubKeyTree(subkey, true);
          this.report = this.report + "DELETED 64bit: " + subkey + "\r\n";
        }
        catch (Exception ex)
        {
          this.report = this.report + "NOT FOUND 64bit: " + subkey + "\r\n";
        }
      }
      registryKey2.Close();
      RegistryKey registryKey3 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32);
      foreach (string subkey in this.HKCU)
      {
        try
        {
          registryKey3.DeleteSubKeyTree(subkey, true);
          this.report = this.report + "DELETED 32bit: " + subkey + "\r\n";
        }
        catch (Exception ex)
        {
          this.report = this.report + "NOT FOUND 32bit: " + subkey + "\r\n";
        }
      }
      registryKey3.Close();
      RegistryKey registryKey4 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
      foreach (string subkey in this.HKCU)
      {
        try
        {
          registryKey4.DeleteSubKeyTree(subkey, true);
          this.report = this.report + "DELETED 64bit: " + subkey + "\r\n";
        }
        catch (Exception ex)
        {
          this.report = this.report + "NOT FOUND 64bit: " + subkey + "\r\n";
        }
      }
      registryKey4.Close();
      foreach (string folderPath in this.folderPaths)
      {
        string path = Environment.ExpandEnvironmentVariables(folderPath);
        try
        {
          Directory.Delete(path, true);
          this.report = this.report + "DELETED: " + folderPath + "\r\n";
        }
        catch (Exception ex)
        {
          this.report = this.report + "File not found: " + folderPath + "\r\n";
        }
      }
      foreach (string filePath in this.FilePaths)
      {
        string path = Environment.ExpandEnvironmentVariables(filePath);
        try
        {
          File.Delete(path);
          this.report = this.report + "DELETED: " + filePath + "\r\n";
        }
        catch (Exception ex)
        {
          this.report = this.report + "File not found: " + filePath + "\r\n";
        }
      }
      int num = (int) MessageBox.Show("Completed");
    }

    private void button5_Click(object sender, EventArgs e) => new Process()
    {
      StartInfo = new ProcessStartInfo()
      {
        FileName = "cmd.exe",
        Verb = "runas",
        Arguments = "/K ipconfig /release & ipconfig /flushdns & ipconfig /renew & netsh int ip reset & netsh winsock reset"
      }
    }.Start();

    private void button1_Click(object sender, EventArgs e)
    {
      switch (MessageBox.Show("This will remove LEFTOVER Reg-Key traces for FaceIT" + Environment.NewLine + Environment.NewLine + "Have you Uninstalled FaceIt with Revo First?", "Cleaner", MessageBoxButtons.YesNo))
      {
        case DialogResult.Yes:
          this.AddRegistryKeyPath("HKEY_LOCAL_MACHINE\\SOFTWARE\\Classes\\faceitac");
          int num1 = (int) MessageBox.Show("Removed leftover traces!");
          RegistryKey registryKey1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
          foreach (string subkey in this.HKLM)
          {
            try
            {
              registryKey1.DeleteSubKeyTree(subkey, true);
              this.report = this.report + "DELETED 32bit: " + subkey + "\r\n";
            }
            catch (Exception ex)
            {
              this.report = this.report + "NOT FOUND 32bit: " + subkey + "\r\n";
            }
          }
          registryKey1.Close();
          RegistryKey registryKey2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
          foreach (string subkey in this.HKLM)
          {
            try
            {
              registryKey2.DeleteSubKeyTree(subkey, true);
              this.report = this.report + "DELETED 64bit: " + subkey + "\r\n";
            }
            catch (Exception ex)
            {
              this.report = this.report + "NOT FOUND 64bit: " + subkey + "\r\n";
            }
          }
          registryKey2.Close();
          RegistryKey registryKey3 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32);
          foreach (string subkey in this.HKCU)
          {
            try
            {
              registryKey3.DeleteSubKeyTree(subkey, true);
              this.report = this.report + "DELETED 32bit: " + subkey + "\r\n";
            }
            catch (Exception ex)
            {
              this.report = this.report + "NOT FOUND 32bit: " + subkey + "\r\n";
            }
          }
          registryKey3.Close();
          RegistryKey registryKey4 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
          foreach (string subkey in this.HKCU)
          {
            try
            {
              registryKey4.DeleteSubKeyTree(subkey, true);
              this.report = this.report + "DELETED 64bit: " + subkey + "\r\n";
            }
            catch (Exception ex)
            {
              this.report = this.report + "NOT FOUND 64bit: " + subkey + "\r\n";
            }
          }
          registryKey4.Close();
          foreach (string folderPath in this.folderPaths)
          {
            string path = Environment.ExpandEnvironmentVariables(folderPath);
            try
            {
              Directory.Delete(path, true);
              this.report = this.report + "DELETED: " + folderPath + "\r\n";
            }
            catch (Exception ex)
            {
              this.report = this.report + "File not found: " + folderPath + "\r\n";
            }
          }
          using (List<string>.Enumerator enumerator = this.FilePaths.GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              string current = enumerator.Current;
              string path = Environment.ExpandEnvironmentVariables(current);
              try
              {
                File.Delete(path);
                this.report = this.report + "DELETED: " + current + "\r\n";
              }
              catch (Exception ex)
              {
                this.report = this.report + "File not found: " + current + "\r\n";
              }
            }
            break;
          }
        case DialogResult.No:
          int num2 = (int) MessageBox.Show("Please install Revo Uninstaller and remove FaceIt before returning here.");
          break;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (cleaners));
      this.button3 = new Button();
      this.button4 = new Button();
      this.button5 = new Button();
      this.pictureBox1 = new PictureBox();
      this.button1 = new Button();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      this.button3.FlatStyle = FlatStyle.Flat;
      this.button3.ForeColor = System.Drawing.Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.button3.Location = new Point(12, 12);
      this.button3.Name = "button3";
      this.button3.Size = new Size(150, 30);
      this.button3.TabIndex = 9;
      this.button3.Text = "Escape From Tarkov";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new EventHandler(this.button3_Click);
      this.button4.FlatStyle = FlatStyle.Flat;
      this.button4.ForeColor = System.Drawing.Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.button4.Location = new Point(12, 58);
      this.button4.Name = "button4";
      this.button4.Size = new Size(150, 30);
      this.button4.TabIndex = 10;
      this.button4.Text = "Fortnite";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new EventHandler(this.button4_Click);
      this.button5.FlatStyle = FlatStyle.Flat;
      this.button5.ForeColor = System.Drawing.Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.button5.Location = new Point(12, 104);
      this.button5.Name = "button5";
      this.button5.Size = new Size(150, 30);
      this.button5.TabIndex = 11;
      this.button5.Text = "Network";
      this.button5.UseVisualStyleBackColor = true;
      this.button5.Click += new EventHandler(this.button5_Click);
      this.pictureBox1.Image = (Image) componentResourceManager.GetObject("pictureBox1.Image");
      this.pictureBox1.Location = new Point(490, 105);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(140, 150);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 48;
      this.pictureBox1.TabStop = false;
      this.button1.FlatStyle = FlatStyle.Flat;
      this.button1.ForeColor = System.Drawing.Color.FromArgb((int) byte.MaxValue, 0, 187);
      this.button1.Location = new Point(12, 153);
      this.button1.Name = "button1";
      this.button1.Size = new Size(150, 30);
      this.button1.TabIndex = 49;
      this.button1.Text = "FaceIT";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new Size(630, (int) byte.MaxValue);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.button5);
      this.Controls.Add((Control) this.button4);
      this.Controls.Add((Control) this.button3);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (cleaners);
      this.Text = nameof (cleaners);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
