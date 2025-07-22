using BestPractices.Api.Extensions;
using BestPractices.Api.Logging;
using BestPractices.Api.Service;
using BestPractices.Api.Validations;
using BestPractices.Models;
using FluentValidation;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information() // Minimum seviye debug
    //.WriteTo.Debug()
    .WriteTo.File("Logs.txt")
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();
builder.Services.AddHealthChecks();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.ConfigureMapping();
builder.Services.AddTransient<IValidator<ContactDVO>, ContactValidator>();

builder.Services.AddHttpClient("garantiapi", config =>
{
    config.BaseAddress = new Uri("http://www.garanti.com");
    config.DefaultRequestHeaders.Add("Authorization", "Bearer 1212121212");
});


builder.Services.AddLogging(i =>
{
    i.ClearProviders();
    i.SetMinimumLevel(LogLevel.Information);
    //i.AddDebug();
    i.AddProvider(new MyCustomLoggerProvider());
    
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
   
}

app.UseCustomHealthCheck();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseResponseCaching();

app.Run();
