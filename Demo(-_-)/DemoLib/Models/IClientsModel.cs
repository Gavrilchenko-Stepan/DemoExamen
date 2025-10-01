using System.Collections.Generic;

namespace DemoLib.Models
{
    public interface IClientsModel
    {
        List<Client> ReadAllClients();

        int GetClientsCount();
    }
}
