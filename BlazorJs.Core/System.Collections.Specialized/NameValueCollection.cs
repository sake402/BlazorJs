using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Collections.Specialized
{
    public class NameValueCollection : Dictionary<string, object>
    {
        public string[] AllKeys => base.Keys.ToArray();
        public new string this[string name]
        {
            get => ((Dictionary<string, object>)this)[name]?.ToString();
            set => ((Dictionary<string, object>)this)[name] = value;
        }

        public void Add(string name, string value)
        {
            if (base.TryGetValue(name, out var evalue) && evalue != null)
            {
                value += evalue + ";" + value;
            }
            base.Add(name, value);
        }

        public string[] GetValues(string name)
        {
            if (base.TryGetValue(name, out var evalue))
            {
                return evalue?.ToString().Split(';');
            }
            return null;
        }
    }
}
