using ArmyClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.LogicApp.Interfaces
{
    /// <summary>
    /// Социальные статусы
    /// </summary>
    interface ISocStatusesLogic
    {
        /// <summary>
        /// Получить список социальных статусов
        /// </summary>
        /// <returns>Возвращает список социальных статусов</returns>
        Task<List<SocialStatuses>> GetSocialStatuses();
    }
}
