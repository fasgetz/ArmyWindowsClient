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

        LogicProviderDB provider;
        ArmyDBContext db;

        public UserLogic(LogicProviderDB provider)
        {
            this.provider = provider;
        }

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
                using (db = provider.GetProvider())
                {
                    db.Users.Add(user);
                    db.SaveChanges();

                    return true;
                }
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
                    using (db = provider.GetProvider())
                    {
                        db.Users.Add(user);
                        db.SaveChanges();

                        return true;
                    }
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
        public async Task<List<Users>> GetUsersAsync(Users user, bool vk = false, bool instagram = false, bool facebook = false)
        {

             
            return await Task.Run(() =>
            {
                using (db = provider.GetProvider())
                {
                    var users = (from item in (from vm in db.Users.Include("UserSoldierService").Include("UserCrimes").Include("Countries1")
                                               where
                                                 (!(string.IsNullOrEmpty(user.Name)) ? vm.Name.Contains(user.Name) : !string.IsNullOrEmpty(vm.Name)) &&
                                                 (!(string.IsNullOrEmpty(user.Family)) ? vm.Family.Contains(user.Family) : (string.IsNullOrEmpty(vm.Family) || !string.IsNullOrEmpty(vm.Family))) &&
                                                 (!(string.IsNullOrEmpty(user.Surname)) ? vm.Surname.Contains(user.Surname) : (string.IsNullOrEmpty(vm.Surname) || !string.IsNullOrEmpty(vm.Surname))) &&
                                                 ((user.DateBirth != null) ? vm.DateBirth == user.DateBirth : (vm.DateBirth >= new DateTime() || vm.DateBirth == null)) &&
                                                 ((user.IdCountryBirth != null) ? vm.IdCountryBirth == user.IdCountryBirth : vm.IdCountryBirth != 0) &&
                                                 (!(string.IsNullOrEmpty(user.CityBirth)) ? vm.CityBirth.Contains(user.CityBirth) : (string.IsNullOrEmpty(vm.CityBirth) || !string.IsNullOrEmpty(vm.CityBirth))) &&
                                                 ((user.IdCurrentCountryResidence != null) ? vm.IdCurrentCountryResidence == user.IdCurrentCountryResidence : vm.IdCurrentCountryResidence != 0) &&
                                                 (!(string.IsNullOrEmpty(user.CurrentCityResience)) ? vm.CurrentCityResience.Contains(user.CurrentCityResience) : (string.IsNullOrEmpty(vm.CurrentCityResience) || !string.IsNullOrEmpty(vm.CurrentCityResience))) &&
                                                 (!(string.IsNullOrEmpty(user.AddressResidence)) ? vm.AddressResidence.Contains(user.AddressResidence) : (string.IsNullOrEmpty(vm.AddressResidence) || !string.IsNullOrEmpty(vm.AddressResidence))) &&
                                                 // Ищем по социальному статусу
                                                 ((user.SocialStatusID != null) ? vm.SocialStatusID == user.SocialStatusID : vm.SocialStatusID != 0) &&
                                                 (!(string.IsNullOrEmpty(user.email)) ? vm.email.Contains(user.email) : (string.IsNullOrEmpty(vm.email) || !string.IsNullOrEmpty(vm.email))) &&
                                                 (!(string.IsNullOrEmpty(user.phone)) ? vm.phone.Contains(user.phone) : (string.IsNullOrEmpty(vm.phone) || !string.IsNullOrEmpty(vm.phone))) &&
                                                 (user.IsMonitoring == false ? (vm.IsMonitoring == true || vm.IsMonitoring == false) : vm.IsMonitoring == true) &&
                                                 // Тут самое сложное. По социальным сетям вывести если стоят галочки
                                                 (((vk == true) ? vm.SocialNetworkUser.FirstOrDefault(i => i.SocialNetworkId == 1).SocialNetworkId == 1 : vm.SocialNetworkUser.FirstOrDefault(i => i.SocialNetworkId == 0).SocialNetworkId == 0) ||
                                                 ((instagram == true) ? vm.SocialNetworkUser.FirstOrDefault(i => i.SocialNetworkId == 3).SocialNetworkId == 3 : vm.SocialNetworkUser.FirstOrDefault(i => i.SocialNetworkId == 0).SocialNetworkId == 0) ||
                                                 ((facebook == true) ? vm.SocialNetworkUser.FirstOrDefault(i => i.SocialNetworkId == 2).SocialNetworkId == 2 : vm.SocialNetworkUser.FirstOrDefault(i => i.SocialNetworkId == 0).SocialNetworkId == 0))

                                               select new
                                               {
                                                   Id = vm.Id,
                                                   Name = vm.Name,
                                                   Family = vm.Family,
                                                   Surname = vm.Surname,
                                                   Countries1 = vm.Countries1,
                                                   CurrentCityResience = vm.CurrentCityResience,
                                                   UserSoldierService = vm.UserSoldierService,
                                                   UserCrimes = vm.UserCrimes
                                               }).ToList()
                                 // Выбираем столбцы, которые будут отображаться в таблице
                                 select new Users()
                                 {
                                     Id = item.Id,
                                     Name = item.Name,
                                     Family = item.Family,
                                     Surname = item.Surname,
                                     Countries1 = item.Countries1,
                                     CurrentCityResience = item.CurrentCityResience,
                                     UserSoldierService = item.UserSoldierService,
                                     UserCrimes = item.UserCrimes
                                 });
                      

                    return users.ToList();
                }

            });
        }

        /// <summary>
        /// Получить пользователя по айди
        /// </summary>
        /// <param name="UserID">Айди Пользователя</param>
        /// <returns>Возвращает данные о пользователе</returns>
        public async Task<Users> GetUserAsync(int UserID)
        {


            return await Task.Run(() =>
            {
                using (db = provider.GetProvider())
                    return db.Users.Include("Countries").Include("Countries1").Include("SocialStatuses").Include("UserSoldierService.SoldierUnit").Include("SocialNetworkUser.SocialNetworkType").FirstOrDefault(i => i.Id == UserID);
            });
        }

        #endregion


    }
}
