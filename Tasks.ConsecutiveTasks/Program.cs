using System;
using System.Threading.Tasks;
using System.Threading;

namespace DemoTaskConsecutiva
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tarea = Task.Run(() => EjecutarTarea());

            var tarea2 = tarea.ContinueWith(EjecutarOtraTarea);

            Console.ReadLine();
        }

        static void EjecutarTarea()
        {
            for (int i = 0; i < 10; i++)
            {
                var miThread = Thread.CurrentThread.ManagedThreadId;

                Thread.Sleep(1000);

                Console.WriteLine("Esta vuelta de bucle corresponde al Thread: " + miThread);
            }
        }

        static void EjecutarOtraTarea(Task obj)
        {
            for (int i = 0; i < 10; i++)
            {
                var miThread = Thread.CurrentThread.ManagedThreadId;

                Thread.Sleep(1000);

                Console.WriteLine("Esto es otra tarea y esta vuelta de bucle corresponde al Thread: " + miThread);
            }
        }
    }
}