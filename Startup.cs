using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using MVCSAMPLE.Models;

namespace MVCSAMPLE
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {

            configuration = configuration;

        }
        public IConfiguration configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Bind SmtpSettings from appsettings.json
            services.Configure<SMPT>(configuration.GetSection("SmtpSettings"));

            // Register EmailService
            services.AddTransient<EmailService>();

            // Other service configurations
            services.AddControllersWithViews();
        }
        public void Configureservices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }
        public void configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();

            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=ContactInfo}/{action=Email}/{id?}"
                    );
            });
        }
    }
}
