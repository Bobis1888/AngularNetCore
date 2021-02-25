using AngularDotnetCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AngularDotnetCore.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AngularDotnetCore
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            // string connectionString = "Host=localhost;Database=test_angular;Username=angular;Password=angular";
            // string connectionString = "Host=ec2-34-230-167-186.compute-1.amazonaws.com;Database=d3dboka8cnqkpp;Username=wwjcesiaclywuw;Password=1c5f15cfdbf12e40bbfa3439a3ca4fb33e5e767aef1971e0dbfd293ad7156617;SslMode=Require;TrustServerCertificate=true";
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));

            services.AddControllers();
            services.AddTransient<HttpClientService>();
            services.AddTransient<RssService>();
            services.AddTransient<ItemService>();
            services.AddTransient<AccountService>();
            
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }
 
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
 
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
                 
                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
