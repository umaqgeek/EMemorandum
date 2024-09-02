using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace EMemorandum.Authorization
{
    public class TokenRequirement : IAuthorizationRequirement
    {
        public IEnumerable<string> RequiredRoles { get; }

        public TokenRequirement(IEnumerable<string> requiredRoles)
        {
            RequiredRoles = requiredRoles;
        }
    }
}
