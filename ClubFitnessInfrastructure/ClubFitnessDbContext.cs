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
        public DbSet<AccountSupplier> AccountSupplier { get; set; } 
        public DbSet<AccountProductCategory> AccountProductCategory { get; set; } 
        public DbSet<AccountProductSubCategory> AccountProductSubCategory { get; set; } 
        public DbSet<AccountProduct> AccountProduct { get; set; } 
        public DbSet<Staff> Staff { get; set; } 
        public DbSet<DiscountCoupon> DiscountCoupons { get; set; } 
        public DbSet<PosTransaction> PosTransaction { get; set; } 
        public DbSet<PosTransactionItem> PosTransactionItem { get; set; } 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Register all Fluent API entity type configurations inherited from IEntityTypeConfiguration
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}