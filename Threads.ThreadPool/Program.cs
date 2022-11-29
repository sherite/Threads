using System;
using System.Threading;

namespace DemoThreadPool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                ThreadPool.QueueUserWorkItem(EjecutarTarea,i);
            }

            Console.ReadLine();

        }

        static void EjecutarTarea(Object stateInfo)
        {
            var nTarea = (int)stateInfo;

            Console.WriteLine($"Thread nro: {Thread.CurrentThread.ManagedThreadId} ha comenzado la tarea " + nTarea);

            Thread.Sleep( 1000 );

            Console.WriteLine($"Thread nro: {Thread.CurrentThread.ManagedThreadId} ha terminado la tarea " + nTarea);
        }
    }
}
