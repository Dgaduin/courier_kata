using System;
using System.Collections.Generic;
using CourierKata.Domain;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace CourierKata.Test
{
    public class OrderTests
    {
        [Fact]
        public void Order_should_sum_the_parcels_in_it()
        {
            IList<IOrderItem> items = new List<IOrderItem> {
                new Parcel(10, 150, 2), //XL
                new Parcel(10, 74, 2), //L
                new Parcel(12, 4, 2), //M
                new Parcel(4, 4, 2) //S
            };
            var order = new Order(items);
            order.SumOrderItems();
            order.TotalCost.Should().Be(51, "25+15+8+3=51");
        }
    }
}