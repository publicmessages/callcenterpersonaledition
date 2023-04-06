using CallCenter.Server;
using CallCenter.Server.Requests;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((hostContext, services, configuration) =>
{
    _ = configuration.ReadFrom.Configuration(hostContext.Configuration);
});

var startup = new CallCenter.Server.Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);
WebApplication app = builder.Build();
startup.Configure(app, app.Environment);

app.MediateGet<ExampleRequest>("example/{stateCode}");

await app.RunAsync();
