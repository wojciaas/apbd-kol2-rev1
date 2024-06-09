using apbd_kol2cf_rev1.Entities;

namespace apbd_kol2cf_rev1.Services;

public interface IClientService
{
    public Task<Client> GetClientByIdAsync(int id);
}