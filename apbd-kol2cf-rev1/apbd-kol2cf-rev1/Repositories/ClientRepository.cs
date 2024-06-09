using apbd_kol2cf_rev1.Context;
using apbd_kol2cf_rev1.Entities;
using Microsoft.EntityFrameworkCore;

namespace apbd_kol2cf_rev1.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly BoatServiceDbContext _dbContext;

    public ClientRepository(BoatServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Client?> GetClientByIdAsync(int id)
    {
        return await _dbContext.Clients
            .Include(c => c.Reservations)
            .FirstOrDefaultAsync(c => c.IdClient == id);
    }
}