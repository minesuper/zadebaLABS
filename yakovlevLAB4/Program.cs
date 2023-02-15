using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    class Program
    {
        public static double e = 0.1;
        public static double d = 0.01;
        static void Y1(double a,double b)
        {
            double x = a;
            double temp_;
            int count = 0;
            Console.WriteLine("\n1");
            while (x<=b)
            {
                temp_ = Math.Pow(5, x) - Math.Pow(x, 4) + Math.Sin(x);
                if (temp_ >-e && temp_<e)
                {
                    Console.WriteLine(temp_);
                    Console.WriteLine($"a={a},b={b},d={d},e={e} Ответ x={x}");
                    count = 1;
                }
                x += d;
            }
            if (count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Решений нет");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void Y2(double a, double b)
        {
            double x = a;
            double temp_;
            int count = 0;
            Console.WriteLine("\n2");
            while (x <= b)
            {
                temp_ = Math.Log(x) + Math.Exp(x) - 0.3;
                if (temp_ > -e && temp_ < e)
                {
                    Console.WriteLine(temp_);
                    Console.WriteLine($"a={a},b={b},d={d},e={e} Ответ x={x}");
                    count = 1;
                }
                x += d;
            }
            if (count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Решений нет");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void Y3(double a, double b)
        {
            double x = a;
            double temp_;
            int count = 0;
            Console.WriteLine("\n3");
            while (x <= b)
            {
                temp_ = x-Math.Sin(x)-0.25;
                if (temp_ > -e && temp_ < e)
                {
                    Console.WriteLine(temp_);
                    Console.WriteLine($"a={a},b={b},d={d},e={e} Ответ x={x}");
                    count = 1;
                }
                x += d;
            }
            if (count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Решений нет");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void Y4(double a, double b)
        {
            double x = a;
            double temp_;
            int count = 0;
            Console.WriteLine("\n4");
            while (x <= b)
            {
                temp_ = Math.Log(Math.Abs(x)) + Math.Tan(x) - x - 0.3;
                if (temp_ > -e && temp_ < e)
                {
                    Console.WriteLine(temp_);
                    Console.WriteLine($"a={a},b={b},d={d},e={e} Ответ x={x}");
                    count = 1;
                }
                x += d;
            }
            if (count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Решений нет");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void Y5(double a, double b)
        {
            double x = a;
            double temp_;
            int count = 0;
            Console.WriteLine("\n5");
            while (x <= b)
            {
                temp_ = Math.Log(3 * x) - Math.Log(2 * x) - Math.Log(x) - 0.2;
                if (temp_ > -e && temp_ < e)
                {
                    Console.WriteLine(temp_);
                    Console.WriteLine($"a={a},b={b},d={d},e={e} Ответ x={x}");
                    count = 1;
                }
                x += d;
            }
            if (count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Решений нет");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void Y6(double a, double b)
        {
            double x = a;
            double temp_;
            int count = 0;
            Console.WriteLine("\n6");
            while (x <= b)
            {
                temp_ = 1 / (Math.Pow(x, 2) - x + 11)-Math.Cos(x);
                if (temp_ > -e && temp_ < e)
                {
                    Console.WriteLine(temp_);
                    Console.WriteLine($"a={a},b={b},d={d},e={e} Ответ x={x}");
                    count = 1;
                }
                x += d;
            }
            if (count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Решений нет");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void Y7(double a, double b)
        {
            double x = a;
            double temp_;
            int count = 0;
            Console.WriteLine("\n7");
            while (x <= b)
            {
                temp_ = Math.Log(x)+Math.Cos(x)-0.25;
                if (temp_ > -e && temp_ < e)
                {
                    Console.WriteLine(temp_);
                    Console.WriteLine($"a={a},b={b},d={d},e={e} Ответ x={x}");
                    count = 1;
                }
                x += d;
            }
            if (count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Решений нет");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void Y8(double a, double b)
        {
            double x = a;
            double temp_;
            int count = 0;
            Console.WriteLine("\n8");
            while (x <= b)
            {
                temp_ = 0.3/Math.Cos(x)-(0.1*Math.Pow(x,2)-0.4*x+0.5);
                if (temp_ >-e && temp_<e)
                {
                    Console.WriteLine(temp_);
                    Console.WriteLine($"a={a},b={b},d={d},e={e} Ответ x={x}");
                    count = 1;
                }
                x += d;
            }
            if (count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Решений нет");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №4. Решение уравнения. Выполнена Яковлевым Георгием.");
            Y1(-1,1);
            Y2(0.1, 0.5);
            Y3(1, 1.5);
            Y4(0.7,1.3);
            Y5(1,1.5);
            Y6(1,2);
            Y7(0.4,1.5);
            Y8(0.3,0.7);
        }
    }
}
