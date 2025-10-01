using ClientCard;
using DemoLib.Models;
using DemoLib.Presenters;
using DemoLib.Views;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DemoProject
{
    public partial class MainForm : Form
    {
        private ClientPresenter presenter_;
        public MainForm()
        {
            InitializeComponent();

            MemoryClientsModel model = new MemoryClientsModel();

            /// Д.З Сделать нормальный вид карточек
            List<IClientView> cards = new List<IClientView>();
            for (int i = 0; i < model.GetClientsCount(); i++)
            {
                ClientView card = new ClientView(); /// наклепали пустую карточку
                ClientsLayout.Controls.Add(card); /// добавляем карточку на главную форму в layout
                cards.Add(card); 
            }

            presenter_ = new ClientPresenter(new MemoryClientsModel(), cards);
        }
    }
}
