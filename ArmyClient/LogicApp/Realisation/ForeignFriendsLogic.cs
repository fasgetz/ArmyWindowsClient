using ArmyClient.LogicApp.Interfaces;
using ArmyClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.LogicApp.Realisation
{
    class ForeignFriendsLogic : IForeignFriendsLogic
    {
        LogicProviderDB provider;
        ArmyDBContext db;

        public ForeignFriendsLogic(LogicProviderDB provider)
        {
            this.provider = provider;
        }


        /// <summary>
        /// Добавить иностранного друга в соц. сеть
        /// </summary>
        /// <param name="friend">Иностранный друг</param>
        /// <returns>Возвращает true, если успешно</returns>
        public bool AddForeignFriend(ForeignFriends friend)
        {
            try
            {
                using (db = provider.GetProvider())
                {
                    db.ForeignFriends.Add(friend);
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Получить список иностранных друзей социальной сети
        /// </summary>
        /// <param name="ID">Айди пользователя</param>
        /// <returns>Список иностранных друзей</returns>
        public async Task<List<ForeignFriends>> GetForeignFriends(int ID)
        {
            return await Task.Run(() =>
            {
                using (db = provider.GetProvider())
                {
                    try
                    {
                        // Отбираем в выборке нужные поля (без изображения), чтобы не нагружать лишний раз
                        var foreignfriends = (from friend in db.ForeignFriends.Include("Country")
                                              where friend.SocialNetworkUserID == ID
                                              select friend).ToList()
                                             .Select(x => new ForeignFriends() 
                                                { 
                                                    Id = x.Id, 
                                                    Name = x.Name,
                                                    Family = x.Family,
                                                    Surname = x.Surname,
                                                    SocialNetworkUserID = x.SocialNetworkUserID,
                                                    Country = x.Country
                                                }).ToList();

                        return foreignfriends;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            });
        }


        /// <summary>
        /// Получить иностранного друга по айди
        /// </summary>
        /// <param name="ID">Айди пользователя</param>
        /// <returns>Иностранный друг</returns>
        public async Task<ForeignFriends> GetOneForeignFriend(int ID)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (db = provider.GetProvider())
                    {
                        return db.ForeignFriends.Include("Country").FirstOrDefault(i => i.Id == ID);
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
