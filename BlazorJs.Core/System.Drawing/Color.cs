using System;
using System.Collections.Generic;
using System.Text;

namespace System.Drawing
{
    public readonly struct Color : IEquatable<Color>
    {
        public Color(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public byte R { get; }
        public byte G { get; }
        public byte B { get; }
        public byte A { get; }

        public static Color FromArgb(int alpha, int red, int green, int blue)
        {
            return new Color((byte)red, (byte)green, (byte)blue, (byte)alpha);
        }
        public static Color FromArgb(int red, int green, int blue)
        {
            return new Color((byte)red, (byte)green, (byte)blue, (byte)255);
        }

        public bool Equals(Color other)
        {
            return A == other.A && R == other.R && G == other.G && B == other.B;
        }

        public float GetBrightness() { throw new NotImplementedException(); }
        public float GetHue() { throw new NotImplementedException(); }
        public float GetSaturation() { throw new NotImplementedException(); }
        public int ToArgb() { throw new NotImplementedException(); }

    }
}
