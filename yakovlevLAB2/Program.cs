using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class zadanie1
    {
        public void zad1()
        {
            double y;
            for (double x = -30; x <= 30;)
            {
                if (x <= 6)
                {
                    y = Math.Round(8 * Math.Sin(4 * x), 3);
                }
                else if (x >= 18)
                {
                    y = Math.Round(5 / (4 * x), 3);
                }
                else
                {
                    y = 56;
                }
                Console.WriteLine($"x: {x}\ty:{y}");
                x += 6;
            }
        }
    }
    class zadanie2
    {
        public int n; double y;
        public double X(int n1, double y1)
        {
            double s = 0;
            n = n1; y = y1;
            for (int j = 1; j <= n; j++)
                s += Math.Exp(-Math.Sqrt(j - y));
            return s;
        }

    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Лабораторная работа №2 вариант №6 выполнена Яковлевым Георгием");
            ConsoleKey q = ConsoleKey.Spacebar;
            double x1, x2, x3; int n;
            while (q != ConsoleKey.Q)
            {
                zadanie1 zadanie1 = new zadanie1();
                Console.WriteLine("Задание 1:");
                zadanie1.zad1();
                Console.WriteLine("\nЗадание 2:");
                Console.Write("n = "); n = int.Parse(Console.ReadLine());
                zadanie2 fx = new zadanie2();
                x1 = fx.X(n, 0); Console.WriteLine("y1 = " + x1);
                x2 = fx.X(n, x1); Console.WriteLine("y2 = " + x2);
                x3 = fx.X(n, x2); Console.WriteLine("y3 = " + x3);
                Console.WriteLine("\nPress Q to exit");
                q = Console.ReadKey().Key;
            }
        }
    }
}
