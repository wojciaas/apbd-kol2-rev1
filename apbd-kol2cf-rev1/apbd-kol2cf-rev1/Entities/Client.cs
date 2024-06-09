namespace apbd_kol2cf_rev1.Entities
{
    public class Client
    {
        public int IdClient { get; set; }
        public string Name { get; set; } = null!;   
        public string LastName { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public string Pesel { get; set; } = null!;   
        public string Email { get; set; } = null!;
        public int IdClientCategory { get; set; }
        public virtual ClientCategory ClientCategoryNavigation { get; set; } = null!;
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}

