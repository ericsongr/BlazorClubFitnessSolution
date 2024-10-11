using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClubFitnessDomain;

namespace ClubFitnessInfrastructure.EntityTypeConfigurations
{
    public class AccountProductConfiguration : IEntityTypeConfiguration<AccountProduct>
    {
        public void Configure(EntityTypeBuilder<AccountProduct> builder)
        {
            builder.HasKey(ap => ap.AccountProductId);

            builder.Property(ap => ap.AccountId)
                .IsRequired();

            builder.Property(ap => ap.AccountSupplierId)
                .IsRequired();

            builder.Property(ap => ap.AccountProductCategoryId)
                .IsRequired();

            builder.Property(ap => ap.AccountProductSubCategoryId)
                .IsRequired();

            builder.Property(ap => ap.OnHandQuantity)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(ap => ap.CreatedBy)
                .IsRequired();

            builder.Property(ap => ap.CreatedDateTimeUtc)
                .IsRequired();

            builder.Property(ap => ap.IsDeleted)
                .IsRequired();

            builder.Property(ap => ap.DepartmentType)
                .IsRequired();

            builder.Property(ap => ap.IsActive)
                .IsRequired();

            builder.Property(ap => ap.IsCasualEntry)
                .IsRequired();

            builder.Property(ap => ap.IsPosItem)
                .IsRequired();

            builder.Property(ap => ap.IsStockTakeRequired)
                .IsRequired();

            builder.Property(ap => ap.GstRequired)
                .IsRequired();

            builder.Property(ap => ap.IsCommissionable)
                .IsRequired();

            builder.HasQueryFilter(o => !o.IsDeleted);

            builder.HasOne(dc => dc.StaffCreatedBy)
                .WithMany(dc => dc.CreatedByAccountProducts)
                .HasForeignKey(dc => dc.CreatedBy)
                .HasConstraintName("FK_AccountProduct_Staff_StaffId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(dc => dc.StaffUpdatedBy)
                .WithMany(dc => dc.UpdatedByAccountProducts)
                .HasForeignKey(dc => dc.UpdatedBy)
                .HasConstraintName("[FK_AccountProduct_UpdatedBy_Staff_StaffId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(dc => dc.StaffDeletedBy)
                .WithMany(dc => dc.DeletedByAccountProducts)
                .HasForeignKey(dc => dc.DeletedBy)
                .HasConstraintName("[FK_AccountProduct_DeletedBy_Staff_StaffId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}