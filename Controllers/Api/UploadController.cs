using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace EMemorandum.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = "StaffPolicy")]
public class UploadController : ControllerBase
{
    // Directory to save files (ensure this path exists or create it dynamically)
    private readonly string _uploadDirectory;
    private readonly IWebHostEnvironment _env;

    public UploadController(IWebHostEnvironment env)
    {
        _env = env;
        var uploadPath = _env.EnvironmentName != "Local" ? "wwwroot/uploads" : "web-app/public/uploads";
        _uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), uploadPath);
    }

    [HttpPost]
    [Route("upload")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        try
        {
            // Ensure the upload directory exists
            if (!Directory.Exists(_uploadDirectory))
            {
                Directory.CreateDirectory(_uploadDirectory);
            }

            // Create a unique file name and save it
            var fileName = $"{Path.GetRandomFileName()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(_uploadDirectory, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Return the relative file path
            var relativePath = $"uploads/{fileName}";
            return Ok(new { filePath = relativePath });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
