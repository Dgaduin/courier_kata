namespace CourierKata.Domain
{
    public interface IOrderItem
    {
        int Cost { get; }
        OrderItemType Type { get; }
    }
}
