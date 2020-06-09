using System;
using System.Collections.Generic;
using CourierKata.Domain;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace CourierKata.Test
{
    public class HeavyParcelTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(-27)]
        [InlineData(-524)]
        public void HeavyParcel_with_negative_weight_should_throw_Argument_out_of_range(int weight)
        {
            Action a = () => new HeavyParcel(weight);
            a.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage("Value needs to be positive (Parameter 'weight')");
        }

        [Fact]
        public void HeavyParcel_with_0_weight_should_throw_Argument_out_of_range()
        {
            Action a = () => new HeavyParcel(0);
            a.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage("Value needs to be positive (Parameter 'weight')");
        }


        [Theory]
        [InlineData(5)]
        [InlineData(43)]
        [InlineData(50)]
        public void HeavyParcel_in_the_weight_limit_should_have_cost_of_50(int weight)
        {
            var parcel = new HeavyParcel(weight);

            parcel.Cost.Should().Be(50);
        }

        [Theory]
        [InlineData(54, 54)]
        [InlineData(67, 67)]
        [InlineData(90, 90)]
        public void HeavyParcel_over_the_weight_limit_should_have_cost_of_50_plus_penalty(int weight, int expected)
        {
            var parcel = new HeavyParcel(weight);

            parcel.Cost.Should().Be(expected);
        }
    }
}