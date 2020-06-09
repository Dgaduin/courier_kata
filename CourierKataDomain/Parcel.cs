using System;

namespace CourierKata.Domain
{
    public class Parcel : IOrderItem
    {
        public OrderItemType Type { get { return OrderItemType.Parcel; } }
        public int Height { get; }
        public int Width { get; }
        public int Length { get; }
        public int Weight { get; }
        public ParcelSize Size { get; }
        public int Cost { get; }

        public Parcel(int height, int width, int length, int weight)
        {
            if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height), "Value needs to be positive");
            if (width <= 0) throw new ArgumentOutOfRangeException(nameof(width), "Value needs to be positive");
            if (length <= 0) throw new ArgumentOutOfRangeException(nameof(length), "Value needs to be positive");
            if (weight <= 0) throw new ArgumentOutOfRangeException(nameof(weight), "Value needs to be positive");

            Height = height;
            Width = width;
            Length = length;
            Weight = weight;

            int cost = 0;

            if (Height >= 100 || Width >= 100 || Length >= 100)
            {
                Size = ParcelSize.Xl;
                cost = 25;
                if (Weight > WeightLimits.XL)
                    cost += (Weight - WeightLimits.XL) * 2;
            }
            else if (Height >= 50 || Width >= 50 || Length >= 50)
            {
                Size = ParcelSize.L;
                cost = 15;
                if (Weight > WeightLimits.L)
                    cost += (Weight - WeightLimits.L) * 2;
            }
            else if (Height >= 10 || Width >= 10 || Length >= 10)
            {
                Size = ParcelSize.M;
                cost = 8;
                if (Weight > WeightLimits.M)
                    cost += (Weight - WeightLimits.M) * 2;
            }
            else if (Height >= 1 || Width >= 1 || Length >= 1)
            {
                Size = ParcelSize.S;
                cost = 3;
                if (Weight > WeightLimits.S)
                    cost += (Weight - WeightLimits.S) * 2;
            }
            Cost = cost;

        }
    }
}
