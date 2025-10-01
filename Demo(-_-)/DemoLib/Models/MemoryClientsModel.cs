using System.Collections.Generic;

namespace DemoLib.Models
{
    public class MemoryClientsModel : IClientsModel
    {
        private List<Client> allClients_ = new List<Client>();  

        public MemoryClientsModel()
        {
            Client c1 = new Client(1);
            c1.Name = "Просто Валера";
            c1.Description = "Это самый совершенный клиент из всех возможных";
            c1.Phone = "777";
            c1.Mail = "666@sobaka.ru";
            c1.ImagePath = "../../../Resources/img/Valera.jpg";


            Client c2 = new Client(2);
            c2.Name = "ОАО ЕПРСТЕЙКА";
            c2.Description = "Похуже, чем Валера";
            c2.Phone = "666";
            c2.Mail = "777@sobaka.ru";
            c2.ImagePath = "../../../Resources/img/prsteyka.jpg";

            allClients_.Add(c1);
            allClients_.Add(c2);
        }
        public List<Client> ReadAllClients()
        {
            return allClients_;
        }

        public int GetClientsCount()
        {
            return allClients_.Count;
        }
    }
}
