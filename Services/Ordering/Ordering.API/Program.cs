var builder = WebApplication.CreateBuilder(args);

//Add services to the container

var app = builder.Build();

//configuring http request lifecycle

app.Run();
