using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_kol2cf_rev1.Entities.Configs
{
    public class SailboatEfConfig : IEntityTypeConfiguration<Sailboat>
    {
        public void Configure(EntityTypeBuilder<Sailboat> builder)
        {
            builder.HasKey(sb => sb.IdSailboat);
            builder.Property(sb => sb.IdSailboat).ValueGeneratedNever();
            builder.Property(sb => sb.Name).HasMaxLength(100).IsRequired();
            builder.Property(sb => sb.Capacity).IsRequired();
            builder.Property(sb => sb.Description).HasMaxLength(100).IsRequired();
            builder.HasOne(sb => sb.BoatStandardNavigation)
                .WithMany(bs => bs.Sailboats)
                .HasForeignKey(sb => sb.IdBoatStandard)
                .HasConstraintName("Sailboat_BoatStandard")
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(sb => sb.Price).HasColumnType("money").IsRequired();

            builder.HasData(
                new Sailboat
                {
                    IdSailboat = 1,
                    Name = "Sailboat1",
                    Capacity = 5,
                    Description = "Sailboat1 description",
                    IdBoatStandard = 1,
                    Price = 100
                },
                new Sailboat
                {
                    IdSailboat = 2,
                    Name = "Sailboat2",
                    Capacity = 6,
                    Description = "Sailboat2 description",
                    IdBoatStandard = 2,
                    Price = 200
                },
                new Sailboat
                {
                    IdSailboat = 3,
                    Name = "Sailboat3",
                    Capacity = 7,
                    Description = "Sailboat3 description",
                    IdBoatStandard = 3,
                    Price = 300
                }
                );
            
            builder.ToTable("Sailboat");
        }
    }
}