using DemoLib.Models;
using DemoLib.Views;
using System.Collections.Generic;
using System.Linq;

namespace DemoLib.Presenters
{
    public class ClientPresenter
    {
        private readonly IClientsModel model_;
        private readonly List<IClientView> views_ = new List<IClientView>();
        private List<Client> allClients_;
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

                if (clientNameToLower.Contains(text))
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
        public void FilterClientsByEmail(string searchText)
        {
            foreach (IClientView view in views_)
            {
                Client client = view.GetClientInfo();

                string clientEmail = client.Mail.ToLower();
                string text = searchText.ToLower();

                if (clientEmail.Contains(text))
                {
                    view.ShowView();
                }
                else
                {
                    view.HideView();
                }
            }
        }
        /// Задание на 5+++++++. Сортировка  по числу заказов!!!
        public void SortClientsByOrderCount()
        {
            if (allClients_ == null || allClients_.Count == 0) return;

            for (int i = 0; i < allClients_.Count - 1; i++)
            {
                for (int j = i + 1; j < allClients_.Count; j++)
                {
                    int count1 = allClients_[i].order.GetRecords().Count;
                    int count2 = allClients_[j].order.GetRecords().Count;

                    // Если у j больше заказов чем у i - меняем местами
                    if (count2 > count1)
                    {
                        Client temp = allClients_[i];
                        allClients_[i] = allClients_[j];
                        allClients_[j] = temp;
                    }
                }
            }

            for (int i = 0; i < views_.Count && i < allClients_.Count; i++)
            {
                views_[i].ShowClientInfo(allClients_[i]);
                views_[i].ShowView();
            }
        }

    }
}
