using apbd_kol2cf_rev1.Entities;

namespace apbd_kol2cf_rev1.Repositories;

public interface IClientRepository
{
    public Task<Client?> GetClientByIdAsync(int id);
}