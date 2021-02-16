using System;
using System.Collections.Generic;
using System.Text;

namespace Redux.Layouts
{
    public class Layoutable : ReduxAnimatable
    {
        public HitBox Bounds
        {
            get;
            private set;
        }

        public double Height
        {
            get;
            set;
        }

        public double Width
        {
            get;
            set;
        }
    }
}
