using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    class RussianSetting : Settings
    {
        public override void AddresPolice()
        {
            Console.WriteLine("Данные адреса полицейских загружены");
        }
        public override void Agreement()
        {
            Console.WriteLine("Данные о соглашении загружены");
        }
        public override void Domen()
        {
            Console.WriteLine("Данные о домене загружены");
        }
        public override void FormMoney()
        {
            Console.WriteLine("Данные о деньгах загружены");
        }
        public override void FormPhone()
        {
            Console.WriteLine("Данные о форме телефона загружены");
        }
        public override void InfoSupport()
        {
            Console.WriteLine("Данные об поддержке загружены");
        }
        public override void Language()
        {
            Console.WriteLine("Данные о языке загружены");
        }
        public override void Law()
        {
            Console.WriteLine("Данные о законе загружены");
        }
        public override void SupplierCountry()
        {
            Console.WriteLine("Данные о стране доставшика загружены");
        }
        public override void Version()
        {
            Console.WriteLine("Данные о версии загружены");
        }
    }
}
