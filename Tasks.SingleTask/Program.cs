using System;
using System.Threading;
using System.Threading.Tasks;

namespace DemoTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task tarea = new Task(EjecutarTarea); 
            
            tarea.Start();

            Task tarea2 = new Task(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    var miThread = Thread.CurrentThread.ManagedThreadId;

                    Thread.Sleep(1000);

                    Console.WriteLine("Esta vuelta de bucle corresponde al hilo: " + miThread + " ejecutandose desde el Main");
                }
            });

            tarea2.Start();


            Console.ReadLine();
        }

        static void EjecutarTarea()
        {
            for (int i = 0; i < 100; i++)
            {
                var miThread = Thread.CurrentThread.ManagedThreadId;

                Thread.Sleep(1000);

                Console.WriteLine("Esta vuelta de bucle corresponde al Thread: " + miThread);
            }
        }
    }
}
