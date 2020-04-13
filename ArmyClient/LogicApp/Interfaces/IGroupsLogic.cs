using ArmyClient.Models.ModelSocialNetworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.LogicApp.Interfaces
{
    interface IGroupsLogic
    {
        /// <summary>
        /// Метод добавления группы в БД
        /// </summary>
        /// <param name="group">Группа</param>
        /// <returns>Возвращает true, если успешно</returns>
        bool AddGroup(SocialNetworkGroup group);


        /// <summary>
        /// Получить список групп по айди социальной сети пользователей в бд
        /// </summary>
        /// <param name="ID">Айди социальной сети в БД</param>
        /// <returns>Список групп</returns>
        Task<List<SocialNetworkGroup>> GetGroups(int ID);

        /// <summary>
        /// Получить группу юзера по названию
        /// </summary>
        /// <param name="UserID">Айди социальной сети пользователя</param>
        /// <param name="NameGroup">Название группы</param>
        /// <returns>Если есть, то вернет группу, иначе null</returns>
        Task<SocialNetworkGroup> GetOneGroup(int UserID, string NameGroup);
    }
}
