
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.FileProviders;
using System.IO;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CorporateMassenger.Data;

namespace CorporateMessenger
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddMvc(options =>
            {
                options.SslPort = 44398;
                options.Filters.Add(new RequireHttpsAttribute());
            });
        }

        public async void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
   

            app.UseFileServer(new FileServerOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "node_modules")),
                RequestPath = "/node_modules",
                EnableDirectoryBrowsing = false
            });

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = "Cookies",
                LoginPath = new PathString("/Singin/Index"),
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });
            app.UseGoogleAuthentication(new GoogleOptions
            {
                ClientId = "815966292218-2s5a27ss6iej414vcmtvfbnii9idmm7i.apps.googleusercontent.com",
                ClientSecret = "-HmgT9i8vIhrXVFeEl8h6Kt1",
                CallbackPath = new PathString("/GoogleLoginCallback"),
                SignInScheme = "Cookies"
            });
            app.UseCors("CorsPolicy");

            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "spa-fallback",
                //    template: "{controller=Confirm}/{action=Result}");
                routes.MapRoute(
                          name: "default",
                          template: "{*url}",
                          defaults: new { controller = "Massanger", action = "Index" });

                routes.MapRoute(
                           name: "fallback",
                           template: "{*url}",
                           defaults: new { controller = "Confirm", action = "Result" });


            });
            //await DatabaseInitialize(app.ApplicationServices);
        }
    }
 }
