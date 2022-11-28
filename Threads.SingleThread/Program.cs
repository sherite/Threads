using System;
using System.Threading;

namespace SingleThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t = new Thread(MetodoSaludo);
            t.Start();
            t.Join();

            
            Console.WriteLine("Hola desde el hilo 1!");
            Thread.Sleep(500);
            Console.WriteLine("Hola desde el hilo 1!");
            Thread.Sleep(500);
            Console.WriteLine("Hola desde el hilo 1!");
            Thread.Sleep(500);
            Console.WriteLine("Hola desde el hilo 1!");
            Thread.Sleep(500);
            Console.WriteLine("Hola desde el hilo 1!");
        }

        static void MetodoSaludo()
        {
            
            Console.WriteLine("Hola desde el hilo 2!");
            Thread.Sleep(500);                    
            Console.WriteLine("Hola desde el hilo 2!");
            Thread.Sleep(500);                    
            Console.WriteLine("Hola desde el hilo 2!");
            Thread.Sleep(500);                    
            Console.WriteLine("Hola desde el hilo 2!");
            Thread.Sleep(500);                    
            Console.WriteLine("Hola desde el hilo 2!");

        }
    }
}
