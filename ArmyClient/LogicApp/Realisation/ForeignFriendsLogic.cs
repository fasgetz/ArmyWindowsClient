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
                try
                {
                    using (db = provider.GetProvider())
                    {
                        return db.ForeignFriends.Include("Country").Where(i => i.SocialNetworkUserID == ID).ToList();
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
