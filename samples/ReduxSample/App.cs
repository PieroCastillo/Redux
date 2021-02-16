using Redux;
using Redux.AppTypes;
using Redux.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReduxSample
{
    public class App : Application
    { 
        protected override void OnLoadFinished()
        {
            base.OnLoadFinished();

            if(ApplicationType is IDesktopApplicationType)
            {
                new Window();
            }
        }
    }
}
