using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace lab5
{
    class CheckNoNumber : Check
    {

        public override void CheckNow(string row)
        {
           if (Regex.IsMatch(row,@"^[\D]+$"))
           {
                Console.WriteLine("Работяга 1: Нууу, чисел нет. Молодец! Передаю запрос своему коллеге.");
                if (CheckNext != null)
                {
                    CheckNext.CheckNow(row);
                }
           }
           else
           {
                Console.WriteLine("Работяга 1: Хееей. Подожди секундочку... в запросе не может быть числа, ты не знал? вот теперь знаешь. Давай еще раз.");
                throw new Exception();
           }

        }

    }
}
