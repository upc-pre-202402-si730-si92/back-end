using Application.Learning.CommandServices;
using Application.Learning.QueryServices;
using Domain.Learning.Repositories;
using Domain.Learning.Services;
using Domain.Shared;
using Infrastructure.Learning;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Presentation.Shared.Middleware;

var builder = WebApplication.CreateBuilder(args);

//Azure inight
builder.Services.AddApplicationInsightsTelemetry();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection native - before .net core Autofact,Nijtect
builder.Services.AddScoped<ITutorialRepository, TutorialRepository>();
builder.Services.AddScoped<ITutorialQueryService, TutorialQueryService>();
builder.Services.AddScoped<ITutorialCommandService, TutorialCommandService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


//Conexion a MySQL 
var connectionString = builder.Configuration.GetConnectionString("learningCenterConnection");

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();
    });

var app = builder.Build();


EnsureDatabaseCreation(app);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.UseMiddleware<ErrorHandlerMiddleware>();

app.Run();

// Method to handle database creation
void EnsureDatabaseCreation(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        context.Database.EnsureCreated();
    }
}