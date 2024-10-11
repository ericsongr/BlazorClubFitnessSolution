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
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.IsPosCategory).HasDefaultValue(true);

            builder.Property(x => x.CreatedBy)
                .IsRequired();

            builder.Property(x => x.CreatedDateTimeUtc)
                .IsRequired();

            builder.HasOne(dc => dc.CreatedByStaffAccountProductCategory)
                .WithMany(dc => dc.CreatedByAccountProductCategories)
                .HasForeignKey(dc => dc.CreatedBy)
                .HasConstraintName("FK_AccountProductCategory_CreatedBy_Staff_StaffId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(dc => dc.UpdatedByStaffAccountProductCategory)
                .WithMany(dc => dc.UpdatedByAccountProductCategories)
                .HasForeignKey(dc => dc.UpdatedBy)
                .HasConstraintName("FK_AccountProductCategory_UpdatedBy_Staff_StaffId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(dc => dc.DeletedByStaffAccountProductCategory)
                .WithMany(dc => dc.DeletedByAccountProductCategories)
                .HasForeignKey(dc => dc.DeletedBy)
                .HasConstraintName("FK_AccountProductCategory_DeletedBy_Staff_StaffId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Account)
                .WithMany(x => x.AccountProductCategories)
                .HasForeignKey(x => x.AccountId);

            builder.HasQueryFilter(o => !o.IsDeleted);
        }
    }
}