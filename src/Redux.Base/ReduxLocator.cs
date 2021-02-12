using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Redux
{
    public class ReduxLocator : IReduxResolver
    {
        static ReduxLocator()
        {
            Current = new ReduxLocator();
        }

        private ReduxLocator()
        {

        }

        private Dictionary<object, object> serviceCache = new Dictionary<object, object>();

        /// <inheritdoc/>
        public T? GetService<T>() where T : class
        {
            if (serviceCache.Keys.Contains(typeof(T)))
            {
                return (T)serviceCache[typeof(T)];
            }
            else
            {
                return null;
            }
        }

        /// <inheritdoc/>
        public IReduxResolver RegisterService<T>(T service) where T : class
        {
            if (serviceCache.Keys.Contains(typeof(T)))
            {
                throw new ReduxException("The Service is already registered");
            }
            else
            {
                serviceCache.Add(typeof(T), service);
                return this;
            }
        }       
        
        #region Properties
        public static IReduxResolver Current
        {
            get;
            private set;
        }
        #endregion
    }
}
