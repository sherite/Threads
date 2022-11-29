using System;
using System.Threading;
using System.Threading.Tasks;

namespace DemoTaskPriorizada
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RealizarTodasTareas();
            
            Console.ReadLine();
        }

        static void RealizarTodasTareas()
        {
            var tarea1 = Task.Run(() =>
            {
                EjecutarTarea();
            });

            //tarea1.Wait();

            var tarea2 = Task.Run(() =>
            {
                EjecutarTarea2();
            });

            //Task.WaitAll(tarea1, tarea2);
            Task.WaitAny(tarea1, tarea2);
            
            //tarea2.Wait();

            var tarea3 = Task.Run(() =>
            {
                EjecutarTarea3();
            });
        }

        static void EjecutarTarea()
        {
            for (int i = 0; i < 5; i++)
            {
                var miThread = Thread.CurrentThread.ManagedThreadId;

                Thread.Sleep(1000);

                Console.WriteLine("Esta vuelta de bucle corresponde a la tarea 1");
            }
        }

        static void EjecutarTarea2()
        {
            for (int i = 0; i < 5; i++)
            {
                var miThread = Thread.CurrentThread.ManagedThreadId;

                Thread.Sleep(500);

                Console.WriteLine("Esta vuelta de bucle corresponde a la tarea 2");
            }
        }
        static void EjecutarTarea3()
        {
            for (int i = 0; i < 5; i++)
            {
                var miThread = Thread.CurrentThread.ManagedThreadId;

                Thread.Sleep(500);

                Console.WriteLine("Esta vuelta de bucle corresponde a la tarea 3");
            }
        }
    }
}
