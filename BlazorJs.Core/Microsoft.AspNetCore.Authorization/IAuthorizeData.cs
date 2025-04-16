using System;
using System.Collections.Generic;
using System.Text;

namespace  Microsoft.AspNetCore.Authorization
{    
    //
    // Summary:
    //     Defines the set of data required to apply authorization rules to a resource.
    public partial interface IAuthorizeData
    {
        //
        // Summary:
        //     Gets or sets the policy name that determines access to the resource.
        string Policy { get; set; }
        //
        // Summary:
        //     Gets or sets a comma delimited list of roles that are allowed to access the resource.
        string Roles { get; set; }
        //
        // Summary:
        //     Gets or sets a comma delimited list of schemes from which user information is
        //     constructed.
        string AuthenticationSchemes { get; set; }
    }
}
