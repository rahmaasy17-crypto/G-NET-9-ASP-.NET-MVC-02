using GymManagement.Configuration;
using GymManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.DBContexts
{
    public class GymDbContext:DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)// مش مكانها الصح
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=GymManagement;Trusted_Connection=True;TrustServerCertificate=True;");

        //}
        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options) { } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Plan>(new PlanConfigurations());
        }
       public DbSet <Plan> plans { get; set; }
    }
}
