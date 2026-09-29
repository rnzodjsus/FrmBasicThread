using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Threading;

namespace FrmBasicThread
{
    internal class MyThreadClass
    {
        public static void Thread1()
        {
            // Loop that terminates the thread on the fifth attempt (0 to 5 inclusive)
            for (int loopCount = 0; loopCount <= 5; loopCount++)
            {
                // Suspend the current thread for 1.5 seconds (1500 milliseconds)
                Thread.Sleep(1500);

                Thread thread = Thread.CurrentThread;
                Console.WriteLine("Name of Thread: " + thread.Name + " = " + loopCount);
            }
        }
    }
}
