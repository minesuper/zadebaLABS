using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace yakovlevLAB5
{
    abstract class Convertions
    {
        abstract public string Normalize(string a);
        public string ConvertBase(string numstr, int base_old, int base_new)
        {
            int num = Convert.ToInt32(numstr, base_old);
            string res = Convert.ToString(num, base_new).ToUpper();
            return res;
        }
        public string Tetradsbin(string a)
        {
            a = a.PadLeft(32, '0');
            string[] tetrads = new string[8];
            for (int i = 0; i < a.Length; i += 4)
            {
                tetrads[i / 4] = a.Substring(i, 4);
            }
            a = string.Join(" ", tetrads);
            return a;
        }
    }
    class Convertion : Convertions
    {
        override public string Normalize(string a)
        {
            string res = "";
            if (a.Length > 8)
            {
                res = a.Substring(a.Length - 8);
            }
            else if (a.Length < 8)
            {
                res = a;
                for (int i = 0; i < 8 - a.Length; i++)
                {
                    res = "0" + res;
                }
            }
            else res = a;
            return res;
        }
    }
    class T1
    {
        Convertion c = new Convertion();
        private string Logic(string a, string b, int num)
        {
            int a1 = Convert.ToInt32(c.ConvertBase(a, 16, 10));
            int b1 = Convert.ToInt32(c.ConvertBase(b, 16, 10));
            int res;
            switch (num)
            {
                case 1:
                    res = a1 & b1;
                    break;
                case 2:
                    res = a1 | b1;
                    break;
                case 3:
                    res = a1 ^ b1;
                    break;
                default:
                    res = 0;
                    break;
            }
            string result = c.ConvertBase(Convert.ToString(res), 10, 16).ToUpper();
            return result;
        }
        private string MoveR(string a, int num)
        {
            int a1 = Convert.ToInt32(c.ConvertBase(a, 16, 10));
            string res = c.ConvertBase(Convert.ToString(a1 >> num), 10, 16).ToUpper();
            return res;
        }
        private string MoveRC(string a, int num)
        {
            a = c.Tetradsbin(c.ConvertBase(a, 16, 2)).Replace(" ", String.Empty);
            try
            {
                string res = a.Substring(a.Length - num) + a.Substring(0, a.Length - num);
                return c.ConvertBase(res, 2, 16).ToUpper();
            }
            catch (ArgumentOutOfRangeException)
            {
                return c.ConvertBase(a, 2, 16).ToUpper();
            }
        }
        private void Output(string a)
        {
            Console.WriteLine($"{c.Normalize(a)} = {c.ConvertBase(a, 16, 10)} = \n{c.Tetradsbin(c.ConvertBase(a, 16, 2))}\n");
        }
        private void Output(string action, string symbol, string a, string b, string res)
        {
            Console.WriteLine($"{action} {a} {symbol} {b} = {res} = {c.ConvertBase(res, 16, 10)} = \n{c.Tetradsbin(c.ConvertBase(res, 16, 2))}\n");
        }
        private void Output(string action, string a)
        {
            Console.WriteLine($"{action} {a} = {c.ConvertBase(a, 16, 10)} = \n{c.Tetradsbin(c.ConvertBase(a, 16, 2))}\n");
        }
        public T1()
        {
            Console.WriteLine("Введите два шестнадцатеричных числа: ");
            string a = c.Normalize(Console.ReadLine().ToUpper());
            string b = c.Normalize(Console.ReadLine().ToUpper());
            Console.WriteLine();
            Output(a);
            Output(b);
            string res = Logic(a, b, 1);
            Output("Конъюнкция:", "&", a, b, res);
            res = Logic(a, b, 2);
            Output("Дизъюнкция:", "|", a, b, res);
            res = Logic(a, b, 3);
            Output("Сложение по модулю 2:", "^", a, b, res);
            Console.WriteLine("На сколько двигать? ");
            int numR = Int32.Parse(Console.ReadLine());
            Output($"Сдвиг вправо на {numR}:", MoveR(a, numR));
            Console.WriteLine("На сколько двигать? ");
            int numC = Int32.Parse(Console.ReadLine());
            Output($"Циклический сдвиг вправо на {numC}:", MoveRC(b, numC));
        }
    }
    class T2
    {
        Convertion c = new Convertion();
        private string[] SplitBinary(string a)
        {
            a = Tetradsbin(a).Replace(" ", string.Empty);
            return new[] { a.Trim(' ').Substring(0, 1), a.Trim(' ').Substring(1, 8), a.Trim(' ').Substring(9, 23) };
        }
        private double FindPow(string[] a)
        {
            int _ = int.Parse(c.ConvertBase(a[1], 2, 10)) - 127;
            return Math.Pow(2, _);
        }
        private double FindMantiss(string[] a)
        {
            string _ = "1," + c.ConvertBase(a[2], 2, 10);
            return double.Parse(_);
        }
        private double FromFloat(string[] a, double mantiss, double pow)
        {
            if (a[0] == "0") return mantiss * pow;
            else return -mantiss * pow;
        }
        private string[] ToBinFromFloat(double a)
        {
            string _ = Convert.ToString(a);
            string[] temp = _.Split(',');
            string[] bin = { c.ConvertBase(temp[0], 10, 2), c.ConvertBase(temp[1], 10, 2) };
            string[] res = { c.ConvertBase(Convert.ToString(bin[0].Length - 1 + 127), 10, 2), bin[0].Substring(1) + bin[1] };
            return res;
        }
        public string Tetradsbin(string a)
        {
            a = a.PadLeft(32, '0');
            string[] tetrads = new string[8];
            for (int i = 0; i < a.Length; i += 4)
            {
                tetrads[i / 4] = a.Substring(i, 4);
            }
            a = string.Join(" ", tetrads);
            return a;
        }
        public string TetradsbinR(string a)
        {
            a = a.PadRight(32, '0');
            string[] tetrads = new string[8];
            for (int i = 0; i < a.Length; i += 4)
            {
                tetrads[i / 4] = a.Substring(i, 4);
            }
            a = string.Join(" ", tetrads);
            return a;
        }
        private void BinOut(string b)
        {
            b = b.PadRight(33, '0');
            for (int i = 1; i < b.Length; i++)
            {
                if (i == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (i == 10)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write(b[i - 1]);
                if (i % 4 == 0)
                {
                    Console.Write(" ");
                }
            }
        }
        private void Output(double a, string b)
        {
            string _ = TetradsbinR(b).Replace(" ", string.Empty);
            Console.Write($"{a} = {c.ConvertBase(_, 2, 16)} = ");
            BinOut(b);
        }
        public T2()
        {
            Console.WriteLine("Введите шестнадцатеричное число:");
            string a = c.Normalize(Console.ReadLine());
            string a_base2 = c.ConvertBase(a, 16, 2);
            Console.WriteLine($"{a} = {c.Tetradsbin(a_base2)}");
            string[] arr_a = SplitBinary(a_base2);
            Console.WriteLine(a + " = " + FromFloat(arr_a, FindMantiss(arr_a), FindPow(arr_a)));
            Console.WriteLine("Ввести десятичное дробное число (РАЗДЕЛИТЕЛЬ ЗАПЯТАЯ)");
            double b = double.Parse(Console.ReadLine());
            char sign;
            string[] temp;
            string res;
            sign = (b < 0) ? '1' : '0';
            b = Math.Abs(b);
            temp = ToBinFromFloat(b);
            res = sign + temp[0] + temp[1];
            Output(b, res);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №5 “Преобразование чисел” выполнена Яковлевым Георгием");
            //T1 t1 = new T1();
            T2 t2 = new T2();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу чтобы выйти");
            Console.ReadKey();
        }
    }
}