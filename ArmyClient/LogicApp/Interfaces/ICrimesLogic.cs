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
        /// Удаление крайма
        /// </summary>
        /// <param name="crime">Крайм</param>
        /// <returns>Возвращает true, если успешно, иначе false</returns>
        Task<bool> RemoveCrime(UserCrimes crime);

        /// <summary>
        /// Загрузка типов преступлений
        /// </summary>
        /// <returns>Возвращаем список типов преступлений</returns>
        Task<List<CrimesType>> LoadCrimesCategory();

        /// <summary>
        /// Получить преступления пользователя
        /// </summary>
        /// <param name="ID">Айди социальной сети</param>
        /// <returns>Преступления</returns>
        Task<List<UserCrimes>> GetSocialNetworkCrimes(int ID);


        /// <summary>
        /// Добавление преступления
        /// </summary>
        /// <param name="crime">Преступление</param>
        /// <returns>Возвращает true, если успешно</returns>
        Task<bool> AddCrime(UserCrimes crime);


        /// <summary>
        /// Редактирование преступления
        /// </summary>
        /// <param name="crime">Преступление</param>
        /// <returns>Возвращает true, если успешно</returns>
        Task<bool> EditCrime(UserCrimes crime);
    }
}
