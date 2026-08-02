using FactoryPulse.Api.Hubs;
using FactoryPulse.Api.Middleware;

using FactoryPulse.Application.Interfaces;
using FactoryPulse.Application.Services;
using FactoryPulse.Application.Validators;

using FactoryPulse.Infrastructure.Data;
using FactoryPulse.Infrastructure.Repositories;

using FluentValidation;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


// Controllers + Swagger + SignalR

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();


// CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy("frontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});


// Database

builder.Services.AddDbContext<FactoryPulseDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));


// Repositories

builder.Services.AddScoped<IMachineRepository, MachineRepository>();

builder.Services.AddScoped<ITelemetryRepository, TelemetryRepository>();

builder.Services.AddScoped<IAlertRepository, AlertRepository>();

builder.Services.AddScoped<IEventRepository, EventRepository>();


// Services

builder.Services.AddScoped<IDashboardNotifier, DashboardNotifier>();

builder.Services.AddScoped<TelemetryService>();

builder.Services.AddScoped<MachineService>();

builder.Services.AddScoped<AlertService>();

builder.Services.AddScoped<MachineHealthService>();

builder.Services.AddScoped<DashboardService>();

builder.Services.AddScoped<OverviewService>();

builder.Services.AddScoped<EventService>();


// Background Services

builder.Services.AddHostedService<TelemetrySimulatorService>();


// Validation

builder.Services.AddValidatorsFromAssemblyContaining<TelemetryRequestValidator>();


var app = builder.Build();


// Database Seed

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider
        .GetRequiredService<FactoryPulseDbContext>();

    await DbSeeder.SeedAsync(db);
}


// Middleware

app.UseMiddleware<ExceptionMiddleware>();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}


app.UseCors("frontend");


app.UseHttpsRedirection();

app.UseDefaultFiles();

app.UseStaticFiles();


app.MapControllers();


// SignalR

app.MapHub<DashboardHub>(
    "/hubs/dashboard"
);


app.Run();