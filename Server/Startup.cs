using CallCenter.Data;
using CallCenter.Data.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;

namespace CallCenter.Server;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddServerSideBlazor();
        services.AddDbContext<DefaultDbContextQuery>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Startup>());
        services.AddScoped<GetLookupState>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            _ = app.UseExceptionHandler("/Error");
            _ = app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapControllers();
            endpoints.MapFallbackToFile("index.html");
        });
        // Configure the HTTP request pipeline.
        //if (!app.Environment.IsDevelopment())
        //{
        //    _ = app.UseExceptionHandler("/Error");
        //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        //    _ = app.UseHsts();
        //}

        //app.UseHttpsRedirection();

        //app.UseBlazorFrameworkFiles();
        //app.UseStaticFiles();

        //app.UseRouting();
        //app.UseAuthorization();

        //app.MapRazorPages();
        //app.MapControllers(); 
        //app.MapFallbackToFile("index.html");
    }
}
