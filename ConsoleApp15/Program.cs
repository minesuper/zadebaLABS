using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YakovlevLAB3
{
    class Program
    {
        private static double x, z;
        private static int k, m;
        static private void vvod()
        {
            x = double.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());
            m = int.Parse(Console.ReadLine());
        }
        static private void Z()
        {
            double sum = 0;
            int i = k;
            while (i <= m)
            {
                sum += (i * Math.Sqrt(Math.Pow(x, 2) - 3)) / Math.Log(i * x);
                i++;
            }
            z = (7 / (x - 3)) * sum;
        }
        private static float[] ReturnNumber()
        {
            Console.Clear();
            Console.WriteLine("Введите числа через пробел:");
            string str = Console.ReadLine();
            string[] a = str.Split(' ');
            float[] result = new float[2];
            result[0] = Convert.ToInt32(a[0]);
            result[1] = Convert.ToInt32(a[1]);
            return result;
        }
        private static float ReturnOperation(float a, float b)
        {
            Console.Write($"1.'+'\n2.'-'\n3.'*'\n4.'/'\n5.'^'\n6.REPEAT?\n");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    return a + b;
                case ConsoleKey.D2:
                    return a - b;
                case ConsoleKey.D3:
                    return a * b;
                case ConsoleKey.D4:
                    return a / b;
                case ConsoleKey.D5:
                    return (float)Math.Pow(a, b);
                default:
                    float[] _ = ReturnNumber();
                    return ReturnOperation(_[0], _[1]);
            }
        }
        static private void zadanie1()
        {
            bool zad = true;
            while (zad)
            {
                Console.Clear();
                vvod();
                bool zdel = true;
                if (k > m || k < 0)
                {
                    zdel = false;
                }
                if (x - 3 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Ошибка");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(": знаменатель (x-3) равен 0.\n");
                    zdel = false;
                }
                if (Math.Pow(x, 2) * 3 < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Ошибка");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(": подкоренное выражение х^2-3 меньше 0.\n");
                    zdel = false;
                }
                if (k * x == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Ошибка");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(": аргумент логарифма равен 0.\n");
                    zdel = false;
                }
                if (zdel)
                {
                    Z();
                    Console.WriteLine($"Z({x};{k};{m}) = {z}");
                }
                Console.WriteLine("REPEAT? (Y/N)");
                ConsoleKey y = Console.ReadKey().Key;
                if (y != ConsoleKey.Y)
                {
                    zad = false;
                }
                Console.WriteLine();
            }
        }
        static private void zadanie2()
        {
            float[] arr = ReturnNumber();
            float result;
            result = ReturnOperation(arr[0], arr[1]);
            Console.WriteLine("\nОтвет:" + result);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №3 “Итерация” выполнена Яковлевым Георгием.");
            zadanie1();
            zadanie2();
        }
    }
}
