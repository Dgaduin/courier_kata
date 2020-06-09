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
            SumOrderItems();
        }

        private int SumOrderItems()
        {
            int value = Items.Sum(x => x.Cost);
            var discounts = ApplySmallParcelDiscounts(Items);
            if (SpeedyShipping)
            {
                Items.Add(new SpeedyShipping(value));
                value += value;
            }
            TotalCost = value;
            return value;
        }

        private IList<IOrderItem> ApplySmallParcelDiscounts(IList<IOrderItem> items)
        {
            // TODO get all the items that are small parcels - this will require a change in the OrderItemType enum to 
            // a more gradual type hierarchy and remove the ParcelSize enum
            // After that we need to sort by cost (desc), and group in groups of 4, adding a new return discount object
            // For each group we will flag each parcel as already used in a discount 
            // The ones not grouped will be left as is
            // We repeat this for medium parcel discount and mixed parcel discount (in this order) using the same method signature
            // This will give us 3 seprate colletions of discounts, which we will add to the Items collection before applying speedy shipping
            return new List<IOrderItem>();
        }

    }
}