using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redux.Threading
{
    public class ReduxThread
    {
        static ReduxThread()
        {
            Current = new ReduxThread();
        }

        private List<Thread> threads = new List<Thread>();

        private ReduxThread()
        {
            
        }

        public void Invoke(Action action)
        {
            var thr = new Thread(new ThreadStart(action));
            threads.Add(thr);
            thr.Start();
        }

        public async void InvokeAsync(Action action)
        {
            var thr = new Thread(new ThreadStart(action));
            threads.Add(thr);
            await new Task(() =>
            {
               thr.Start();
            });
        }

        public static ReduxThread Current
        {
            get;
        }
    }
}
