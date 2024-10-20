using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClubFitnessDomain;

namespace ClubFitnessInfrastructure.EntityTypeConfigurations
{
    public class LookupTypeItemsConfiguration : IEntityTypeConfiguration<LookupTypeItem>
    {
        public void Configure(EntityTypeBuilder<LookupTypeItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(x => x.IsSystem)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.IsShowOnline)
                .IsRequired()
                .HasDefaultValue(true);

            // Configure the foreign key relationship
            builder.HasOne(x => x.LookupType)
                .WithMany(x => x.LookupTypeItems)
                .HasForeignKey(x => x.TypeId)
                .HasConstraintName("FK_LookupTypeItems_TypeId_LookupTypes_TypeId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("LookupTypeItems");
        }
    }
}