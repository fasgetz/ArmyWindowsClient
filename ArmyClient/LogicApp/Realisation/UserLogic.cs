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
        public async Task<List<Users>> GetUsersAsync(Users user, bool vk = false, bool instagram = false, bool facebook = false, bool odnoklassniki = false)
        {

             
            return await Task.Run(() =>
            {
                using (db = provider.GetProvider())
                {
                    //var users = db.Users.Include("UserSoldierService").Include("UserCrimes").Include("City1.Countries").Where(i => i.City1 != null);

                    //var test = users.ToList();

                    //var a = test;
                    var users = (from item in (from vm in db.Users.Include("UserSoldierService").Include("SocialNetworkUser.UserCrimes").Include("City1.Countries")
                                               where
                                                 (!(string.IsNullOrEmpty(user.Name)) ? vm.Name.Contains(user.Name) : !string.IsNullOrEmpty(vm.Name)) &&
                                                 (!(string.IsNullOrEmpty(user.Family)) ? vm.Family.Contains(user.Family) : (string.IsNullOrEmpty(vm.Family) || !string.IsNullOrEmpty(vm.Family))) &&
                                                 (!(string.IsNullOrEmpty(user.Surname)) ? vm.Surname.Contains(user.Surname) : (string.IsNullOrEmpty(vm.Surname) || !string.IsNullOrEmpty(vm.Surname))) &&
                                                 ((user.DateBirth != null) ? vm.DateBirth == user.DateBirth : (vm.DateBirth >= new DateTime() || vm.DateBirth == null)) &&
                                                 // Страна рождения
                                                 ((user.City.CountryId != null) ? vm.City.CountryId == user.City.CountryId : vm.City.CountryId != 0) &&
                                                 // Страна проживания
                                                 ((user.City1.CountryId != null) ? vm.City1.CountryId == user.City1.CountryId : vm.City1.CountryId != 0) &&
                                                 // Город рождения
                                                 (user.CityBirth_Id != null ? vm.CityBirth_Id == user.CityBirth_Id : vm.CityBirth_Id != 0) &&
                                                 // Город текущего проживания
                                                 (user.CurrentCityResience_Id != null ? vm.CurrentCityResience_Id == user.CurrentCityResience_Id : vm.CurrentCityResience_Id != 0) &&
                                                 (!(string.IsNullOrEmpty(user.AddressResidence)) ? vm.AddressResidence.Contains(user.AddressResidence) : (string.IsNullOrEmpty(vm.AddressResidence) || !string.IsNullOrEmpty(vm.AddressResidence))) &&
                                                 // Ищем по социальному статусу
                                                 ((user.SocialStatusID != null) ? vm.SocialStatusID == user.SocialStatusID : (vm.SocialStatusID != 0 | vm.SocialStatusID == null)) &&
                                                 (!(string.IsNullOrEmpty(user.email)) ? vm.email.Contains(user.email) : (string.IsNullOrEmpty(vm.email) || !string.IsNullOrEmpty(vm.email))) &&
                                                 (!(string.IsNullOrEmpty(user.phone)) ? vm.phone.Contains(user.phone) : (string.IsNullOrEmpty(vm.phone) || !string.IsNullOrEmpty(vm.phone))) &&
                                                 (user.IsMonitoring == false ? (vm.IsMonitoring == true || vm.IsMonitoring == false) : vm.IsMonitoring == true) &&
                                                 // Тут самое сложное. По социальным сетям вывести если стоят галочки
                                                 (
                                                 (((vk == true) || (instagram == true) || (facebook == true)) ?
                                                 ((vk == true) ? vm.SocialNetworkUser.FirstOrDefault(i => i.SocialNetworkId == 1).SocialNetworkId == 1 : vm.SocialNetworkUser.FirstOrDefault(i => i.SocialNetworkId == 0).SocialNetworkId == 0) ||
                                                 ((instagram == true) ? vm.SocialNetworkUser.FirstOrDefault(i => i.SocialNetworkId == 3).SocialNetworkId == 3 : vm.SocialNetworkUser.FirstOrDefault(i => i.SocialNetworkId == 0).SocialNetworkId == 0) ||
                                                 ((facebook == true) ? vm.SocialNetworkUser.FirstOrDefault(i => i.SocialNetworkId == 2).SocialNetworkId == 2 : vm.SocialNetworkUser.FirstOrDefault(i => i.SocialNetworkId == 0).SocialNetworkId == 0) ||
                                                 ((odnoklassniki == true) ? vm.SocialNetworkUser.FirstOrDefault(i => i.SocialNetworkId == 4).SocialNetworkId == 4 : vm.SocialNetworkUser.FirstOrDefault(i => i.SocialNetworkId == 0).SocialNetworkId == 0)
                                                 :
                                                 // Вывести всех, у кого нет соц сетей
                                                 vm.SocialNetworkUser.Count == 0)
                                                 )

                                               select new
                                               {
                                                   Id = vm.Id,                                                   
                                                   Name = vm.Name,
                                                   Family = vm.Family,
                                                   Surname = vm.Surname,
                                                   City1 = vm.City1,
                                                   Country = vm.City1.Countries.Name,
                                                   UserSoldierService = vm.UserSoldierService,
                                                   SocialNetworkUser = vm.SocialNetworkUser
                                                   // Преступления пользователя
                                                   //UserCrimes = vm.UserCrimes
                                               }).ToList()
                                     // Выбираем столбцы, которые будут отображаться в таблице
                                 select new Users()
                                 {
                                     Id = item.Id,
                                     Name = item.Name,
                                     Family = item.Family,
                                     Surname = item.Surname,
                                     City1 = item.City1,
                                     UserSoldierService = item.UserSoldierService,
                                     SocialNetworkUser = db.SocialNetworkUser.Include("UserCrimes").Where(i => i.IdUser == item.Id).ToList()
                                     //CrimesCount = item.SocialNetworkUser.Where(i => i.UserCrimes.Count > 0).Sum(i => i.UserCrimes.Count)
                                     //UserCrimes = item.UserCrimes
                                 }); ;
                    
                    //foreach (var item in users.ToList())
                    //{
                    //    item.SocialNetworkUser.Where(i => i.UserCrimes.Count > 0).Sum(i => i.UserCrimes.Count);
                    //}


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
                    return db.Users.Include("City1.Countries").Include("City.Countries").Include("SocialStatuses").Include("UserSoldierService.SoldierUnit").Include("SocialNetworkUser.SocialNetworkType").FirstOrDefault(i => i.Id == UserID);
            });
        }

        #endregion


    }
}
