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
        // TODO: Convert to theory and add more cases 
        [Fact]
        public void Order_should_sum_the_parcels_in_it()
        {
            IList<IOrderItem> items = new List<IOrderItem> {
                new Parcel(10, 150, 2,1), //XL
                new Parcel(10, 74, 2,1), //L
                new Parcel(12, 4, 2,1), //M
                new Parcel(4, 4, 2,1) //S
            };
            var order = new Order(items);

            order.SumOrderItems();

            order.TotalCost.Should().Be(51, "25+15+8+3=51");
        }

        [Fact]
        public void Speedy_shipping_should_be_twice_the_sum_of_the_parcels_and_half_of_the_total()
        {
            IList<IOrderItem> items = new List<IOrderItem> {
                new Parcel(10, 150, 2,1), //XL
                new Parcel(10, 74, 2,1), //L
                new Parcel(12, 4, 2,1), //M
                new Parcel(4, 4, 2,1) //S
            };
            var order = new Order(items, true);

            order.SumOrderItems();

            using var scope = new AssertionScope();
            order.TotalCost.Should().Be(102, "(25+15+8+3)*2=102");
            order.Items.Should().HaveCount(5, "there are 4 parcels + speedy shiping");
        }
    }
}