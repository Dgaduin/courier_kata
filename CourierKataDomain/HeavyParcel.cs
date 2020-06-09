using System;

namespace CourierKata.Domain
{
    public class HeavyParcel : IOrderItem
    {
        public OrderItemType Type { get { return OrderItemType.Parcel; } }
        public int Weight { get; }
        public int Cost { get; }

        public HeavyParcel(int weight)
        {
            if (weight <= 0) throw new ArgumentOutOfRangeException(nameof(weight), "Value needs to be positive");

            Weight = weight;
            Cost = 50;
            if (weight > 50)
                Cost += weight - 50; // We can just set the cost to the weight but this would make it harder if we have to change in the future
        }
    }
}
