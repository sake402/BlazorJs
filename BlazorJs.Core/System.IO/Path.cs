using System;
using System.Collections.Generic;
using System.Text;

namespace System.IO
{
    public static partial class Path
    {
        public static string GetExtension(string name)
        {
            var dot = name.LastIndexOf('.');
            if (dot >= 0)
                return name.Substring(dot);
            return "";
        }
    }
}
