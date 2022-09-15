using System;
using System.Reflection;

[assembly: AssemblyDescription("Computing a file entropy")]
[assembly: AssemblyTitle("ent")]
[assembly: AssemblyVersion("1.0.0.0")]

namespace Entropy {
  internal sealed class AssemblyInfo {
    private  Type a;
    internal AssemblyInfo() { a = typeof(Program); }

    internal String Description {
      get {
        return ((AssemblyDescriptionAttribute)Attribute
          .GetCustomAttribute(a.Assembly, typeof(AssemblyDescriptionAttribute))
        ).Description;
      }
    }

    internal String Title {
      get {
        return ((AssemblyTitleAttribute)Attribute
          .GetCustomAttribute(a.Assembly, typeof(AssemblyTitleAttribute))
        ).Title;
      }
    }

    internal String Version {
      get { return a.Assembly.GetName().Version.ToString(2); }
    }
  } // AssemblyInfo
}
