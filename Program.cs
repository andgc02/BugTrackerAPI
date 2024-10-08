using BugTrackerAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register the BugContext with an in-memory database
builder.Services.AddDbContext<BugContext>(options =>
    options.UseInMemoryDatabase("BugList"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Removed HTTPS redirection to avoid ERR_CERT_INVALID in development
// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();