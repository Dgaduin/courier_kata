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

        [Fact]
        public void Parcel_with_0_height_should_throw_Argument_out_of_range()
        {
            Action a = () => new Parcel(0, 1, 1);
            a.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage("Value needs to be positive (Parameter 'height')");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-27)]
        [InlineData(-524)]
        public void Parcel_with_negative_width_should_throw_Argument_out_of_range(int width)
        {
            Action a = () => new Parcel(1, width, 1);
            a.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage("Value needs to be positive (Parameter 'width')");
        }

        [Fact]
        public void Parcel_with_0_width_should_throw_Argument_out_of_range()
        {
            Action a = () => new Parcel(1, 0, 1);
            a.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage("Value needs to be positive (Parameter 'width')");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-27)]
        [InlineData(-524)]
        public void Parcel_with_negative_length_should_throw_Argument_out_of_range(int length)
        {
            Action a = () => new Parcel(1, 1, length);
            a.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage("Value needs to be positive (Parameter 'length')");
        }

        [Fact]
        public void Parcel_with_0_length_should_throw_Argument_out_of_range()
        {
            Action a = () => new Parcel(1, 1, 0);
            a.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage("Value needs to be positive (Parameter 'length')");
        }

        [Theory]
        [InlineData(10, 150, 2)]
        [InlineData(140, 3, 45)]
        [InlineData(6, 75, 532)]
        [InlineData(10, 100, 2)]
        [InlineData(100, 3, 45)]
        [InlineData(6, 20, 100)]
        public void Parcel_with_a_dimension_over_or_equal_to_100_should_have_size_XL(int height, int width, int length)
        {
            var p = new Parcel(height, width, length);
            p.Size.Should().Be(ParcelSize.Xl);
        }


    }
}
