using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;

// Legt beim Start Standardrollen (und optional einen Admin-User) an.
namespace KvpTool.Web.Startup
{
    public class IdentitySeedHostedService : IHostedService
    {
        private readonly IServiceProvider _sp;

        // Konstruktor für DI
        public IdentitySeedHostedService(IServiceProvider sp)
        {
            _sp = sp;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _sp.CreateScope();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string[] rolls = ["Admin", "KaizenCoach", "Abteilungsleiter"];

            foreach (var role in rolls)
            {
                if(!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Admin-User anlegen (nur für Dev)
            const string adminMail = "admin@kvptool.local";
            const string adminPass = "Admin12345!";

            var admin = await userManager.FindByEmailAsync(adminMail);
            
            if (admin == null)
            {
                admin = new IdentityUser { UserName = adminMail, Email = adminMail };

                var createRes = await userManager.CreateAsync(admin, adminPass);

                if (!createRes.Succeeded)
                {
                    throw new InvalidOperationException(string.Join("; ", createRes.Errors.Select(e => e.Description)));
                }
                
                var roleRes = await userManager.AddToRoleAsync(admin, "Admin");

                if (!roleRes.Succeeded)
                {
                    throw new InvalidOperationException(string.Join("; ", roleRes.Errors.Select(e => e.Description)));
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
