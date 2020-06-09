using System;
using CourierKata.Domain;
using FluentAssertions;
using Xunit;

namespace CourierKata.Test
{
    public class ParcelTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(-27)]
        [InlineData(-524)]
        public void Parcel_with_negative_height_should_throw_Argument_out_of_range(int height)
        {
            Action a = () => new Parcel(height, 1, 1);
            a.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage("Value needs to be positive (Parameter 'height')");
        }        
    }
}
