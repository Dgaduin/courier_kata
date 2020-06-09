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
        }
    }
}
