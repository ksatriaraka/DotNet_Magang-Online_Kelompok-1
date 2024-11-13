using Departemen_Matematika.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;

namespace Departemen_Matematika.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Dosen> Dosen { get; set; }

        public DbSet<Mahasiswa> Mahasiswa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
