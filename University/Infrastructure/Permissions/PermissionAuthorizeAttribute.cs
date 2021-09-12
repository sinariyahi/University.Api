using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Infrastructure.Permissions
{
    public class PermissionAuthorizeAttribute : AuthorizeAttribute
    {
        internal const string PolicyPrefix = "PERMISSION:";
        public PermissionAuthorizeAttribute(params string[] permissions)
        {
            Policy = $"{PolicyPrefix}{string.Join(",", permissions)}";
        }
    }
}