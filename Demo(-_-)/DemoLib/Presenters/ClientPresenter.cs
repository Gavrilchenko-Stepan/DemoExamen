using DemoLib.Models;
using DemoLib.Views;
using System.Collections.Generic;

namespace DemoLib.Presenters
{
    public class ClientPresenter
    {
        private readonly IClientsModel model_;
        private readonly List<IClientView> views_ = new List<IClientView>();
        public ClientPresenter(IClientsModel model, List<IClientView> views)
        {
            model_ = model;
            views_ = views;

            List<Client> allClients = model_.ReadAllClients();

            if (views_.Count > 0)
            {
                for (int i = 0; i < allClients.Count; ++i)
                {
                    Client client = allClients[i];
                    views[i].ShowClientInfo(client);
                }
            }
        }
    }
}
