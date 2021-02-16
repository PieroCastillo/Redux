using System;
using System.Collections.Generic;
using System.Text;

namespace Redux.Animators
{
    public class PointAnimator : Animator<Point>
    {
        static PointAnimator()
        {
            Animator<Point>.RegisterAnimator<PointAnimator>(new PointAnimator());
        }
    }
}
