using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_kol2cf_rev1.Entities.Configs
{
    public class ReservationEfConfig : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(r => r.IdReservation);
            builder.Property(r => r.IdReservation).ValueGeneratedNever();
            builder.HasOne(r => r.ClientNavigation)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.IdClient)
                .HasConstraintName("Client_Reservation")
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(r => r.DateFrom).HasColumnType("datetime").IsRequired();
            builder.Property(r => r.DateTo).HasColumnType("datetime").IsRequired();
            builder.HasOne(r => r.BoatStandardNavigation)
                .WithMany(bs => bs.Reservations)
                .HasForeignKey(r => r.IdBoatStandard)
                .HasConstraintName("BoatStandard_Reservation")
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(r => r.Capacity).IsRequired();
            builder.Property(r => r.NumOfBoats).IsRequired();
            builder.Property(r => r.Fullfilled).HasColumnType("bit").IsRequired();
            builder.Property(r => r.Price).HasColumnType("money");
            builder.Property(r => r.CancelReason).HasMaxLength(200);

            builder.HasData(
                new Reservation
                {
                    IdReservation = 1,
                    IdClient = 1,
                    DateFrom = new DateTime(2021, 6, 1, 12, 0, 0),
                    DateTo = new DateTime(2021, 6, 1, 14, 0, 0),
                    IdBoatStandard = 1,
                    Capacity = 2,
                    NumOfBoats = 1,
                    Fullfilled = true,
                    Price = 100,
                    CancelReason = null
                },
                new Reservation
                {
                    IdReservation = 2,
                    IdClient = 2,
                    DateFrom = new DateTime(2021, 6, 2, 12, 0, 0),
                    DateTo = new DateTime(2021, 6, 2, 14, 0, 0),
                    IdBoatStandard = 2,
                    Capacity = 4,
                    NumOfBoats = 1,
                    Fullfilled = true,
                    Price = 200,
                    CancelReason = null
                },
                new Reservation
                {
                    IdReservation = 3,
                    IdClient = 3,
                    DateFrom = new DateTime(2021, 6, 3, 12, 0, 0),
                    DateTo = new DateTime(2021, 6, 3, 14, 0, 0),
                    IdBoatStandard = 3,
                    Capacity = 6,
                    NumOfBoats = 1,
                    Fullfilled = true,
                    Price = 300,
                    CancelReason = null
                }
                );
            
            builder.ToTable("Reservation");
        }
    }
}