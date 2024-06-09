namespace apbd_kol2cf_rev1.Entities
{
    public class BoatStandard
    {
        public int IdBoatStandard { get; set; }
        public string Name { get; set; } = null!;
        public int Level { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public virtual ICollection<Sailboat> Sailboats { get; set; } = new List<Sailboat>();
    }
}