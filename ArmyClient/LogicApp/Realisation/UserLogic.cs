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

        /// <summary>
        /// Асинхронная версия метод по добавлению пользователя в бд
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> AddUserAsync(Users user)
        {            
            await Task.Run(() =>
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

            return false;
        }

    }
}
