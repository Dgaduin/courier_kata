using System;
using CourierKata.Domain;
using FluentAssertions;
using FluentAssertions.Execution;
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

        [Theory]
        [InlineData(10, 150, 2)]
        [InlineData(140, 3, 45)]
        [InlineData(6, 75, 532)]
        [InlineData(10, 100, 2)]
        [InlineData(100, 3, 45)]
        [InlineData(6, 20, 100)]
        public void Parcel_with_size_XL_should_have_cost_of_25(int height, int width, int length)
        {
            var p = new Parcel(height, width, length);
            using var scope = new AssertionScope();
            p.Size.Should().Be(ParcelSize.Xl);
            p.Cost.Should().Be(25);
        }

        [Theory]
        [InlineData(10, 74, 2)]
        [InlineData(91, 3, 45)]
        [InlineData(6, 23, 85)]
        [InlineData(10, 99, 2)]
        [InlineData(99, 3, 45)]
        [InlineData(6, 20, 99)]
        [InlineData(10, 50, 2)]
        [InlineData(50, 3, 45)]
        [InlineData(6, 20, 50)]
        public void Parcel_with_a_dimension_between_50_and_99_should_have_size_L(int height, int width, int length)
        {
            var p = new Parcel(height, width, length);
            p.Size.Should().Be(ParcelSize.L);
        }

        [Theory]
        [InlineData(10, 74, 2)]
        [InlineData(91, 3, 45)]
        [InlineData(6, 23, 85)]
        [InlineData(10, 99, 2)]
        [InlineData(99, 3, 45)]
        [InlineData(6, 20, 99)]
        [InlineData(10, 50, 2)]
        [InlineData(50, 3, 45)]
        [InlineData(6, 20, 50)]
        public void Parcel_with_size_L_should_have_cost_of_15(int height, int width, int length)
        {
            var p = new Parcel(height, width, length);
            using var scope = new AssertionScope();
            p.Size.Should().Be(ParcelSize.L);
            p.Cost.Should().Be(15);
        }

        [Theory]
        [InlineData(12, 4, 2)]
        [InlineData(4, 34, 6)]
        [InlineData(6, 6, 43)]
        [InlineData(10, 4, 2)]
        [InlineData(9, 3, 10)]
        [InlineData(6, 10, 5)]
        [InlineData(49, 5, 2)]
        [InlineData(5, 49, 2)]
        [InlineData(6, 4, 49)]
        public void Parcel_with_a_dimension_between_10_and_49_should_have_size_M(int height, int width, int length)
        {
            var p = new Parcel(height, width, length);
            p.Size.Should().Be(ParcelSize.M);
        }

        [Theory]
        [InlineData(12, 4, 2)]
        [InlineData(4, 34, 6)]
        [InlineData(6, 6, 43)]
        [InlineData(10, 4, 2)]
        [InlineData(9, 3, 10)]
        [InlineData(6, 10, 5)]
        [InlineData(49, 5, 2)]
        [InlineData(5, 49, 2)]
        [InlineData(6, 4, 49)]
        public void Parcel_with_size_M_should_have_cost_of_8(int height, int width, int length)
        {
            var p = new Parcel(height, width, length);
            using var scope = new AssertionScope();
            p.Size.Should().Be(ParcelSize.M);
            p.Cost.Should().Be(8);
        }

        [Theory]
        [InlineData(4, 4, 2)]
        [InlineData(4, 6, 6)]
        [InlineData(6, 6, 8)]
        [InlineData(6, 4, 9)]
        [InlineData(9, 3, 7)]
        [InlineData(6, 9, 5)]
        [InlineData(1, 5, 2)]
        [InlineData(5, 1, 2)]
        [InlineData(6, 4, 1)]
        public void Parcel_with_a_dimension_below_10_should_have_size_S(int height, int width, int length)
        {
            var p = new Parcel(height, width, length);
            p.Size.Should().Be(ParcelSize.S);
        }

        [Theory]
        [InlineData(4, 4, 2)]
        [InlineData(4, 6, 6)]
        [InlineData(6, 6, 8)]
        [InlineData(6, 4, 9)]
        [InlineData(9, 3, 7)]
        [InlineData(6, 9, 5)]
        [InlineData(1, 5, 2)]
        [InlineData(5, 1, 2)]
        [InlineData(6, 4, 1)]
        public void Parcel_with_size_S_should_have_cost_of_3(int height, int width, int length)
        {
            var p = new Parcel(height, width, length);
            using var scope = new AssertionScope();
            p.Size.Should().Be(ParcelSize.S);
            p.Cost.Should().Be(3);
        }
    }
}
