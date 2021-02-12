using System;
using System.Collections.Generic;
using Redux;

namespace LocatorSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ReduxLocator.Current
                .RegisterService("Hello World!")
                .RegisterService(new List<int>() { 1, 2, 3, 4 });

            Console.WriteLine($"{ReduxLocator.Current.GetService<string>()}");
            foreach (var s in ReduxLocator.Current.GetService<List<int>>())
            {
                Console.WriteLine($"{s}");
            }
        }
    }
}
