using DXC_Fibonacci.Services;
using System;

namespace DXC_Fibonacci
{
    public class Program
    {
        static void Main(string[] args)
        {
            FibonacciService fs = new FibonacciService();
            Console.WriteLine("Enter length");
            int len = Convert.ToInt32(Console.ReadLine());
            if (len <= 0)
            {
                return;
            }

            //foreach (var n in fs.GetNthFibonacciSeries(len))
            //{
            //    Console.Write(n + " ");
            //}

            Console.WriteLine(string.Join(",", fs.GetNthFibonacciSeries(len)));

            Console.ReadLine();
        }
    }
}
