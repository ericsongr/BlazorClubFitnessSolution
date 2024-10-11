using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClubFitnessDomain;

namespace ClubFitnessInfrastructure.EntityTypeConfigurations
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(s => s.StaffId);
            
            builder.Property(s => s.FirstName).IsRequired();
            builder.Property(s => s.LastName).IsRequired();
            builder.Property(s => s.MobilePhone).IsRequired();
            builder.Property(s => s.Barcode).IsRequired();
            builder.Property(s => s.Email).IsRequired();

            builder.Property(s => s.LastModifiedUTCDateTime).IsRequired().HasDefaultValueSql("getutcdate()");
            builder.Property(s => s.MobilePhone).IsRequired().HasMaxLength(20);
            builder.Property(s => s.HourlyRate).IsRequired().HasDefaultValue(0);

            // Foreign Key
            builder.HasOne(s => s.PreferredClubAccount)
                .WithMany(s => s.Staffs)
                .HasForeignKey(s => s.PreferredClub)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(o => !o.IsDeleted);
        }
    }
}