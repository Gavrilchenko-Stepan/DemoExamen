using DemoLib;
using DemoLib.Models;
using DemoLib.Presenters;
using DemoLib.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace DemoTesting
{
    [TestClass]
    public class TClientPresenter
    {
        [TestMethod]
        public void TestConstruct()
        {
            List<Client> testClients = new List<Client>();

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

            Client c3 = new Client(3);
            c3.Name = "Еще какая-то абвгдейка";
            c3.Description = "Это непонятно кто";
            c3.Phone = "666";
            c3.Mail = "777@sobaka.ru";
            c3.ImagePath = "../../../Resources/img/abc.jpg";

            testClients.Add(c1);
            testClients.Add(c2);
            testClients.Add(c3);

            var mockModel = new Mock<IClientsModel>(); /// фейковая модель
            var mockViews = new List<IClientView>(); /// фейковые представления

            int countClients = testClients.Count;
            mockModel
                .Setup(m => m.GetClientsCount())
                .Returns(countClients);

            mockModel
                .Setup(m => m.ReadAllClients())
                .Returns(testClients);

            for (int clientId = 0; clientId < countClients; ++clientId)
            {
                Client client = testClients[clientId];
                Mock<IClientView> view = new Mock<IClientView>();

                ///Д.З. сделать проверку Verify
                view.Setup(v => v.ShowClientInfo(client));
                mockViews.Add(view.Object);
            }
            var clientPresenter = new ClientPresenter(mockModel.Object, mockViews);
        }
    }
}
