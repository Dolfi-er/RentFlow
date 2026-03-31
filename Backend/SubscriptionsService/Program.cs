using DotNetEnv;
using SubscriptionsService.Extensions;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

app.ConfigureApp();

app.Run();