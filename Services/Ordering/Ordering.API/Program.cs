using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

//Add services to the container

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

 
var app = builder.Build();

//configuring http request lifecycle

app.Run();
