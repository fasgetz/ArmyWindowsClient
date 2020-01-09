using ArmyClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.LogicApp.Interfaces
{

    /// <summary>
    /// Логика работы с иностранными друзьями
    /// </summary>
    interface IForeignFriendsLogic
    {

        /// <summary>
        /// Добавить иностранного друга в соц. сеть
        /// </summary>
        /// <param name="friend">Иностранный друг</param>
        /// <returns>Возвращает true, если успешно</returns>
        bool AddForeignFriend(ForeignFriends friend);


        /// <summary>
        /// Получить список иностранных друзей социальной сети
        /// </summary>
        /// <param name="ID">Айди пользователя</param>
        /// <returns>Список иностранных друзей</returns>
        Task<List<ForeignFriends>> GetForeignFriends(int ID);


        /// <summary>
        /// Получить иностранного друга по айди
        /// </summary>
        /// <param name="ID">Айди пользователя</param>
        /// <returns>Иностранный друг</returns>
        Task<ForeignFriends> GetOneForeignFriend(int ID);
    }
}
