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
    public class ScopeMemoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ScopeMemoController(IConfiguration configuration, ApplicationDbContext context)
        {
            _context = context;
        }

        // TODO: Add ScopeMemo (Admin, PUU)
        // TODO: Update ScopeMemo (Admin, PUU)
        // TODO: Delete ScopeMemo (Admin, PUU)
        // TODO: List all ScopeMemo (Admin, PUU)
        // TODO: View a ScopeMemo (Admin, PUU)
    }
}
