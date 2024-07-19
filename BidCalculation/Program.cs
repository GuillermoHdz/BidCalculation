using BidCalculation.Business.Factories;
using BidCalculation.Business.Services;
using BidCalculation.Common.Settings;
using BidCalculation.Data;
using BidCalculation.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();
if (!string.IsNullOrWhiteSpace(appSettings?.CorsList))
{
    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(policy => { policy.WithOrigins(appSettings.CorsList).AllowAnyHeader().AllowAnyMethod(); });
    });
}

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDatabaseDataContext, SqlServerDataContext>();
builder.Services.AddSingleton<ICalculationFactory, CalculationFactory>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IVehicleService, VehicleService>();

builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
