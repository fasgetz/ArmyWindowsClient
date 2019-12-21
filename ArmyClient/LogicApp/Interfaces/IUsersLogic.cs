using ArmyClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.LogicApp.Interfaces
{

    /// <summary>
    /// Содержит набор методов для работы с пользователями
    /// </summary>
    interface IUsersLogic
    {

        #region Синхронные версии методов

        /// <summary>
        /// Метод по добавлению пользователя в бд
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns>Возвращает результат добавления</returns>
        bool AddUser(Users user);

        #endregion

        /// <summary>
        /// Асинхронная версия метод по добавлению пользователя в бд
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns>Возвращает результат добавления</returns>
        Task<bool> AddUserAsync(Users user);


        /// <summary>
        /// Метод получения пользователей
        /// </summary>
        /// <param name="user">Параметр, по модели которой делается выборка</param>
        /// <returns>Возвращает пользователей</returns>
        Task<List<Users>> GetUsersAsync(Users user, bool vk = false, bool instagram = false, bool facebook = false);

        #region Асинхронные версии методов


        #endregion
    }
}
