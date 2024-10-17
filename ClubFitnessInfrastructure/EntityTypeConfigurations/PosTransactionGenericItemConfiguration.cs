using ClubFitnessDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubFitnessInfrastructure.EntityTypeConfigurations
{
    public class PosTransactionGenericItemConfiguration : IEntityTypeConfiguration<PosTransactionGenericItem>
    {
        public void Configure(EntityTypeBuilder<PosTransactionGenericItem> builder)
        {
            builder.HasKey(p => p.PosTransactionGenericItemId);

            builder.Property(p => p.ItemDescription)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.ItemAmount)
                .IsRequired();

            builder.Property(p => p.ItemQuantity)
                .IsRequired();

            builder.HasOne(p => p.PosTransaction)
                .WithMany(t => t.PosTransactionGenericItems)
                .HasForeignKey(p => p.PosTransactionId)
                .HasConstraintName("FK_PosTransactionGenericItem_PosTransaction")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}