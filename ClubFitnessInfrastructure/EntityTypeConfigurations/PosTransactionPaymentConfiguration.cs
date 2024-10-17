using ClubFitnessDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubFitnessInfrastructure.EntityTypeConfigurations
{
    public class PosTransactionPaymentConfiguration : IEntityTypeConfiguration<PosTransactionPayment>
    {
        public void Configure(EntityTypeBuilder<PosTransactionPayment> builder)
        {
            builder.HasKey(p => p.PosTransactionPaymentId);

            builder.Property(p => p.Amount)
                .IsRequired();

            builder.Property(p => p.CCNumber)
                .HasMaxLength(25);

            builder.HasOne(p => p.PosTransaction)
                .WithMany(t => t.PosTransactionPayments)
                .HasForeignKey(p => p.PosTransactionId)
                .HasConstraintName("FK_PosTransactionPayment_PosTransaction")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}