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
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using EMemorandum.Models;

namespace EMemorandum.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = "StaffPolicy")]
public class CountriesController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly string _jsonFilePath;

    public CountriesController(IConfiguration configuration, ApplicationDbContext context)
    {
        _context = context;
        _jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "JSONs", "countries.json");
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCountries()
    {
        try {
            // Ensure the file exists
            if (!System.IO.File.Exists(_jsonFilePath)) {
                return NotFound("JSON file for Countries not found!");
            }
            var jsonData = await System.IO.File.ReadAllTextAsync(_jsonFilePath);
            var countries = JsonSerializer.Deserialize<List<Country>>(jsonData);
            if (countries == null || countries.Count == 0) {
                return BadRequest("The JSON file Countries is empty or invalid.");
            }
            foreach (var country in countries) {
                country.name = country.name.ToUpper();
            }
            return Ok(countries);
        } catch (Exception ex) {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
