namespace KvpTool.Web
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            // Hinweis: Identity, DB-Context, Logging, Security, etc. wird in Sprint 0 nachgerüstet
            var builder = WebApplication.CreateBuilder(args);

            // MVC aktivieren
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Middleware-Pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error"); // Fehlerseite in Prod
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            
            // Defailt-Route für MVC
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
