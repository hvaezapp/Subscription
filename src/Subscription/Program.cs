using Carter;
using Scalar.AspNetCore;
using ServiceCollector.Core;
using Subscription.Configuration;
using Subscription.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.ConfigureDbContexts(builder.Configuration);
builder.Services.ConfigureValidator();
builder.Services.AddCarter();
builder.Services.AddServiceDiscovery();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseMiddleware<GlobalExceptionHandler>();

app.MapCarter();

app.Run();
