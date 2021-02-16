using System;
using System.Collections.Generic;
using System.Text;

namespace Redux
{
    public struct HitBox
    {
        public HitBox(Size size, Point position)
        {
            Size = size;
            Position = position;
        }

        public Size Size
        {
            get;
            private set;
        }

        public Point Position
        {
            get;
            private set;
        }
    }
}
