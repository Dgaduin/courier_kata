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
        }
    }
}
