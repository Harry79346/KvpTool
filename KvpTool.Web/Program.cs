using Microsoft.EntityFrameworkCore;
using KvpTool.Infrastructure.Percistence;
using Microsoft.AspNetCore.Identity;


namespace KvpTool.Web
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            // Hinweis: Identity, DB-Context, Logging, Security, etc. wird in Sprint 0 nachger�stet
            var builder = WebApplication.CreateBuilder(args);

            // 1) ConnectionString aus Appsettings lesen:
            var connectionString = builder.Configuration.GetConnectionString("Default") 
                ?? throw new InvalidOperationException("Connection string 'Default' was not found.");
            // Provider: SQL-Server
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            // 2) Identity-Setup (Default: Identity + Rolle)
            // In Development-Umgebung keine E-Mail-Best�tigung verlangen, f�r Produktion-Umgebung schon.
            var requireConfirmed = !builder.Environment.IsDevelopment();

            builder.Services
                .AddDefaultIdentity<IdentityUser>(options =>
                {
                    // >>> Hier wird nun die Umgebung ber�cksichtigt
                    options.SignIn.RequireConfirmedEmail = requireConfirmed;
                    // Password-Policy
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 10;
                    options.Lockout.MaxFailedAccessAttempts = 5;
                })
                .AddRoles<IdentityRole>() // Rollen aktivieren
                .AddEntityFrameworkStores<AppDbContext>(); // Identity in DbContext speichern

            // MVC aktivieren
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages(); // <- n�tig f�r Identity-UI
            builder.Services.AddHostedService<KvpTool.Web.Startup.IdentitySeedHostedService>();

            var app = builder.Build();

            // Middleware-Pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error"); // Fehlerseite in Prod
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // <- Benutzer anmelden/pr�fen
            app.UseAuthorization();  // <- Rollen/Rechte pr�fen

            app.MapStaticAssets();
            
            // Defailt-Route f�r MVC & Razor
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            // Identity-UI Endpunkte (Login, Register, Layout, Manage)
            app.MapRazorPages();

            app.Run();
        }
    }
}
