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
            Action a = () => new Parcel(height, 1, 1, 1);
            a.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage("Value needs to be positive (Parameter 'height')");
        }

        [Fact]
        public void Parcel_with_0_height_should_throw_Argument_out_of_range()
        {
            Action a = () => new Parcel(0, 1, 1, 1);
            a.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage("Value needs to be positive (Parameter 'height')");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-27)]
        [InlineData(-524)]
        public void Parcel_with_negative_width_should_throw_Argument_out_of_range(int width)
        {
            Action a = () => new Parcel(1, width, 1, 1);
            a.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage("Value needs to be positive (Parameter 'width')");
        }

        [Fact]
        public void Parcel_with_0_width_should_throw_Argument_out_of_range()
        {
            Action a = () => new Parcel(1, 0, 1, 1);
            a.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage("Value needs to be positive (Parameter 'width')");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-27)]
        [InlineData(-524)]
        public void Parcel_with_negative_length_should_throw_Argument_out_of_range(int length)
        {
            Action a = () => new Parcel(1, 1, length, 1);
            a.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage("Value needs to be positive (Parameter 'length')");
        }

        [Fact]
        public void Parcel_with_0_length_should_throw_Argument_out_of_range()
        {
            Action a = () => new Parcel(1, 1, 0, 1);
            a.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage("Value needs to be positive (Parameter 'length')");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-27)]
        [InlineData(-524)]
        public void Parcel_with_negative_weight_should_throw_Argument_out_of_range(int weight)
        {
            Action a = () => new Parcel(1, 1, 1, weight);
            a.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage("Value needs to be positive (Parameter 'weight')");
        }

        [Fact]
        public void Parcel_with_0_weight_should_throw_Argument_out_of_range()
        {
            Action a = () => new Parcel(1, 1, 1, 0);
            a.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage("Value needs to be positive (Parameter 'weight')");
        }

        [Theory]
        [InlineData(10, 150, 2, 1)]
        [InlineData(140, 3, 45, 1)]
        [InlineData(6, 75, 532, 1)]
        [InlineData(10, 100, 2, 1)]
        [InlineData(100, 3, 45, 1)]
        [InlineData(6, 20, 100, 1)]
        public void Parcel_with_a_dimension_over_or_equal_to_100_should_have_size_XL(int height, int width, int length, int weight)
        {
            var p = new Parcel(height, width, length, weight);
            p.Size.Should().Be(ParcelSize.Xl);
        }

        [Theory]
        [InlineData(10, 150, 2, 1)]
        [InlineData(140, 3, 45, 1)]
        [InlineData(6, 75, 532, 1)]
        [InlineData(10, 100, 2, 1)]
        [InlineData(100, 3, 45, 1)]
        [InlineData(6, 20, 100, 1)]
        public void Parcel_with_size_XL_should_have_cost_of_25(int height, int width, int length, int weight)
        {
            var p = new Parcel(height, width, length, weight);
            using var scope = new AssertionScope();
            p.Size.Should().Be(ParcelSize.Xl);
            p.Cost.Should().Be(25);
        }

        [Theory]
        [InlineData(10, 74, 2, 1)]
        [InlineData(91, 3, 45, 1)]
        [InlineData(6, 23, 85, 1)]
        [InlineData(10, 99, 2, 1)]
        [InlineData(99, 3, 45, 1)]
        [InlineData(6, 20, 99, 1)]
        [InlineData(10, 50, 2, 1)]
        [InlineData(50, 3, 45, 1)]
        [InlineData(6, 20, 50, 1)]
        public void Parcel_with_a_dimension_between_50_and_99_should_have_size_L(int height, int width, int length, int weight)
        {
            var p = new Parcel(height, width, length, weight);
            p.Size.Should().Be(ParcelSize.L);
        }

        [Theory]
        [InlineData(10, 74, 2, 1)]
        [InlineData(91, 3, 45, 1)]
        [InlineData(6, 23, 85, 1)]
        [InlineData(10, 99, 2, 1)]
        [InlineData(99, 3, 45, 1)]
        [InlineData(6, 20, 99, 1)]
        [InlineData(10, 50, 2, 1)]
        [InlineData(50, 3, 45, 1)]
        [InlineData(6, 20, 50, 1)]
        public void Parcel_with_size_L_should_have_cost_of_15(int height, int width, int length, int weight)
        {
            var p = new Parcel(height, width, length, weight);
            using var scope = new AssertionScope();
            p.Size.Should().Be(ParcelSize.L);
            p.Cost.Should().Be(15);
        }

        [Theory]
        [InlineData(12, 4, 2, 1)]
        [InlineData(4, 34, 6, 1)]
        [InlineData(6, 6, 43, 1)]
        [InlineData(10, 4, 2, 1)]
        [InlineData(9, 3, 10, 1)]
        [InlineData(6, 10, 5, 1)]
        [InlineData(49, 5, 2, 1)]
        [InlineData(5, 49, 2, 1)]
        [InlineData(6, 4, 49, 1)]
        public void Parcel_with_a_dimension_between_10_and_49_should_have_size_M(int height, int width, int length, int weight)
        {
            var p = new Parcel(height, width, length, weight);
            p.Size.Should().Be(ParcelSize.M);
        }

        [Theory]
        [InlineData(12, 4, 2, 1)]
        [InlineData(4, 34, 6, 1)]
        [InlineData(6, 6, 43, 1)]
        [InlineData(10, 4, 2, 1)]
        [InlineData(9, 3, 10, 1)]
        [InlineData(6, 10, 5, 1)]
        [InlineData(49, 5, 2, 1)]
        [InlineData(5, 49, 2, 1)]
        [InlineData(6, 4, 49, 1)]
        public void Parcel_with_size_M_should_have_cost_of_8(int height, int width, int length, int weight)
        {
            var p = new Parcel(height, width, length, weight);
            using var scope = new AssertionScope();
            p.Size.Should().Be(ParcelSize.M);
            p.Cost.Should().Be(8);
        }

        [Theory]
        [InlineData(4, 4, 2, 1)]
        [InlineData(4, 6, 6, 1)]
        [InlineData(6, 6, 8, 1)]
        [InlineData(6, 4, 9, 1)]
        [InlineData(9, 3, 7, 1)]
        [InlineData(6, 9, 5, 1)]
        [InlineData(1, 5, 2, 1)]
        [InlineData(5, 1, 2, 1)]
        [InlineData(6, 4, 1, 1)]
        public void Parcel_with_a_dimension_below_10_should_have_size_S(int height, int width, int length, int weight)
        {
            var p = new Parcel(height, width, length, weight);
            p.Size.Should().Be(ParcelSize.S);
        }

        [Theory]
        [InlineData(4, 4, 2, 1)]
        [InlineData(4, 6, 6, 1)]
        [InlineData(6, 6, 8, 1)]
        [InlineData(6, 4, 9, 1)]
        [InlineData(9, 3, 7, 1)]
        [InlineData(6, 9, 5, 1)]
        [InlineData(1, 5, 2, 1)]
        [InlineData(5, 1, 2, 1)]
        [InlineData(6, 4, 1, 1)]
        public void Parcel_with_size_S_should_have_cost_of_3(int height, int width, int length, int weight)
        {
            var p = new Parcel(height, width, length, weight);
            using var scope = new AssertionScope();
            p.Size.Should().Be(ParcelSize.S);
            p.Cost.Should().Be(3);
        }

        [Theory]
        [InlineData(10, 150, 2, 12, 29, "it's an XL package with 2kg over the limit")]
        [InlineData(140, 3, 45, 16, 37, "it's an XL package with 6kg over the limit")]
        [InlineData(6, 75, 532, 11, 27, "it's an XL package with 1kg over the limit")]
        [InlineData(6, 75, 532, 7, 25, "it's an XL package with 1kg over the limit")]
        [InlineData(6, 23, 85, 7, 17, "it's an L package with 1kg over the limit")]
        [InlineData(10, 99, 2, 11, 25, "it's an L package with 5kg over the limit")]
        [InlineData(99, 3, 45, 9, 21, "it's an L package with 3kg over the limit")]
        [InlineData(12, 4, 2, 4, 10, "it's an M package with 1kg over the limit")]
        [InlineData(4, 34, 6, 6, 14, "it's an M package with 3kg over the limit")]
        [InlineData(6, 6, 43, 7, 16, "it's an M package with 4kg over the limit")]
        [InlineData(4, 6, 6, 2, 5, "it's an S package with 1kg over the limit")]
        [InlineData(6, 6, 8, 3, 7, "it's an S package with 2kg over the limit")]
        [InlineData(6, 4, 9, 4, 9, "it's an S package with 3kg over the limit")]
        public void Parcel_over_weight_limit_for_size_should_have_higher_cost(int height, int width, int length, int weight, int expected, string because)
        {
            var p = new Parcel(height, width, length, weight);

            p.Cost.Should().Be(expected, because);
        }
    }
}
