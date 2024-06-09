namespace apbd_kol2cf_rev1.Entities
{
    public class SailboatReservation
    {
        public int IdSailboat { get; set; }
        public virtual Sailboat SailboatNavigation { get; set; } = null!;
        public int IdReservation { get; set; }
        public virtual Reservation ReservationNavigation { get; set; } = null!;
    }
}