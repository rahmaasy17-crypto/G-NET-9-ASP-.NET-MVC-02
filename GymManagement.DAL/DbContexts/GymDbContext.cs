using GymManagement.Configuration;
using GymManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.DBContexts
{
    public class GymDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=GymManagement;Trusted_Connection=True;TrustServerCertificate=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Plan>(new PlanConfigurations());
        }
       public DbSet <Plan> plans { get; set; }
    }
}
