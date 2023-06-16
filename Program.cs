using System;
using System.IO;
using System.Globalization;

namespace Entropy {
  internal sealed class Program {
    static unsafe double Entropy(byte[] buf) {
      int* rgi = stackalloc int[0x100], pi = rgi + 0x100;
      double ent = 0.0, src = buf.Length;

      for (int i = buf.Length; --i >= 0;) rgi[buf[i]]++;
      while (--pi >= rgi) {
        if (*pi > 0) ent += *pi * Math.Log(*pi / src, 2.0);
      }

      return -ent / src;
    }

    static string StrMsg(string msg, params Object[] list) {
      return String.Format(CultureInfo.InvariantCulture, msg, list);
    }

    static void Main(String[] args) {
      if (1 != args.Length) {
        AssemblyInfo ai = new AssemblyInfo();
        Console.WriteLine(StrMsg("{0} v{1} - {2}\nUsage: {3} <file>",
                    ai.Title, ai.Version, ai.Description, ai.Title));
        return;
      }

      try {
        string file = Path.GetFullPath(args[0]);
        Console.WriteLine(StrMsg("{0} *{1}",
             Math.Round(Entropy(File.ReadAllBytes(file)), 3), file));
      }
      catch (Exception e) {
        Console.WriteLine(StrMsg("{0}", e.Message));
      }
    }
  }
}
