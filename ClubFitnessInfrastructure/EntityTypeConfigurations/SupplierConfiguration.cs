using ClubFitnessDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubFitnessInfrastructure.EntityTypeConfigurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<AccountSupplier>
    {
        public void Configure(EntityTypeBuilder<AccountSupplier> builder)
        {
            builder.HasKey(s => s.AccountSupplierId);

            builder.Property(s => s.CreatedUtcDateTime)
                .HasDefaultValueSql("getutcdate()");

            builder.Property(s => s.UpdatedUtcDateTime)
                .HasDefaultValueSql("getutcdate()");

            builder.Property(s => s.IsActive)
                .HasDefaultValue(true);

            builder.Property(s => s.IsDeleted)
                .HasDefaultValue(false);

            // Define foreign key relationship
            builder.HasOne(s => s.Account)
                .WithMany(s => s.AccountSuppliers)
                .HasForeignKey(s => s.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}