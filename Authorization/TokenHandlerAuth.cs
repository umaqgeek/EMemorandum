using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using EMemorandum.Models;

namespace EMemorandum.Authorization
{
    public class TokenHandlerAuth : AuthorizationHandler<TokenRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DbContext_EMO _context;

        public TokenHandlerAuth(IHttpContextAccessor httpContextAccessor, DbContext_EMO context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, TokenRequirement requirement)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var Bearer = "Bearer ";

            if (httpContext != null)
            {
                var authHeader = httpContext.Request.Headers["Authorization"].FirstOrDefault();
                if (authHeader != null && authHeader.StartsWith(Bearer))
                {
                    var token = authHeader.Substring(Bearer.Length).Trim();

                    // Check if the token exists in the database
                    var user = await _context.EMO_Staf.FirstOrDefaultAsync(s => s.NoStaf == token);

                    if (user != null)
                    {
                        httpContext.Session.SetString("ssusrid", token);

                        List<EMO_Roles> roles = null;

                        if (requirement.RequiredRoles != null && requirement.RequiredRoles.Any())
                        {
                            roles = await _context.EMO_Roles
                                .Where(r => r.NoStaf == token && requirement.RequiredRoles.Contains(r.Role))
                                .ToListAsync();
                        }

                        // Log the roles
                        if (roles != null)
                        {
                            Console.WriteLine("Roles:");
                            foreach (var role in roles)
                            {
                                Console.WriteLine($"- {role.Role}");
                            }
                        }

                        // Log required roles
                        if (requirement.RequiredRoles != null)
                        {
                            Console.WriteLine("Required Roles:");
                            foreach (var requiredRole in requirement.RequiredRoles)
                            {
                                Console.WriteLine($"- {requiredRole}");
                            }
                        }

                        // Role check
                        if (requirement.RequiredRoles == null || !requirement.RequiredRoles.Any() || (roles != null && roles.Any()))
                        {
                            context.Succeed(requirement);
                            return;
                        }
                    }
                }
            }

            context.Fail();
        }
    }
}
