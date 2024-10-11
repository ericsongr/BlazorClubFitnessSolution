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

            builder.Property(x => x.CreatedBy)
                .IsRequired();

            builder.Property(x => x.CreatedDateTimeUtc)
                .IsRequired();

            builder.HasOne(dc => dc.CreatedByStaffSubCategory)
                .WithMany(dc => dc.CreatedByProductSubCategories)
                .HasForeignKey(dc => dc.CreatedBy)
                .HasConstraintName("FK_AccountProductSubCategory_CreatedBy_Staff_StaffId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(dc => dc.UpdatedByStaffSubCategory)
                .WithMany(dc => dc.UpdatedByProductSubCategories)
                .HasForeignKey(dc => dc.UpdatedBy)
                .HasConstraintName("FK_AccountProductSubCategory_UpdatedBy_Staff_StaffId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(dc => dc.DeletedByStaffSubCategory)
                .WithMany(dc => dc.DeletedByProductSubCategories)
                .HasForeignKey(dc => dc.DeletedBy)
                .HasConstraintName("FK_AccountProductSubCategory_DeletedBy_Staff_StaffId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(o => !o.IsDeleted);
        }
    }
}