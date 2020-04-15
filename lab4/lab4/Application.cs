using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    /// <summary>
    /// Само приложение
    /// </summary>
    /// <returns>Сам класс</returns>
    public class Application
    {
        /// <summary>
        /// Это функция иницилизации класса
        /// </summary>
        /// <param name="FactorySetting">Настройки определенной страны</param>
        /// <returns>Сам класс</returns>
        public Application(Settings FactorySetting)
        {
            FactorySetting.AddresPolice();
            FactorySetting.Agreement();
            FactorySetting.Domen();
            FactorySetting.FormMoney();
            FactorySetting.FormPhone();
            FactorySetting.InfoSupport();
            FactorySetting.Language();
            FactorySetting.Law();
            FactorySetting.SupplierCountry();
            FactorySetting.Version();
        }
    }
}
