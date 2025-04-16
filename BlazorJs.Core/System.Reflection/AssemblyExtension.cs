using H5;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace System.Reflection
{
    public static class AssemblyExtension
    {
        [ObjectLiteral]
        public class AssemblyName { public string Name { get; set; } }
        public static AssemblyName GetName(this Assembly assembly)
        {
            return new AssemblyName { Name = assembly.FullName };
        }

        public static Stream GetManifestResourceStream(this Assembly assembly, string name)
        {
            return Stream.Null;
        }
    }
}
