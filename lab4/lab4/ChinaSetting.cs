using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    /// <summary>
    /// Это класс, с функциями, которые должны настраивать  приложения
    /// </summary>
    /// <returns>Сам класс</returns>
    class ChinaSetting :Settings
    {
        public override void AddresPolice()
        {
            Console.WriteLine("警察地址数据已上传");
        }
        public override void Agreement()
        {
            Console.WriteLine("协议数据已上传");
        }
        public override void Domen()
        {
            Console.WriteLine("域数据上传");
        }
        public override void FormMoney()
        {
            Console.WriteLine("资金数据已上传");
        }
        public override void FormPhone()
        {
            Console.WriteLine("手机形状数据上传");
        }
        public override void InfoSupport()
        {
            Console.WriteLine("支持数据上传");
        }
        public override void Language()
        {
            Console.WriteLine("语言数据上传");
        }
        public override void Law()
        {
            Console.WriteLine("法律数据上传");
        }
        public override void SupplierCountry()
        {
            Console.WriteLine("送货国家/地区数据已上传");
        }
        public override void Version()
        {
            Console.WriteLine("版本数据上传");
        }
    }
}
