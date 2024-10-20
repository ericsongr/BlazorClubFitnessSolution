using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClubFitnessDomain;

namespace ClubFitnessInfrastructure.EntityTypeConfigurations
{
    public class LookupTypesConfiguration : IEntityTypeConfiguration<LookupType>
    {
        public void Configure(EntityTypeBuilder<LookupType> builder)
        {
            builder.HasKey(x => x.TypeId);

            builder.Property(x => x.Type)
                .IsRequired()
                .HasMaxLength(50);

            builder.ToTable("LookupTypes");
        }
    }
}