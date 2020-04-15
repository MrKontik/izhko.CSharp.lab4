using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    /// <summary>
    /// Это абстрактный класс, с функциями, которые должны настраивать  приложения
    /// </summary>
    /// <returns>Сам класс</returns>
    public abstract class Settings
    {
        /// <summary>
        /// Функция по настройке языка
        /// </summary>
        public abstract void Language();
        /// <summary>
        /// Функция по настройке формы денег
        /// </summary>
        public abstract void FormMoney();
        /// <summary>
        /// Функция по настройке инфе о саппортах
        /// </summary>
        public abstract void InfoSupport();
        /// <summary>
        /// Функция по настройке форме телефонного номера
        /// </summary>
        public abstract void FormPhone();
        /// <summary>
        /// Функция по настройке домена
        /// </summary>
        public abstract void Domen();
        /// <summary>
        /// Функция по настройке закона страны
        /// </summary>
        public abstract void Law();
        /// <summary>
        /// Функция по настройке соглашения
        /// </summary>
        public abstract void Agreement();
        /// <summary>
        /// Функция по настройке версии
        /// </summary>
        public abstract void Version();
        /// <summary>
        /// Функция по настройке стране доставщике
        /// </summary>
        public abstract void SupplierCountry();
        /// <summary>
        /// Функция по настройке адресса полиции
        /// </summary>
        public abstract void AddresPolice();

    }
}
