using System;

namespace lab4
{
    /// <summary>
    /// Это класс самой программы
    /// </summary>
    /// <returns>Сам класс</returns>
    class Program
    {
        //Предположим, нам требуется написать приложение, которое в дальнейшем будут продвигать в следующих странах: Россия, Китай, Германия. 
        //Напишите часть программы, которая определяет настройки приложения в зависимости от выбранного региона (например: язык, формат денежной единицы и т.д.). 
        //На вход подаётся название страны, программа выводит список настроек для данной локации. Минимальное количество изменяемых параметров: 10.
        /// <summary>
        /// Это главная функция откуда идет запуск
        /// </summary>
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

