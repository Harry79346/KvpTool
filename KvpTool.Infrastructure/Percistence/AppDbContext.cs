using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// AppDbContext.cs
// ZENTRALER EF-CORE-KONTEXT
// - Hängt im Infrastructure-Layer, damit DB-Zeug NICHT in Domain/Application landet.
// - Aktuell noch ohne DbSets; Entities werden erst später erstellt.
namespace KvpTool.Infrastructure.Percistence
{
    public class AppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        // Der Konstruktor nimmt die über DI konfigurierten Optionen entgegen.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // >>> Hier werden die "DbSet<Entity> Entities" eingetragen


        protected override void OnModelCreating(ModelBuilder builder)
        {
             base.OnModelCreating(builder); // Wichtig: Identiy-Tabellen konfigurieren
        }
    }
}
