using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClubFitnessDomain;

namespace ClubFitnessInfrastructure.EntityTypeConfigurations
{
    public class AccountProductSubCategoryConfiguration : IEntityTypeConfiguration<AccountProductSubCategory>
    {
        public void Configure(EntityTypeBuilder<AccountProductSubCategory> builder)
        {
            builder.HasKey(x => x.AccountProductSubCategoryId);

            builder.Property(x => x.AccountId)
                .IsRequired();

            builder.Property(x => x.AccountProductCategoryId)
                .IsRequired();

            builder.Property(x => x.ProductSubCategoryName)
                .IsRequired()
                .HasMaxLength(40);

            // Additional configuration for other properties
        }
    }
}