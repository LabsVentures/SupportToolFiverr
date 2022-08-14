// Decompiled with JetBrains decompiler
// Type: SupportTool.Properties.Resources
// Assembly: Support Tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7C2F509-6BDB-4CAE-AB6E-4A5371C4CE0D
// Assembly location: C:\Users\ethan\OneDrive\Desktop\Support_Tool.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace SupportTool.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (SupportTool.Properties.Resources.resourceMan == null)
          SupportTool.Properties.Resources.resourceMan = new ResourceManager("SupportTool.Properties.Resources", typeof (SupportTool.Properties.Resources).Assembly);
        return SupportTool.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => SupportTool.Properties.Resources.resourceCulture;
      set => SupportTool.Properties.Resources.resourceCulture = value;
    }
  }
}
