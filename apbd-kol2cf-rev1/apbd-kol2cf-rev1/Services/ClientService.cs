using apbd_kol2cf_rev1.Context;
using apbd_kol2cf_rev1.Entities;
using apbd_kol2cf_rev1.Exceptions;
using apbd_kol2cf_rev1.Repositories;

namespace apbd_kol2cf_rev1.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<Client> GetClientByIdAsync(int id)
    {
        Client? client = await _clientRepository.GetClientByIdAsync(id);
        EnsureClientExists(client, id);
        return client!;
    }

    private void EnsureClientExists(Client? client, int id)
    {
        if (client == null)
        {
            throw new DomainException($"Client with id={id} does not exists.");
        }
    }
}