using ArmyClient.LogicApp.Interfaces;
using ArmyClient.Model;
using ArmyClient.Models.ModelSocialNetworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.LogicApp.Realisation
{
    class GroupsLogic : IGroupsLogic
    {
        LogicProviderDB provider;
        ArmyDBContext db;

        public GroupsLogic(LogicProviderDB provider)
        {
            this.provider = provider;
        }


        /// <summary>
        /// Метод добавления группы в БД
        /// </summary>
        /// <param name="group">Группа</param>
        /// <returns>Возвращает true, если успешно</returns>
        public bool AddGroup(SocialNetworkGroup group)
        {
            using (db = provider.GetProvider())
            {
                db.SocialNetworkUserGroups.Add(group);
                db.SaveChanges();

                return true;
            }            
        }

        /// <summary>
        /// Получить список групп по айди социальной сети пользователей в бд
        /// </summary>
        /// <param name="ID">Айди социальной сети в БД</param>
        /// <returns>Список групп</returns>
        public async Task<List<SocialNetworkGroup>> GetGroups(int ID)
        {
            return await Task.Run(() =>
            {
                using (db = provider.GetProvider())
                {
                    return db.SocialNetworkUserGroups.Where(i => i.SocialNetworkUserID == ID).ToList();
                }
            });
        }

        /// <summary>
        /// Получить группу юзера по названию
        /// </summary>
        /// <param name="UserID">Айди социальной сети пользователя</param>
        /// <param name="NameGroup">Название группы</param>
        /// <returns>Если есть, то вернет группу, иначе null</returns>
        public async Task<SocialNetworkGroup> GetOneGroup(int UserID, string NameGroup)
        {
            return await Task.Run(() =>
            {
                using (db = provider.GetProvider())
                {
                    return db.SocialNetworkUserGroups.FirstOrDefault(i => i.SocialNetworkUserID == UserID && i.Name == NameGroup);
                }
            });
        }
    }
}
