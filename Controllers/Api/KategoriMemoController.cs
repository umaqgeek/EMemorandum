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
    public class KategoriMemoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KategoriMemoController(IConfiguration configuration, ApplicationDbContext context)
        {
            _context = context;
        }

        // TODO: Add KategoriMemo (Admin, PUU)
        // TODO: Update KategoriMemo (Admin, PUU)
        // TODO: Delete KategoriMemo (Admin, PUU)
        // TODO: List all KategoriMemo (Admin, PUU)
        // TODO: View a KategoriMemo (Admin, PUU)
    }
}
