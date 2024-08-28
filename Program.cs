using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using EMemorandum.Authorization;
using EMemorandum.Models;
using System.Reflection;
using System.IO;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// The EnvironmentName property contains the value of the ASPNETCORE_ENVIRONMENT environment variable
Console.WriteLine($"Current Environment: {builder.Environment.EnvironmentName}");

// Load the appsettings.json and environment-specific appsettings
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("AppSettingsEnv/appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"AppSettingsEnv/appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:8080") // TODO: Other frontend origins will be added here
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

// Configure the DbContext with the connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// In production, the Vue files will be served from this directory
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "wwwroot";
});

// Configure JWT authentication
var secretKey = builder.Configuration.GetValue<string>("Jwt:SecretKey");
var key = Encoding.ASCII.GetBytes(secretKey);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Register the custom authorization handler as scoped
builder.Services.AddScoped<IAuthorizationHandler, TokenHandlerAuth>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Configure Authorization with custom policy
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("TokenPolicy", policy =>
    {
        policy.Requirements.Add(new TokenRequirement(null)); // No role required for this policy
    });

    options.AddPolicy("AdminPolicy", policy =>
    {
        policy.Requirements.Add(new TokenRequirement(new[] { "Admin" }));
    });

    options.AddPolicy("PUUPolicy", policy =>
    {
        policy.Requirements.Add(new TokenRequirement(new[] { "PUU" }));
    });

    options.AddPolicy("PTJPolicy", policy =>
    {
        policy.Requirements.Add(new TokenRequirement(new[] { "PTJ" }));
    });

    options.AddPolicy("AdminOrPUUPolicy", policy =>
    {
        policy.Requirements.Add(new TokenRequirement(new[] { "Admin", "PUU" }));
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.EnvironmentName == "Local")
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
    app.UseDeveloperExceptionPage();
} else {
    // Configure the base path
    app.UsePathBase("/emo");
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSpaStaticFiles();

app.UseRouting();
app.UseAuthorization();

// Enable CORS
app.UseCors("AllowSpecificOrigin");

// Ensure that API endpoints are mapped before the SPA middleware
app.MapControllers();

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "wwwroot";

    // if (app.Environment.IsDevelopment())
    // {
    //     spa.UseProxyToSpaDevelopmentServer("http://localhost:8080");
    // }
});

app.Run();
