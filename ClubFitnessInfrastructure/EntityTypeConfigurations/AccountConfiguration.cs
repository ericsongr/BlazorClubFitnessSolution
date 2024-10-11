using ClubFitnessDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubFitnessInfrastructure.EntityTypeConfigurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            // Configure the primary key
            builder.HasKey(a => a.AccountId);

            // Configure property lengths and types
            builder.Property(a => a.AccountName).HasMaxLength(50);
            builder.Property(a => a.Timezone).HasMaxLength(50);
            builder.Property(a => a.Street).HasMaxLength(500);
            builder.Property(a => a.SubUrb).HasMaxLength(500);
            builder.Property(a => a.State).HasMaxLength(500);
            builder.Property(a => a.PostalCode).HasMaxLength(500);
            builder.Property(a => a.Email).HasMaxLength(500);
            builder.Property(a => a.PhoneNumber).HasMaxLength(100);

            builder.Property(a => a.WebsiteUrl).HasColumnType("varchar(500)").HasMaxLength(500);
            builder.Property(a => a.FacebookUrl).HasColumnType("varchar(500)").HasMaxLength(500);
            builder.Property(a => a.AddressLine1).HasColumnType("varchar(200)").HasMaxLength(200);
            builder.Property(a => a.City).HasColumnType("varchar(200)").HasMaxLength(200);
            builder.Property(a => a.BusinessOwnerName).HasColumnType("varchar(100)").HasMaxLength(100);
            builder.Property(a => a.BusinessOwnerPhoneNumber).HasColumnType("varchar(100)").HasMaxLength(100);
            builder.Property(a => a.BusinessOwnerEmail).HasColumnType("varchar(100)").HasMaxLength(100);
            builder.Property(a => a.GeoCoordinates).HasColumnType("varchar(75)").HasMaxLength(75);

            builder.Property(a => a.CompanyLegalName).HasColumnType("varchar(200)").HasMaxLength(200);

            // Set defaults for certain fields
            builder.Property(a => a.IsActive).HasDefaultValue(true);
            builder.Property(a => a.DialingCode).HasDefaultValue("63").HasMaxLength(5);
            builder.Property(a => a.ClubfitFeeFailedPaymentCount).HasDefaultValue(0);

            // Configure the AdvancedEmailEditorUid as a sequential GUID
            builder.Property(a => a.AdvancedEmailEditorUid)
                .HasDefaultValueSql("newsequentialid()");

            // Configure other properties
            builder.Property(a => a.PaymentIssueSuspensionDate).HasColumnType("datetime");

            builder.HasQueryFilter(o => !o.IsDeleted);

        }
    }
}
