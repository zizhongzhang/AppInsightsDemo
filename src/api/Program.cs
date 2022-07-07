using api;
using Azure.Identity;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "whitelistdomains",
                      corsBuilder =>
                      {
                          corsBuilder.WithOrigins(builder.Configuration["AllowedHosts"]);
                      });
});

builder.Services.AddDbContext<ContactContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ContactDatabase")));

builder.Services.Configure<TelemetryConfiguration>(config =>
{
    var credential = new ManagedIdentityCredential();
    config.SetAzureTokenCredential(credential);
});
builder.Services.AddApplicationInsightsTelemetry(new ApplicationInsightsServiceOptions
{
    ConnectionString = "InstrumentationKey=2d1cd380-8ff5-455a-a977-3ef0c67cc322;IngestionEndpoint=https://australiasoutheast-0.in.applicationinsights.azure.com/;LiveEndpoint=https://australiasoutheast.livediagnostics.monitor.azure.com/"
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
