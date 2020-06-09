namespace CourierKata.Domain
{
    public class SpeedyShipping : IOrderItem
    {
        public int Cost { get; }

        public OrderItemType Type { get { return OrderItemType.SeedyShipping; } }

        internal SpeedyShipping(int price)
        {
            Cost = price * 2;
        }
    }
}