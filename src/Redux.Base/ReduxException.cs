using System;
using System.Collections.Generic;
using System.Text;

namespace Redux
{
    public class ReduxException : Exception
    {
        public ReduxException()
        {

        }

        public ReduxException(string msg) : base(msg)
        {

        }

        public ReduxException(string msg, Exception exception) : base(msg, exception)
        {

        }
    }
}
