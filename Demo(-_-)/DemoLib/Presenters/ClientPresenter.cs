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

        public void SearchClientsByPartialName(string searchText)
        {
            foreach (IClientView view in views_)
            {
                Client client = view.GetClientInfo();

                string clientNameToLower = client.Name.ToLower();
                string text = searchText.ToLower();

                if(clientNameToLower.Contains(text))
                {
                    view.ShowView();
                }
                else
                {
                    view.HideView();
                }
            }
        }

        /// Д.З. Реализация фильтрации по какому-либо полю клиента
        /// Задание на 5+++++++. Сортировка  по числу заказов!!!
    }
}
