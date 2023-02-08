using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1Yakovlev
{
    class zadanie
    {
        private static string Reverse(string s)
        {
            char[] chars = s.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
        private static string ConvertToNumSystem(int a, int num)
        {
            var numToChar16 = new Dictionary<string, string>()
            {
                { "10", "A" },
                { "11", "B" },
                { "12", "C" },
                { "13", "D" },
                { "14", "E" },
                { "15", "F" },
            };
            string result = "";
            while (a > 0)
            {
                string _ = Convert.ToString(a % num);
                if (num == 16)
                {
                    switch (_)
                    {
                        case "10":
                            _ = numToChar16["10"];
                            break;
                        case "11":
                            _ = numToChar16["11"];
                            break;
                        case "12":
                            _ = numToChar16["12"];
                            break;
                        case "13":
                            _ = numToChar16["13"];
                            break;
                        case "14":
                            _ = numToChar16["14"];
                            break;
                        case "15":
                            _ = numToChar16["15"];
                            break;
                        default:
                            break;
                    };
                }
                result = result + _;
                a /= num;
            }
            if (num == 2)
            {
                if (result.Length < 16)
                {
                    for (int i = result.Length; i < 16; i++)
                    {
                        result = result + 0;
                    }
                }
            }
            return Reverse(result);
        }
        public void zad1()
        {
            Console.WriteLine("Лабораторная работа №1 выполнена Яковлевым Георгием.");
            Console.WriteLine("Задание №1");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int x = a, y = b, xsum = 0, ysum = 0, minod = 1, maxod = 1;
            string xstr = Convert.ToString(x);
            string ystr = Convert.ToString(y);
            bool accepta = false, acceptb = false, first = true;
            if (a >= 0 && a <= 65535)
            {
                accepta = true;
            }
            if (b >= 0 && b <= 65535)
            {
                acceptb = true;
            }
            for (int i = 0; i < xstr.Length; i++)
            {
                xsum += x % 10;
                x /= 10;

            }
            for (int j = 0; j < ystr.Length; j++)
            {
                ysum += y % 10;
                y /= 10;

            }
            if (accepta) { Console.WriteLine($"В числе {a} сумма цифр {xsum}"); }
            if (acceptb) { Console.WriteLine($"В числе {b} сумма цифр {ysum}"); }
            x = a;
            y = b;
            if (accepta)
            {
                Console.WriteLine($"Простые сомножители числа {a}");
                if (x % 2 == 0)
                {
                    x /= 2;
                    Console.Write($"2 ");
                }
                for (int i = 3; i <= x; i++)
                {
                    bool isSimple = true;
                    for (int j = 2; j < i; j++)
                    {
                        if (i % j == 0)
                        {
                            isSimple = false;
                            break;
                        }
                    }
                    if (isSimple)
                    {
                        if (x % i == 0)
                        {
                            x /= i;
                            Console.Write($"{i} ");
                        }
                    }
                }
                Console.WriteLine();
            }
            if (acceptb)
            {
                Console.WriteLine($"Простые сомножители числа {b}");
                if (y % 2 == 0)
                {
                    y /= 2;
                    Console.Write($"2 ");
                }
                for (int i = 3; i <= y; i++)
                {
                    bool isSimple = true;
                    for (int j = 2; j < i; j++)
                    {
                        if (i % j == 0)
                        {
                            isSimple = false;
                            break;
                        }
                    }
                    if (isSimple)
                    {
                        if (y % i == 0)
                        {
                            y /= i;
                            Console.Write($"{i} ");
                        }
                    }
                }
                Console.WriteLine();
            }
            if (accepta && acceptb)
            {
                for (int i = 2; i < 65535; i++)
                {
                    if (a % i == 0 && b % i == 0)
                    {
                        minod = i;
                        break;
                    }
                }
                for (int i = 65535; i > 0; i--)
                {
                    if (a % i == 0 && b % i == 0)
                    {
                        maxod = i;
                        break;
                    }
                }
                Console.WriteLine($"Наименьший общий делитель {a} и {b} ={minod}");
                Console.WriteLine($"Наибольший общий делитель {a} и {b} ={maxod}");
            }
            x = a;
            y = b;
            Console.WriteLine("Разложение на сомножители:");
            if (accepta)
            {
                Console.Write($"{a}=");
                for (int i = 2; i <= x; i++)
                {
                    if (x % i == 0)
                    {
                        x /= i;
                        if (first)
                        {
                            Console.Write($"{i}");
                            i--;
                            first = false;
                        }
                        else
                        {
                            Console.Write($"*{i}");
                            i--;
                        }
                    }
                }
                Console.WriteLine();
            }
            if (acceptb)
            {
                first = true;
                Console.Write($"{b}=");
                for (int i = 2; i <= y; i++)
                {
                    if (y % i == 0)
                    {
                        y /= i;
                        if (first)
                        {
                            Console.Write($"{i}");
                            i--;
                            first = false;
                        }
                        else
                        {
                            Console.Write($"*{i}");
                            i--;
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Задание 2:");
                Console.Write($"Число {a} в 2:");
                Console.WriteLine("\n" + ConvertToNumSystem(a, 2));
                Console.Write($"Число {a} в 16:");
                Console.WriteLine("\n" + ConvertToNumSystem(a, 16));
                Console.Write($"Число {b} в 2:");
                Console.WriteLine("\n" + ConvertToNumSystem(b, 2));
                Console.Write($"Число {b} в 16:");
                Console.WriteLine("\n" + ConvertToNumSystem(b, 16));
            }
        }
        class Program
        {
            static void Main()
            {
                zadanie zadanie1 = new zadanie();
                zadanie zadanie2 = new zadanie();
                zadanie1.zad1();
            }
        }
    }
}