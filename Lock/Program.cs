using System;
using System.Threading;

namespace Lock
{
    class Program
    {
        static int x = 0;

        static void Main(string[] args)
        {
            object lock1 = new object();
            object lock2 = new object();

            
            new Thread(() =>
            {
                lock (lock1)
                {
                    Thread.Sleep(100);
                    lock (lock2)
                    {
                        Console.WriteLine("finished thread 1");
                    }
                }

            }).Start();

            new Thread(() =>
            {
                lock (lock2)  //deadlock
                {

                    Thread.Sleep(100);

                    lock (lock1)
                    {
                        Console.WriteLine("Finished thread 2");
                    }
                }

            }).Start();


        }
    }
}
