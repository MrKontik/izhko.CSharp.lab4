using System;
using System.Collections.Generic;
using System.Text;

namespace lab5
{
    class CheckLength : Check
    {

        public override void CheckNow(string row)
        {
            if (row.Length==5)
            {
                Console.WriteLine("Труженник 3: Проверяем. Длина ввода 5 букв. Подтвержаю проверку. Иди теперь дальше");
                if (CheckNext != null)
                {
                    CheckNext.CheckNow(row);
                }
            }
            else
            {
                Console.WriteLine("Труженник 3: Эх. Тут не 5 букв. К сожалению тебе придеться проходить все проверки заного.");
                throw new Exception();
            }


        }

    }
}
