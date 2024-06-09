using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_kol2cf_rev1.Entities.Configs
{
    public class BoatStandardEfConfig : IEntityTypeConfiguration<BoatStandard>
    {
        public void Configure(EntityTypeBuilder<BoatStandard> builder)
        {
            builder.HasKey(bs => bs.IdBoatStandard);
            builder.Property(bs => bs.IdBoatStandard).ValueGeneratedNever();
            builder.Property(bs => bs.Name).HasMaxLength(100).IsRequired();
            builder.Property(bs => bs.Level).IsRequired();

            builder.HasData(
                new BoatStandard
                {
                    IdBoatStandard = 1,
                    Name = "Standard",
                    Level = 1
                },
                new BoatStandard
                {
                    IdBoatStandard = 2,
                    Name = "Premium",
                    Level = 2
                },
                new BoatStandard
                {
                    IdBoatStandard = 3,
                    Name = "Luxury",
                    Level = 3
                }
            );
            
            builder.ToTable("BoatStandard");
        }
    }
}