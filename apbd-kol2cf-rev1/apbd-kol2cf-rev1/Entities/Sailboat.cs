namespace apbd_kol2cf_rev1.Entities
{
    public class Sailboat
    {
        public int IdSailboat { get; set; }
        public string Name { get; set; } = null!;
        public int Capacity { get; set; }
        public string Description { get; set; } = null!;
        public int IdBoatStandard { get; set; }
        public virtual BoatStandard BoatStandardNavigation { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual ICollection<SailboatReservation> SailBoatReservations { get; set; } =
            new List<SailboatReservation>();
    }
}