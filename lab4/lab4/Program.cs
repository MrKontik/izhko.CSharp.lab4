using System;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите первые две буквы страны на английском (в данный момент известно 3 языка: ru,ge,ch");
                string input = Console.ReadLine();
                Settings settings = new RussianSetting();
                bool bl = true;
                switch (input.ToLower())
                {
                    case "ru":
                        settings = new RussianSetting();
                        break;
                    case "ge":
                        settings = new GermanySetting();
                        break;
                    case "ch":
                        settings = new ChinaSetting();
                        break;
                    default:
                        Console.WriteLine("error input");
                        bl = false;
                        break;
                }
                if (bl)
                {
                    Application application = new Application(settings);
                }
            }
        }
    }
}

