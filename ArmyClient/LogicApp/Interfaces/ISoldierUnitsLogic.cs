using ArmyClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.LogicApp.Interfaces
{
    interface ISoldierUnitsLogic
    {
        #region Асинхронные версии методов


        /// <summary>
        /// Получить список В/Ч по городу
        /// </summary>
        /// <param name="IdCity">Айди города</param>
        /// <returns>Возвращает список В/Ч</returns>
        Task<List<SoldierUnit>> GetSoldierUnitsCityAsync(int IdCity);

        /// <summary>
        /// Получить список В/Ч по стране
        /// </summary>
        /// <param name="IdCountry">Айди страны</param>
        /// <returns>Возвращает список В/Ч</returns>
        Task<List<SoldierUnit>> GetSoldierUnitsCountryAsync(int IdCountry);
        #endregion
    }
}
