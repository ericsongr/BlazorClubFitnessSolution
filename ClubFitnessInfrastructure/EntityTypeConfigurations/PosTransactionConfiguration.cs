using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClubFitnessDomain;

namespace ClubFitnessInfrastructure.EntityTypeConfigurations
{
    public class PosTransactionConfiguration : IEntityTypeConfiguration<PosTransaction>
    {
        public void Configure(EntityTypeBuilder<PosTransaction> builder)
        {
            builder.HasKey(pt => pt.PosTransactionId);
            builder.Property(pt => pt.PosTransactionUtcDateTime).IsRequired();
            builder.Property(pt => pt.PosTransactionLocalDateTime).IsRequired();
            builder.Property(pt => pt.PosTransactionTotalIncTax).IsRequired();
            builder.Property(pt => pt.PosTransactionTotalExTax).IsRequired();
            builder.Property(pt => pt.OutstandingBalance).IsRequired().HasDefaultValue(0);
            builder.Property(pt => pt.IsDeleted).IsRequired().HasDefaultValue(false);
            builder.Property(dc => dc.CreatedBy).IsRequired();
            builder.Property(dc => dc.CreatedDateTimeUtc).IsRequired();

            builder.HasOne(dc => dc.CreatedByStaff)
                .WithMany(dc => dc.CreatedByPosTransactions)
                .HasForeignKey(dc => dc.CreatedBy)
                .HasConstraintName("FK_PosTransaction_CreatedBy")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(dc => dc.UpdatedByStaff)
                .WithMany(dc => dc.UpdatedByPosTransactions)
                .HasForeignKey(dc => dc.UpdatedBy)
                .HasConstraintName("FK_PosTransaction_UpdatedBy")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(dc => dc.DeletedByStaff)
                .WithMany(dc => dc.DeletedByPosTransactions)
                .HasForeignKey(dc => dc.DeletedBy)
                .HasConstraintName("FK_PosTransaction_DeletedBy")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pt => pt.Account)
                .WithMany(pt => pt.PosTransactions)
                .HasForeignKey(pt => pt.AccountId)
                .HasConstraintName("FK_PosTransaction_Accounts_AccountId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}