using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redux.Animation
{
    public interface IReduxAnimator<T>
    {
        public T Animate(float percentage, T oldvalue, T newvalue);
    }
}
