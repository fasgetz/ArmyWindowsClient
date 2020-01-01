using ArmyClient.LogicApp.Interfaces;
using ArmyClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                try
                {
                    using (db = provider.GetProvider())
                    {
                        db.UserCrimes.Add(crime);
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
    }
}
