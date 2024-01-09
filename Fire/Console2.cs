using System;
using System.Collections.Generic;
using System.Linq;
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
        public static decimal ReadDecimal()
        {
            String input = Console.ReadLine();
            decimal value = Convert.ToInt32(input);
            return (decimal)value;
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
    }
}
