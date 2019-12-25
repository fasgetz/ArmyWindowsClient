using ArmyClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.LogicApp.Interfaces
{
    interface ICitiesLogic
    {
        /// <summary>
        /// Получить список городов страны
        /// </summary>
        /// <returns>Возвращает список стран</returns>
        Task<List<City>> GetCities(byte idCountry);
    }
}
