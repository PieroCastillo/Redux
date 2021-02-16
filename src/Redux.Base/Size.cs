using System;
using System.Collections.Generic;
using System.Text;

namespace Redux
{
    public struct Size
    {
        public Size(double equal) : this(equal, equal, equal)
        {

        }

        public Size(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get;
            private set;
        }

        public double Width 
        {
            get;
            private set;
        }

        public double Height
        {
            get;
            private set;
        }
    }
}
