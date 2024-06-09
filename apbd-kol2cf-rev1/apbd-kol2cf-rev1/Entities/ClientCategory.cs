namespace apbd_kol2cf_rev1.Entities
{
    public class ClientCategory
    {
        public int IdClientCategory { get; set; }
        public string Name { get; set; } = null!;
        public int DiscountPerc { get; set; }
        public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
    }
}

