using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_kol2cf_rev1.Entities.Configs
{
    public class SailboatReservationEfConfig : IEntityTypeConfiguration<SailboatReservation>
    {
        public void Configure(EntityTypeBuilder<SailboatReservation> builder)
        {
            builder.HasKey(sbr => new { sbr.IdReservation, sbr.IdSailboat });
            builder.HasOne(sbr => sbr.ReservationNavigation)
                .WithMany(r => r.SailboatReservations)
                .HasForeignKey(sbr => sbr.IdReservation)
                .HasConstraintName("Sailboat_Reservation_Reservation")
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(sbr => sbr.SailboatNavigation)
                .WithMany(sb => sb.SailBoatReservations)
                .HasForeignKey(sbr => sbr.IdSailboat)
                .HasConstraintName("Sailboat_Reservation_Sailboat");

            builder.HasData(
                new SailboatReservation
                {
                    IdReservation = 1,
                    IdSailboat = 1
                },
                new SailboatReservation
                {
                    IdReservation = 2,
                    IdSailboat = 2
                },
                new SailboatReservation
                {
                    IdReservation = 3,
                    IdSailboat = 3
                }
                );
            
            builder.ToTable("Sailboat_Reservation");
        }
    }
}