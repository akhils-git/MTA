using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MTA
{
    class Program
    {
        //[ThreadStatic]
        static int indexVal = 0;
        static void Main(string[] args)
        {
            //Thread t1 = new Thread(new ThreadStart(ThreadMethod1));
            //t1.IsBackground = false;
            //t1.Start();


            //Thread t2 = new Thread(new ParameterizedThreadStart(ThreadMethod2));
            //t2.Start(10);

            //for (int i = 0; i < 4; i++)
            //{
            //    Console.WriteLine($"MainProc: {i}");
            //    Thread.Sleep(500);
            //}
            //t1.Join(1000);
            //t1.Abort();
            bool stopped = false;

          

            Thread t1 = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine($"T1 Running...{indexVal++}");
                    Thread.Sleep(500);
                }
            }));
            t1.Start();
            Thread t2 = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine($"T2 Running...{indexVal++}");
                    Thread.Sleep(500);
                }
            }));
            t2.Start();
            Console.WriteLine("Press any key to exit.");

         Console.ReadKey();
            stopped = true;

        }
        static void ThreadMethod2(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine($"ThreadProc2: {i}");
                //if (i==5)
                //{
                //    Thread.ResetAbort();
                //}
                Thread.Sleep(500);
            }
        }




        static void ThreadMethod1()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"ThreadProc: {i}");
                Thread.Sleep(500);
            }
        }
    }
}