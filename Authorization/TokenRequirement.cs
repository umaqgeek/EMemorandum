using Microsoft.AspNetCore.Authorization;

namespace EMemorandum.Authorization
{
    public class TokenRequirement : IAuthorizationRequirement
    {
        public string RequiredRole { get; }

        public TokenRequirement(string requiredRole)
        {
            RequiredRole = requiredRole;
        }
    }
}
