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
    }
}