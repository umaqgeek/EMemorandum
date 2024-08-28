using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using EMemorandum.Models;

namespace EMemorandum.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminOrPUUPolicy")]
    public class JenisMemoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JenisMemoController(IConfiguration configuration, ApplicationDbContext context)
        {
            _context = context;
        }

        // TODO: Add JenisMemo (Admin, PUU)
        // TODO: Update JenisMemo (Admin, PUU)
        // TODO: Delete JenisMemo (Admin, PUU)
        // TODO: List all JenisMemo (Admin, PUU)
        // TODO: View a JenisMemo (Admin, PUU)
    }
}
