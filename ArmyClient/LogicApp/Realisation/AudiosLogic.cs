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
    class AudiosLogic : IAudiosLogic
    {
        LogicProviderDB provider;
        ArmyDBContext db;

        public AudiosLogic(LogicProviderDB provider)
        {
            this.provider = provider;
        }

        /// <summary>
        /// Метод добавления аудио в БД
        /// </summary>
        /// <param name="audio">Аудиозапись</param>
        /// <returns>Возвращает true, если успешно</returns>
        public bool AddAudio(SocialNetworkAudio audio)
        {
            using (db = provider.GetProvider())
            {
                db.SocialNetworkUserAudios.Add(audio);
                db.SaveChanges();

                return true;
            }
        }

        /// <summary>
        /// Получить список аудиозаписей по айди социальной сети пользователей в бд
        /// </summary>
        /// <param name="ID">Айди социальной сети в БД</param>
        /// <returns>Список аудио</returns>
        public async Task<SocialNetworkAudio[]> GetAudio(int ID)
        {
            return await Task.Run(() =>
            {
                using (db = provider.GetProvider())
                {
                    return db.SocialNetworkUserAudios.Where(i => i.SocialNetworkUserID == ID).ToArray();
                }
            });
        }


        /// <summary>
        /// Получить аудио юзера по названию
        /// </summary>
        /// <param name="UserID">Айди социальной сети пользователя</param>
        /// <param name="NameAudio">Название аудио</param>
        /// <returns>Если есть, то вернет аудио, иначе null</returns>
        public async Task<SocialNetworkAudio> GetOneAudio(int UserID, string NameAudio)
        {
            return await Task.Run(() =>
            {
                using (db = provider.GetProvider())
                {
                    return db.SocialNetworkUserAudios.FirstOrDefault(i => i.SocialNetworkUserID == UserID && i.AudioName == NameAudio);
                }
            });
        }
    }
}
