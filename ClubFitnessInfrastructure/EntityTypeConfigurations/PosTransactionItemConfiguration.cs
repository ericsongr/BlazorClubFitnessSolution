using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClubFitnessDomain;

namespace ClubFitnessInfrastructure.EntityTypeConfigurations
{
    public class PosTransactionItemConfiguration : IEntityTypeConfiguration<PosTransactionItem>
    {
        public void Configure(EntityTypeBuilder<PosTransactionItem> builder)
        {
            builder.HasKey(pti => pti.PosTransactionItemId);

            builder.Property(pti => pti.ItemQuantity).IsRequired();
            builder.Property(pti => pti.ItemTaxAmount).IsRequired();
            builder.Property(pti => pti.ItemPriceExTax).IsRequired();
            builder.Property(pti => pti.ItemPriceIncTax).IsRequired();
            builder.Property(pti => pti.Discount).IsRequired().HasDefaultValue(0);
            builder.Property(pti => pti.IsRefunded).IsRequired().HasDefaultValue(false);
            builder.Property(pti => pti.IsVoided).IsRequired().HasDefaultValue(false);

            // Foreign Key to PosTransaction
            builder.HasOne(pti => pti.PosTransaction)
                .WithMany(pt => pt.PosTransactionItems)
                .HasForeignKey(pti => pti.PosTransactionId)
                .HasConstraintName("FK_PosTransactionItem_PosTransaction")
                .OnDelete(DeleteBehavior.Cascade);

            // Foreign Key to AccountProduct
            builder.HasOne(pti => pti.AccountProduct)
                .WithMany(pt => pt.PosTransactionItems)
                .HasForeignKey(pti => pti.ProductId)
                .HasConstraintName("FK_PosTransactionItem_AccountProduct")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pti => pti.LookupTypeItem)
                .WithMany(pt => pt.PosTransactionItems)
                .HasForeignKey(pti => pti.DiscountByLookupItemId)
                .HasConstraintName("FK_PosTransactionItem_DiscountByLookupItemId_AccountProduct_LookupTypeItem_Id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pti => pti.DiscountCoupon)
                .WithMany(pt => pt.PosTransactionItems)
                .HasPrincipalKey(dc => dc.CouponCode) // Specify CouponCode as the principal key
                .HasForeignKey(pti => pti.CouponCode) // Use CouponCode in PosTransactionItem as the foreign key
                .HasConstraintName("FK_PosTransactionItem_CouponCode_AccountProduct_DiscountCoupon_CouponCode")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}