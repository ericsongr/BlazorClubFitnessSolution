using ClubFitnessDomain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ClubFitnessInfrastructure
{
    public class ClubFitnessDbContext(DbContextOptions<ClubFitnessDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //register all fluent api entity type configuration or inherited by IEntityTypeConfiguration
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
