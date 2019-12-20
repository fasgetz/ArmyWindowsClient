using ArmyClient.LogicApp.Interfaces;
using ArmyClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.LogicApp.Realisation
{

    /// <summary>
    /// Класс содержит логику работы с БД категории пользователей
    /// </summary>
    internal class UserLogic : IUsersLogic
    {

        #region Синхронные версии методов

        /// <summary>
        /// Метод по добавлению пользователя в бд
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns>Возвращает результат добавления</returns>
        public bool AddUser(Users user)
        {
            try
            {
                using (ArmyDB db = new ArmyDB())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        #endregion


        #region Асинхронные версии методов

        /// <summary>
        /// Асинхронная версия метод по добавлению пользователя в бд
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> AddUserAsync(Users user)
        {            
            return await Task.Run(() =>
            {
                try
                {
                    using (ArmyDB db = new ArmyDB())
                    {
                        db.Users.Add(user);
                        db.SaveChanges();
                    }

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        
        /// <summary>
        /// Метод получения пользователей
        /// </summary>
        /// <param name="user">Параметр, по модели которой делается выборка</param>
        /// <returns>Возвращает пользователей</returns>
        public async Task<List<Users>> GetUsersAsync(Users user)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (ArmyDB db = new ArmyDB())
                    {

                        var users = from vm in db.Users
                                    where
                                      (!(string.IsNullOrEmpty(user.Name)) ? vm.Name.Contains(user.Name) : !string.IsNullOrEmpty(vm.Name)) &&
                                      (!(string.IsNullOrEmpty(user.Family)) ? vm.Family.Contains(user.Family) : !string.IsNullOrEmpty(vm.Family)) &&
                                      (!(string.IsNullOrEmpty(user.Surname)) ? vm.Surname.Contains(user.Surname) : !string.IsNullOrEmpty(vm.Surname))
                                    select vm;

                        var r = users.ToList();

                        return users.ToList();
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            });
        }


        #endregion


    }
}
