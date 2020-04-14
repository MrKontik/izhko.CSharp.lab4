using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    public class Application
    {
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
