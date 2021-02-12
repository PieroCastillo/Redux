using System;
using System.Collections.Generic;
using System.Text;

namespace Redux
{
    public interface IReduxResolver
    {
        /// <summary>
        /// Gets a service.
        /// </summary>
        /// <typeparam name="T">The Type of the service.</typeparam>
        /// <returns>The service to return.</returns>
        public T? GetService<T>() where T : class;
        /// <summary>
        /// Register a service.
        /// </summary>
        /// <typeparam name="T">The type of the service.</typeparam>
        /// <param name="service">The initialized object to register.</param>
        public IReduxResolver RegisterService<T>(T service) where T : class;
    }
}
