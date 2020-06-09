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
            if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height),"Value needs to be positive");
            if (width <= 0) throw new ArgumentOutOfRangeException(nameof(width),"Value needs to be positive");
            if (length <= 0) throw new ArgumentOutOfRangeException(nameof(length),"Value needs to be positive");

            Height=height;
            Width=width;
            Length=length;
        }
    }
}
