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
    public class SubPTjController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubPTjController(IConfiguration configuration, ApplicationDbContext context)
        {
            _context = context;
        }

        // TODO: Add SubPTj (Admin, PUU)
        // TODO: Update SubPTj (Admin, PUU)
        // TODO: Delete SubPTj (Admin, PUU)
        // TODO: List all SubPTj (Admin, PUU)
        // TODO: View a SubPTj (Admin, PUU)
    }
}
