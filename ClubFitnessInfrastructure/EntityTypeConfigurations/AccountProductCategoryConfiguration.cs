using ClubFitnessDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubFitnessInfrastructure.EntityTypeConfigurations
{
    public class AccountProductCategoryConfiguration : IEntityTypeConfiguration<AccountProductCategory>
    {
        public void Configure(EntityTypeBuilder<AccountProductCategory> builder)
        {
            builder.HasKey(x => x.AccountProductCategoryId);
            builder.Property(x => x.ProductCategoryName).IsRequired().HasMaxLength(40);
            builder.Property(x => x.ShortDescription).HasMaxLength(255);
            builder.Property(x => x.CreatedUtcDateTime).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.UpdatedUtcDateTime).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.IsPosCategory).HasDefaultValue(true);

            builder.HasOne(x => x.Account)
                .WithMany(x => x.AccountProductCategories)
                .HasForeignKey(x => x.AccountId);

            builder.HasQueryFilter(o => !o.IsDeleted);
        }
    }
}