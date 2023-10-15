using Microsoft.EntityFrameworkCore;
using TestCaseRestApi.Data;
using TestCaseRestApi.Repositories;


var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.DictionaryKeyPolicy = null;
});
builder.Services.AddDbContext<AppDataContext>(options => options.UseNpgsql(connection));

builder.Services.AddScoped<DrillBlockRepository>();
builder.Services.AddScoped<DrillBlockPointRepository>();
builder.Services.AddScoped<HolePointRepository>();
builder.Services.AddScoped<HoleRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
