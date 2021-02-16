using System;
using System.Collections.Generic;
using System.Text;
using Redux;

namespace Redux
{
    public sealed class Color
    {
        public Color(byte a, byte r, byte g, byte b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }

        public byte A
        {
            get;
            private set;
        }

        public byte R
        {
            get;
            private set;
        }

        public byte G
        {
            get;
            private set;
        }

        public byte B
        {
            get;
            private set;
        }

        public static Color FromRGB(byte r, byte g, byte b) => new Color(255, r, g, b);
        public static Color FromARGB(byte a, byte r, byte g, byte b) => new Color(a, r, g, b);
    }
}
