using ArmyClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.LogicApp.Interfaces
{
    interface ICrimesLogic
    {

        /// <summary>
        /// Загрузка типов преступлений
        /// </summary>
        /// <returns>Возвращаем список типов преступлений</returns>
        Task<List<CrimesType>> LoadCrimesCategory();
    }
}
