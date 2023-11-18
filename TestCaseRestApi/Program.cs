using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Extensions.Logging;
using TestCaseRestApi;
using TestCaseRestApi.Data;
using TestCaseRestApi.Repositories;

var _logger = LogManager.GetCurrentClassLogger();


var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging(logBuilder =>
{
    logBuilder.ClearProviders();
    logBuilder.AddNLog();
});
builder.Services.AddAutoMapper(typeof(AppMappingProfile));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.DictionaryKeyPolicy = null;
});

try
{
    builder.Services.AddDbContext<AppDataContext>(options => options.UseNpgsql(connection));
}
catch (Exception)
{
    _logger.Error("Invalid connect to Database. Check connection string");
}

builder.Services.AddScoped<DrillBlockRepository>();
builder.Services.AddScoped<DrillBlockPointRepository>();
builder.Services.AddScoped<HolePointRepository>();
builder.Services.AddScoped<HoleRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
