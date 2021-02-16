using System;
using System.Collections.Generic;
using System.Text;

namespace Redux.Textures
{
    public class SolidColorTexture : ISolidColorTexture, ITexture
    {
        public SolidColorTexture(Color color, double opacity = 1)
        {
            Color = color;
            Opacity = opacity;
        }

        public Color Color
        {
            get;
            set;
        }

        public double Opacity
        {
            get;
            set;
        }
    }
}
