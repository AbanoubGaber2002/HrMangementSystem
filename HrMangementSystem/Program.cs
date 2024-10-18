using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HrMangementSystem.Models;

namespace HrMangementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure Database
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Configure Identity
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            // Add controllers and views (MVC)
            builder.Services.AddControllersWithViews();

            // Add session
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Add MVC middleware (Required for routing)
            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                // In production, show detailed error pages
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts(); // Enforce HTTP Strict Transport Security (HSTS)
            }

            app.UseHttpsRedirection(); // Force HTTPS
            app.UseStaticFiles(); // Serve static files (CSS, JS, images)

            app.UseRouting(); // Enable routing middleware

            // Authentication and Authorization
            app.UseAuthentication();
            app.UseAuthorization();

            // Session middleware
            app.UseSession();

            // Default route configuration
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
