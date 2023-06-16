using System;
using System.Reflection;

[assembly: AssemblyDescription("Computing a file entropy")]

namespace Entropy {
  internal sealed class AssemblyInfo {
    private Type a;
    internal AssemblyInfo() { a = typeof(Program); }

    internal string Description {
      get {
        return ((AssemblyDescriptionAttribute)Attribute
          .GetCustomAttribute(a.Assembly, typeof(AssemblyDescriptionAttribute))
        ).Description;
      }
    }

    internal string Title {
      get {
        return ((AssemblyTitleAttribute)Attribute
          .GetCustomAttribute(a.Assembly, typeof(AssemblyTitleAttribute))
        ).Title;
      }
    }

    internal string Version {
      get { return a.Assembly.GetName().Version.ToString(2); }
    }
  }
}
