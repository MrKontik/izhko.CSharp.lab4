using System;
using System.Collections.Generic;
using System.Text;

namespace lab5
{
    class CheckLow : Check
    {

        public override void CheckNow(string row)
        {
            if (row.ToLower()==row)
            {
                Console.WriteLine("Лентяй 2: Все буквы маленькие. А ты хорош) >.< Даже быстрее других справился");
                if (CheckNext != null)
                {
                    CheckNext.CheckNow(row);
                }
            }
            else
            {
                Console.WriteLine("Лентяй 2: Так... Послушай меня...и запомни. Мы не терпим высокомерия, поэтому все буквы маленькие. У НАС равенство!!!");
                throw new Exception();
            }

        }

    }
}
