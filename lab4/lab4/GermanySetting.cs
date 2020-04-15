using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    /// <summary>
    /// Это класс, с функциями, которые должны настраивать  приложения
    /// </summary>
    /// <returns>Сам класс</returns>
    class GermanySetting :Settings
    {
        public override void AddresPolice()
        {
            Console.WriteLine("Hochgceladene Adressdaten der Polizei");
        }
        public override void Agreement()
        {
            Console.WriteLine("Vertragsdaten hochgeladen");
        }
        public override void Domen()
        {
            Console.WriteLine("Domain-Daten hochgeladen");
        }
        public override void FormMoney()
        {
            Console.WriteLine("Gelddaten hochgeladen");
        }
        public override void FormPhone()
        {
            Console.WriteLine("Telefonformdaten hochgeladen");
        }
        public override void InfoSupport()
        {
            Console.WriteLine("Supportdaten hochgeladen");
        }
        public override void Language()
        {
            Console.WriteLine("Sprachdaten hochgeladen");
        }
        public override void Law()
        {
            Console.WriteLine("Gesetzedaten hochgeladen");
        }
        public override void SupplierCountry()
        {
            Console.WriteLine("Daten zum Lieferland hochgeladen");
        }
        public override void Version()
        {
            Console.WriteLine("Versionsdaten hochgeladen");
        }
    }
}
