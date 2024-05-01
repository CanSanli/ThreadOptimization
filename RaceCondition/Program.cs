using System;
using System.Threading;

namespace RaceCondition
{
    class Program
    {
        static int sayi = 0;
        static void Main(string[] args)
        {
            new Thread(() =>
            {
                for (int i = 0; i <1000000; i++)
                {
                    sayi += 1;
                }
            }).Start();

            new Thread(() =>
            {
                for (int i = 0; i < 100000000; i++)
                {
                    sayi += 1;
                }
            }).Start();

            Thread.Sleep(4000);
            Console.WriteLine(sayi);
            
        }
    }
}
