using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Fire
{
    class Console2
    {
        public static int Readint()
        {
            String input = Console.ReadLine();
            int value = Convert.ToInt32(input);
            return value;
        }
        public static int Readint(string message)
        {
            Console.WriteLine(message);
            return Readint();
        }
        public static double ReadDecimal(string input)
        {
            var value = Convert.ToDouble(input);
            return value;
        }
        public static int Readint2()
        {
            String input = Console.ReadLine();
            bool parse = int.TryParse(input, out int number);
            if (parse)
            {
                return number;
            }
            else
            {
                number = 0;
                return number;
            }
        }
        public static int Readint2(string convert)
        {
            bool parse = int.TryParse(convert, out int number);
            if (parse)
            {
                return number;
            }
            else
            {
                number = 0;
                return number;
            }
        }
        public static string[] SplitStringx2(string comando, string separator, char separator2)
        {
            string[] final;
            var vec = comando.Split(separator);
            for (int i = 0; i < vec.Length; i++)
            {
                 final = vec[i].Split(separator2);
                return final;
            }
            return vec;
        }
        public static bool ConvertToDateOnly(string message)
        {
            DateOnly date;
            if (DateOnly.TryParse(message, out date))
            {
                return true;
            }
            else return false;
        }
        public static void StringSleep(string messagem, int segundos)
        {
            Console.WriteLine(messagem);
            Thread.Sleep(segundos * 1000);
        }
    }
}
