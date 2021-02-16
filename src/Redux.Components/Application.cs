using Redux.AppTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redux
{
    public class Application : ReduxObject
    {
        public Application()
        {
            OnLoadFinished();
        }

        public IApplicationType ApplicationType
        {
            get;
            private set;
        }

        protected virtual void OnLoadFinished()
        {

        }
    }
}
