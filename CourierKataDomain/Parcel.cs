using System;

namespace CourierKata.Domain
{
    public class Parcel
    {
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
                return ParcelSize.Invalid;
            }
        }
    }

    public enum ParcelSize
    {
        Invalid = 1,
        S = 2,
        M = 3,
        L = 4,
        Xl = 5
    }
}
