using apbd_kol2cf_rev1.Entities;
using Microsoft.EntityFrameworkCore;

namespace apbd_kol2cf_rev1.Context;

public class BoatServiceDbContext : DbContext
{
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<BoatStandard> BoatStandards { get; set; }
    public virtual DbSet<ClientCategory> ClientCategories { get; set; }
    public virtual DbSet<Reservation> Reservations { get; set; }
    public virtual DbSet<Sailboat> Sailboats { get; set; }
    public virtual DbSet<SailboatReservation> SailboatReservations { get; set; }
    
    protected BoatServiceDbContext()
    {
    }

    public BoatServiceDbContext(DbContextOptions<BoatServiceDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BoatServiceDbContext).Assembly);
    }
}