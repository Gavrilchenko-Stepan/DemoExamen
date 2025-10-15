namespace DemoLib
{
    public class Client
    {
        private int id_;
        public Order order = new Order();

        public string Name { get; set; }
        public string Description { get; set; }

        public string Phone { get; set; }

        public string Mail { get; set; }

        public string ImagePath { get; set; }

        public Client(int id)
        {
            id_ = id;
        }


    }
}
