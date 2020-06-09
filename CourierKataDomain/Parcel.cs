using System;

namespace CourierKata.Domain
{
    public class Parcel : IOrderItem
    {
        public OrderItemType Type { get { return OrderItemType.Parcel; } }
        public int Height { get; }
        public int Width { get; }
        public int Length { get; }

        public Parcel(int height, int width, int length)
        {
            if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height), "Value needs to be positive");
            if (width <= 0) throw new ArgumentOutOfRangeException(nameof(width), "Value needs to be positive");
            if (length <= 0) throw new ArgumentOutOfRangeException(nameof(length), "Value needs to be positive");

            Height = height;
            Width = width;
            Length = length;
        }

        public ParcelSize Size
        {
            get
            {
                if (Height >= 100 || Width >= 100 || Length >= 100)
                    return ParcelSize.Xl;
                if (Height >= 50 || Width >= 50 || Length >= 50)
                    return ParcelSize.L;
                if (Height >= 10 || Width >= 10 || Length >= 10)
                    return ParcelSize.M;
                if (Height >= 1 || Width >= 1 || Length >= 1)
                    return ParcelSize.S;

                return ParcelSize.Invalid;
            }
        }

        public int Cost
        {
            get
            {
                if (Size == ParcelSize.Xl)
                    return 25;
                if (Size == ParcelSize.L)
                    return 15;
                if (Size == ParcelSize.M)
                    return 8;
                if (Size == ParcelSize.S)
                    return 3;
                return -1;
            }
        }
    }
}
