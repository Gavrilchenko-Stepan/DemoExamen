namespace DemoLib.Views
{
    public interface IClientView
    {
        void ShowClientInfo(Client client);

        Client GetClientInfo();

        void ShowView();
        void HideView();
    }
}
