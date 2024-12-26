using Hangfire;
using Hangfire.Storage.SQLite;
using Microsoft.AspNetCore.Identity;
using System.Configuration;
using TicketManagementSystem.Api.Middleware;
using TicketManagementSystem.Application;
using TicketManagementSystem.Infrastructure;
using TicketManagementSystem.Infrastructure.DataContext;
using TicketManagementSystem.Infrastructure.Repository.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
SQLitePCL.Batteries.Init();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddHangfire(config =>
{
    config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
          .UseSimpleAssemblyNameTypeSerializer()
          .UseRecommendedSerializerSettings()
          .UseSQLiteStorage(builder.Configuration.GetConnectionString("TicketManagementSystemDbContext"));
});
builder.Services.AddApplicationServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

    // Ensure database is created
    context.Database.EnsureCreated();

    // Seed roles and admin user
    await SeedIdentityData.SeedRolesAndAdmin(userManager, roleManager);
}
app.UseHangfireDashboard(); // Optional: to view the dashboard
app.UseHangfireServer();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
