using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using EMemorandum.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the DbContext with the connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// In production, the Vue files will be served from this directory
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "web-app/dist";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSpaStaticFiles();

app.UseRouting();
app.UseAuthorization();

// Ensure that API endpoints are mapped before the SPA middleware
app.MapControllers();

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "web-app";

    // if (app.Environment.IsDevelopment())
    // {
    //     spa.UseProxyToSpaDevelopmentServer("http://localhost:8080");
    // }
});

app.Run();
