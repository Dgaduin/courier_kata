using System.Collections.Generic;

namespace CourierKata.Domain
{
    public class Order
    {
        public IList<IOrderItem> Items { get; }
        public int TotalCost { get; private set; }
        public bool SpeedyShipping { get; }

        public Order(IList<IOrderItem> items, bool speedyShipping = false)
        {
            Items = items;
            SpeedyShipping = speedyShipping;
        }

        public int SumOrderItems()
        {
            int value = 0;
            TotalCost = 0;
            return value;
        }
    }
}