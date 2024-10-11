using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClubFitnessDomain;

namespace ClubFitnessInfrastructure.EntityTypeConfigurations
{
    public class AccountSupplierConfiguration : IEntityTypeConfiguration<AccountSupplier>
    {
        public void Configure(EntityTypeBuilder<AccountSupplier> builder)
        {
            builder.HasKey(dc => dc.AccountSupplierId);

            builder.Property(s => s.IsActive)
                .HasDefaultValue(true);

            builder.Property(s => s.IsDeleted)
                .HasDefaultValue(false);

            // Define foreign key relationship
            builder.HasOne(s => s.Account)
                .WithMany(s => s.AccountSuppliers)
                .HasForeignKey(s => s.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.CreatedBy)
                .IsRequired();

            builder.Property(x => x.CreatedDateTimeUtc)
                .IsRequired();

            builder.HasOne(dc => dc.CreatedByStaffAccountSupplier)
                .WithMany(dc => dc.CreatedByAccountSuppliers)
                .HasForeignKey(dc => dc.CreatedBy)
                .HasConstraintName("FK_AccountSupplier_CreatedBy_Staff_StaffId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(dc => dc.UpdatedByStaffAccountSupplier)
                .WithMany(dc => dc.UpdatedByAccountSuppliers)
                .HasForeignKey(dc => dc.UpdatedBy)
                .HasConstraintName("FK_AccountSupplier_UpdatedBy_Staff_StaffId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(dc => dc.DeletedByStaffAccountSupplier)
                .WithMany(dc => dc.DeletedByAccountSuppliers)
                .HasForeignKey(dc => dc.DeletedBy)
                .HasConstraintName("FK_AccountSupplier_DeletedBy_Staff_StaffId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(o => !o.IsDeleted);
        }
    }
}