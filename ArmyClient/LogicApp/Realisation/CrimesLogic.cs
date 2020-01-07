using ArmyClient.LogicApp.Interfaces;
using ArmyClient.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ArmyClient.LogicApp.Realisation
{
    class CrimesLogic : ICrimesLogic
    {

        LogicProviderDB provider;
        ArmyDBContext db;

        public CrimesLogic(LogicProviderDB provider)
        {
            this.provider = provider;
        }

        /// <summary>
        /// Добавление преступления
        /// </summary>
        /// <param name="crime">Преступление</param>
        /// <returns>Возвращает true, если успешно</returns>
        public async Task<bool> AddCrime(UserCrimes crime)
        {
            return await Task.Run(() =>
            {

                using (db = provider.GetProvider())
                {
                    //crime.DateEnty = DateTime.Now;
                    db.UserCrimes.Add(new UserCrimes() { IdSocialNetworkUser = crime.IdSocialNetworkUser, DateEnty = DateTime.Now });
                    //db.UserCrimes.Add(new UserCrimes()
                    //{
                    //    DateEnty = DateTime.Now,
                    //    IdSocialNetworkUser = crime.IdSocialNetworkUser,
                    //    Photo = crime.Photo,
                    //    Description = crime.Description,
                    //    WebAddressPost = crime.WebAddressPost,
                    //    UserCrimesCategory = crime.UserCrimesCategory
                    //});
                    //db.Entry(crime).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();

                    return true;
                }


                //// Если необходимые поля введены, то добавь в бд, иначе выдай экзепшен
                //if (!string.IsNullOrWhiteSpace(crime.WebAddressPost))
                //    using (db = provider.GetProvider())
                //    {
                //        db.UserCrimes.Add(new UserCrimes()
                //        {
                //            DateEnty = DateTime.Now,
                //            IdSocialNetworkUser = 3,
                //            //Photo = crime.Photo,
                //            //Description = crime.Description,
                //            WebAddressPost = crime.WebAddressPost
                //        });
                //        db.SaveChanges();

                //        return true;
                //    }
                //else
                //{
                //    new Exception("Введите необходимые поля");
                //    return false;
                //}
                    

                
            });
        }


        /// <summary>
        /// Редактирование преступления
        /// </summary>
        /// <param name="crime">Преступление</param>
        /// <returns>Возвращает true, если успешно</returns>
        public async Task<bool> EditCrime(UserCrimes crime)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (db = provider.GetProvider())
                    {

                        //db.Entry(crime).State = System.Data.Entity.EntityState.Modified;
                        //db.Entry(crime).Property(i => i.UserCrimesCategory).IsModified = true;

                        // Получаем список категорий из БД, которые есть у нарушения
                        var items = db.UserCrimesCategory.Where(i => i.UserCrimesId == crime.Id).ToList();
                        //items.ForEach(s => s.Id = crime.Id);

                        db.UserCrimesCategory.RemoveRange(items);

                        // Далее необходимо вставить айдишники
                        var sss = crime.UserCrimesCategory.ToList();
                        sss.ForEach(s => { s.UserCrimesId = crime.Id; s.Id = 0; s.UserCrimes = null; s.CrimesType = null; });
                        //crime.UserCrimesCategory.ToList().ForEach(s => s.Id = crime.Id);

                        db.UserCrimesCategory.AddRange(sss);

                        db.Entry(crime).State = System.Data.Entity.EntityState.Modified;

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
        /// Получить преступления пользователя
        /// </summary>
        /// <param name="ID">Айди социальной сети</param>
        /// <returns>Преступления</returns>
        public async Task<List<UserCrimes>> GetSocialNetworkCrimes(int ID)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (db = provider.GetProvider())
                    {
                        return db.UserCrimes.Include("UserCrimesCategory.CrimesType").Where(i => i.IdSocialNetworkUser == ID).ToList();
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            });
        }



        /// <summary>
        /// Загрузка типов преступлений
        /// </summary>
        /// <returns>Возвращаем список типов преступлений</returns>
        public async Task<List<CrimesType>> LoadCrimesCategory()
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (db = provider.GetProvider())
                    {
                        return db.CrimesType.ToList();
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            });
        }

        /// <summary>
        /// Удаление крайма
        /// </summary>
        /// <param name="crime">Крайм</param>
        /// <returns>Возвращает true, если успешно, иначе false</returns>
        public async Task<bool> RemoveCrime(UserCrimes crime)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (db = provider.GetProvider())
                    {
                        db.UserCrimes.Remove(db.UserCrimes.FirstOrDefault(i => i.Id == crime.Id));
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
    }
}
