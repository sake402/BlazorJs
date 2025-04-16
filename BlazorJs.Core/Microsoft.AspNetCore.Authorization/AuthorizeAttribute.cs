using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.AspNetCore.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public partial class AuthorizeAttribute : Attribute, IAuthorizeData
    {
        public string Policy { get; set; }
        public string Roles { get; set; }
        public string AuthenticationSchemes { get; set; }
        public AuthorizeAttribute(string policy)
        {
            Policy = policy;
        }

        public AuthorizeAttribute()
        {
        }
    }
}
