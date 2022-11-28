using System;
using System.Threading;

namespace ThreadsLockAndSync
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var CuentaFamilia = new CuentaBancaria(2000);

            var hilosPersonas = new Thread[15];
           
            for (int i = 0; i < 15; i++)
            {
                var t = new Thread(CuentaFamilia.VamosRetirarEfectivo);

                t.Name = i.ToString();

                hilosPersonas[i] = t;
           }

            for (int i = 0; i < 15; i++)
            {
                hilosPersonas[i].Start();

                hilosPersonas[i].Join();
            }
        }
    }

    class CuentaBancaria
    {
        private object bloqueaSaldoPositivo = new object();
        double Saldo { get; set; }

        public CuentaBancaria(double saldo)
        {
            Saldo = saldo;
        }
        
        public void VamosRetirarEfectivo()
        {
            Console.WriteLine("Esta sacando dinero el hilo: " + Thread.CurrentThread.Name);

            for (int i = 0; i < 4; i++)
            {
                RetirarEfectivo(500);
            }
        }

        public double RetirarEfectivo(double cantidad)
        {
            if((Saldo - cantidad) < 0){

                Console.WriteLine($"Lo siento, queda {Saldo} euros en la cuenta. Hilo: {Thread.CurrentThread.Name}");
            }

            lock (bloqueaSaldoPositivo){
                if (Saldo >= cantidad)
                {
                    Console.WriteLine("Retirado {0} y quedan {1} en la cuenta. Retirado por el hilo {2}.", cantidad, (Saldo - cantidad), Thread.CurrentThread.Name);

                    Saldo -= cantidad;
                }

                return Saldo;
            }
        }
    }
}