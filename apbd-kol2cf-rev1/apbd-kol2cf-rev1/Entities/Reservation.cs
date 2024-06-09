namespace apbd_kol2cf_rev1.Entities
{
    public class Reservation
    {
        public int IdReservation { get; set; }
        public int IdClient { get; set; }
        public virtual Client ClientNavigation { get; set; } = null!;
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int IdBoatStandard { get; set; }
        public virtual BoatStandard BoatStandardNavigation { get; set; } = null!;
        public int Capacity { get; set; }
        public int NumOfBoats { get; set; }
        public bool Fullfilled { get; set; }
        public decimal? Price { get; set; }
        public string? CancelReason { get; set; }

        public virtual ICollection<SailboatReservation> SailboatReservations { get; set; } =
            new List<SailboatReservation>();
    }
}