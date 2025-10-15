using System.Collections.Generic;

namespace DemoLib
{
    public class Order
    {
        private List<OrderRecord> records_ = new List<OrderRecord>();

        public void AddRecord(OrderRecord record)
        {
            records_.Add(record);
        }

        public List<OrderRecord> GetRecords()
        {
            return records_;
        }
    }
}
