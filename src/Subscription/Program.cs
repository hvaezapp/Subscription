using Subscription.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureDbContexts(builder.Configuration);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Run();
