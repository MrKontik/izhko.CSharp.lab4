using System;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите строку: ");
               string inp = Console.ReadLine();
                try
                {
                    CheckNoNumber checkNoNumber = new CheckNoNumber();
                    CheckLow checkLow = new CheckLow();
                    CheckLength checkLength = new CheckLength();
                    checkNoNumber.setCheckNext(checkLow);
                    checkLow.setCheckNext(checkLength);
                    checkNoNumber.CheckNow(inp);
                    Console.WriteLine("Запрос дошел и обработался, поздравляю!!!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Запрос не прошел проверки. Попробуй еще раз.");
                }
            }
        }
    }
}
