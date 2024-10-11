using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClubFitnessDomain;

namespace ClubFitnessInfrastructure.EntityTypeConfigurations
{
    public class DiscountCouponConfiguration : IEntityTypeConfiguration<DiscountCoupon>
    {
        public void Configure(EntityTypeBuilder<DiscountCoupon> builder)
        {
            builder.HasKey(dc => dc.Id);

            builder.Property(dc => dc.Name).HasMaxLength(100);
            builder.Property(dc => dc.CouponCode).HasMaxLength(100);
            builder.Property(dc => dc.Discount).IsRequired().HasColumnType("decimal(18, 2)");
            builder.Property(dc => dc.DiscountType).IsRequired();
            builder.Property(dc => dc.MinimumAmount).HasColumnType("decimal(18, 0)");
            builder.Property(dc => dc.IsActive).IsRequired();
            builder.Property(dc => dc.CreatedBy).IsRequired();
            builder.Property(dc => dc.CreatedDateTimeUtc).IsRequired();
            builder.Property(dc => dc.AccountId).IsRequired();
            builder.Property(dc => dc.DiscountFor).IsRequired();
            builder.Property(dc => dc.IsCombineFees).IsRequired();
            builder.Property(dc => dc.ChargeType).HasMaxLength(50);
            builder.Property(dc => dc.AllocatedValueJson).HasColumnType("varchar(max)");

            builder.HasOne(dc => dc.CreatedByStaff)
                .WithMany(dc => dc.StaffDiscountCoupons)
                .HasForeignKey(dc => dc.CreatedBy)
                .HasConstraintName("FK_DiscountCoupons_Staff")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(dc => dc.UpdatedByStaff)
                .WithMany(dc => dc.StaffUpdatedDiscountCoupons)
                .HasForeignKey(dc => dc.UpdatedBy)
                .HasConstraintName("FK_DiscountCoupons_Staff1")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(dc => dc.DeletedByStaff)
                .WithMany(dc => dc.StaffDeletedDiscountCoupons)
                .HasForeignKey(dc => dc.DeletedBy)
                .HasConstraintName("FK_DiscountCoupon_DeletedBy_Staff_StaffId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(o => !o.IsDeleted);
        }
    }
}