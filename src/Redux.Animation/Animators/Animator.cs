using Redux.Animation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redux.Animators
{
    public abstract class Animator<T> : IReduxAnimator<T>
    {
        public virtual T Animate(float percentage, T oldvalue, T newvalue) => default;

        //sample
        //internal class IntAnimator : Animator<int>
        //{
        //    static IntAnimator()
        //    {
        //        Animator<int>.RegisterAnimator(new IntAnimator());
        //    }
        //}

        /// <summary>
        /// Register an Animator
        /// </summary>
        /// <typeparam name="TType">The Animated Type</typeparam>
        /// <param name="animator">The Initialized Animator</param>
        public static void RegisterAnimator<TType>(TType animator) where TType : Animator<T>
        {
            ReduxLocator.Current.RegisterService<TType>(animator);
        }
    }
}
