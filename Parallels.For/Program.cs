using System;
using System.Threading;
using System.Threading.Tasks;

namespace DemoParallel
{
    internal class Program
    {
        private static int acumulador = 0;

        static void Main(string[] args)
        {
            Parallel.For(0, 100, dato =>
            {
                Console.WriteLine($"Acumulador vale {acumulador}. Tarea informada por el hilo {Thread.CurrentThread.ManagedThreadId}");

                if ((acumulador % 2) == 0)
                {
                    acumulador += dato;

                    Thread.Sleep(100);
                }
                else
                {
                    acumulador -= dato;

                    Thread.Sleep(100);
                }
            });
        }       
    }
}
