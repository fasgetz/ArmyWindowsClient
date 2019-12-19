using ArmyClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.LogicApp.Interfaces
{
    interface ICountriesLogic
    {
        /// <summary>
        /// Получить список стран
        /// </summary>
        /// <returns>Возвращает список стран</returns>
        Task<List<Countries>> GetCountries();
    }
}
