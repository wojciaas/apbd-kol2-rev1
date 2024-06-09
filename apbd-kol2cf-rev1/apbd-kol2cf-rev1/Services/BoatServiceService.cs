using apbd_kol2cf_rev1.Entities;

namespace apbd_kol2cf_rev1.Services;

public class BoatServiceService : IBoatServiceService
{
    private readonly IClientService _clientService;

    public BoatServiceService(IClientService clientService)
    {
        _clientService = clientService;
    }

    public async Task<Client> GetClientByIdAsync(int id)
    {
        return await _clientService.GetClientByIdAsync(id);
    }
}