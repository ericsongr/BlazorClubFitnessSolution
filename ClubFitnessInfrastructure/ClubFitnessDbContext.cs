using ClubFitnessDomain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ClubFitnessInfrastructure
{
    public class ClubFitnessDbContext : IdentityDbContext<ApplicationUser>
    {
        public ClubFitnessDbContext(DbContextOptions<ClubFitnessDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountSupplier> AccountSupplier { get; set; } // Added AccountSupplier DbSet

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Register all Fluent API entity type configurations inherited from IEntityTypeConfiguration
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}