using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClubFitnessDomain;

namespace ClubFitnessInfrastructure.EntityTypeConfigurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(dc => dc.Id);

            builder.HasOne(au => au.Staff)
                .WithOne(s => s.ApplicationUser)
                .HasForeignKey<ApplicationUser>(au => au.StaffId) // Set the foreign key property in ApplicationUser
                .HasConstraintName("FK_AspNetUsers_StaffId_Staff_StaffId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}