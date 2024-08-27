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
        private readonly ApplicationDbContext _context;

        public TokenHandlerAuth(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, TokenRequirement requirement)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext != null)
            {
                var authHeader = httpContext.Request.Headers["Authorization"].FirstOrDefault();
                if (authHeader != null && authHeader.StartsWith("Bearer "))
                {
                    var token = authHeader.Substring("Bearer ".Length).Trim();

                    // Check if the token exists in the database
                    var user = await _context.EMO_Staf.FirstOrDefaultAsync(s => s.NoStaf == token);

                    if (user != null)
                    {
                        var roles = await _context.EMO_Roles
                            .Where(r => r.NoStaf == token && r.Role == requirement.RequiredRole)
                            .FirstOrDefaultAsync();

                        // Role check
                        if (string.IsNullOrEmpty(requirement.RequiredRole) || roles != null)
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
