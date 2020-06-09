using System.Collections.Generic;
using System.Linq;

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
            int value = Items.Sum(x => x.Cost);
            if (SpeedyShipping)
            {
                Items.Add(new SpeedyShipping(value));
                value += value;
            }
            TotalCost = value;
            return value;
        }
    }
}