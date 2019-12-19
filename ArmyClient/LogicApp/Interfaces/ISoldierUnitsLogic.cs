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
        /// Получить список В/Ч по стране
        /// </summary>
        /// <param name="IdCountry">Айди страны</param>
        /// <returns>Возвращает список В/Ч</returns>
        Task<List<SoldierUnit>> GetSoldierUnitsAsync(byte IdCountry);


        #endregion
    }
}
