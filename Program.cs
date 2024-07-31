using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCSAMPLE.Models;

namespace MVCSAMPLE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configuration
            var configuration = builder.Configuration;

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Bind SmtpSettings from appsettings.json
            builder.Services.Configure<SMPT>(configuration.GetSection("SmtpSettings"));

            // Register EmailService
            builder.Services.AddTransient<EmailService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
