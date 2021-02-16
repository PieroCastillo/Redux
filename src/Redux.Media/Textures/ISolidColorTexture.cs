using System;
using System.Collections.Generic;
using System.Text;

namespace Redux.Textures
{
    public interface ISolidColorTexture : ITexture
    {
        Color Color
        {
            get;
        }

        double Opacity
        {
            get;
        }
    }
}
