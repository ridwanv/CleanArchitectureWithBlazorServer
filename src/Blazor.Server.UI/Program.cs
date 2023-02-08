using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Blazor.Infrastructure.Persistence;
using CleanArchitecture.Blazor.Infrastructure.Identity;
using CleanArchitecture.Blazor.Infrastructure;
using CleanArchitecture.Blazor.Application;
using CleanArchitecture.Blazor.Infrastructure.Extensions;
using Serilog;
using Serilog.Events;
using Blazor.Server.UI;
using Blazor.Server.UI.Services.Notifications;
using BlazorShared.Services;
using HashidsNet;
using Hangfire;
using Hangfire.MemoryStorage;
using CleanArchitecture.Blazor.Application.Common.Mappings;
using BlazorShared;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddSingleton(sp => new Hashids("Blazor.net"));
builder.Services.AddHangfire(configuration => configuration
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseMemoryStorage());
builder.Services.AddHangfireServer();
////////////////////////////////////////

builder.Host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Error)
                .MinimumLevel.Override("Serilog", LogEventLevel.Error)
          .Enrich.FromLogContext()
          .Enrich.WithClientIp()
          .Enrich.WithClientAgent()
          .WriteTo.Console()
    );

builder.Services.AddBlazorUIServices();
builder.Services.AddInfrastructureServices(builder.Configuration)
                .AddApplicationServices();


// APPLICATION SPECIFIC SERVICES

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(SharedMappingProfile));
var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseInfrastructure(builder.Configuration);
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();

        if (context.Database.IsSqlServer())
        {
            context.Database.Migrate();
        }

        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();

        await ApplicationDbContextSeed.SeedSampleDataAsync(context);
        await ApplicationDbContextSeed.SeedDefaultUserAsync(context, userManager, roleManager);

    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

        logger.LogError(ex, "An error occurred while migrating or seeding the database.");

        throw;
    }

    var notificationService = scope.ServiceProvider.GetService<INotificationService>();
    if (notificationService is InMemoryNotificationService inmemoryService)
    {
        inmemoryService.Preload();
    }
}


await app.RunAsync();