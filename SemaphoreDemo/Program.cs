using System;
using System.Threading;

namespace SemaphoreDemo
{
    class Program
    {
        public static Semaphore semaphore = new Semaphore(2,3);
        //public static SemaphoreSlim _semSlim = new SemaphoreSlim(2);
        public static int num = 0;

        static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                Thread threadObject = new Thread(DoSomeTask)
                {
                    Name = "Thread " + i
                };
                threadObject.Start(i);
            }
            

        }
        static void DoSomeTask(object id)
        {

            Console.WriteLine(Thread.CurrentThread.Name + " Wants to Enter into Critical Section for processing");
            try
            {
                //Blocks the current thread until the current WaitHandle receives a signal.   
                //_semSlim.Wait();
                semaphore.WaitOne();
                Console.WriteLine("Success: " + Thread.CurrentThread.Name + " is Doing its work");
                num++;
                Console.WriteLine($"sayi = {num}\n");
                Thread.Sleep(5000);
                Console.WriteLine(Thread.CurrentThread.Name + " Exit.");
            }
            finally
            {
                //Release() method to releage semaphore  

                 semaphore.Release();
               // _semSlim.Release();
            }
        }
    }
}
