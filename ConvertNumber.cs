using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace перевод_чисел_в_различные_системы_исчислений
{
    internal class ConvertNumber
    {
        private long value;
       
        public long Value { set { Value=value; } }
       
        public ConvertNumber(long value)
        {
            this.value = value;
        }
        public string ConvertTo(int NumberSystem)
        {
            long n = value;
            string[] symb = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", 
                "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
           
            StringBuilder res = new StringBuilder(); // для записи остатков от деления 
            while (n != 0)
            {
                if (n < NumberSystem)
                    res.Append(symb[n]);

                else if (n >= NumberSystem)
                {
                    if (n % NumberSystem > 9 && n % NumberSystem < NumberSystem)
                        res.Append(symb[n % NumberSystem]); // в случае если остаток от деления получился больше 9, добавляем соответствующую букву
                    else
                        res.Append(n % NumberSystem); // записываем остатки от деления 
                }
                n /= NumberSystem;  // делим число на соответствующую систему счисления пока не будет 0
            }
            StringBuilder sbrevers = new StringBuilder(); // для реверса
            for (int i = res.Length - 1; i >= 0; i--)
                sbrevers.Append(res[i]); // переворачиваем строку
            string result = Convert.ToString(sbrevers.ToString()); // конвертируем stringbuilder в string

            return result;
        }

        }
}
