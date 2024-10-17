using ClubFitnessDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubFitnessInfrastructure.EntityTypeConfigurations
{
    public class PosTransactionAuditConfiguration : IEntityTypeConfiguration<PosTransactionAudit>
    {
        public void Configure(EntityTypeBuilder<PosTransactionAudit> builder)
        {
            builder.HasKey(p => p.PosTransactionAuditId);

            builder.Property(p => p.PosTransactionTotalIncTax).IsRequired();
            builder.Property(p => p.PosTransactionTotalExTax).IsRequired();
            builder.Property(p => p.PosTransactionTotalTax).IsRequired();

            builder.Property(p => p.ItemPriceIncTax).IsRequired();
            builder.Property(p => p.ItemPriceExTax).IsRequired();
            builder.Property(p => p.ItemQuantity).IsRequired();

            builder.HasOne(p => p.PosTransaction)
                .WithMany(t => t.PosTransactionAudits)
                .HasForeignKey(p => p.PosTransactionId)
                .HasConstraintName("FK_PosTransactionAudit_POSTransactionId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Staff)
                .WithMany(s => s.StaffPosTransactionAudits)
                .HasForeignKey(p => p.StaffMemberId)
                .HasConstraintName("FK_SalesPersonStaff_PosTransactionAudits_SalesPersonStaffId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}