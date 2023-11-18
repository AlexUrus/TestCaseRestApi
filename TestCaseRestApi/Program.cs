using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Extensions.Logging;
using Npgsql;
using System.Diagnostics;
using TestCaseRestApi;
using TestCaseRestApi.Data;
using TestCaseRestApi.Repositories;


internal class Program
{
    private static void Main(string[] args)
    {

        var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(System.AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false);

        IConfiguration configuration = configurationBuilder.Build();
        
        var builder = WebApplication.CreateBuilder(args);
        builder.Host.UseWindowsService();
        IServiceCollection services = builder.Services;

        AddLogging(services);
        AddDatabaseClient(services, configuration);
        AddRepositories(services);

        services.AddControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddAutoMapper(typeof(AppMappingProfile));

        services.AddWindowsService(options =>
        {
            options.ServiceName = "TestCaseRestApi";
        });

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();
        app.MapControllers();

        app.Run();
    }

    private static void AddLogging(IServiceCollection services)
    {
        services.AddLogging(logBuilder =>
        {
            logBuilder.ClearProviders();
            logBuilder.AddNLog();
        });
    }

    private static void AddDatabaseClient(IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient(serviceProvider => new NpgsqlConnection (configuration.GetConnectionString("Postgres")))
                   .AddDbContext<AppDataContext>();
                   
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<DrillBlockRepository>();
        services.AddScoped<DrillBlockPointRepository>();
        services.AddScoped<HolePointRepository>();
        services.AddScoped<HoleRepository>();
    }
}