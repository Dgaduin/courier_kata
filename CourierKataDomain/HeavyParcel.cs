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

        }
    }
}
