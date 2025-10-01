using System.Windows.Forms;
using DemoLib.Views;
using DemoLib;

namespace ClientCard
{
    public partial class ClientView: UserControl, IClientView
    {
        public ClientView()
        {
            InitializeComponent();
        }

        public void ShowClientInfo(Client client)
        {
            TitleLabel.Text = client.Name;
            DescriptionLabel.Text = client.Description;
            PhoneLabel.Text = client.Phone;
            MailLabel.Text = client.Mail;
            AvatarBox.Load(client.ImagePath);
        }
    }
}
