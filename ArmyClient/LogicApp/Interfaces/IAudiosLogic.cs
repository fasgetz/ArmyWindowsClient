using ArmyClient.Models.ModelSocialNetworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.LogicApp.Interfaces
{
    interface IAudiosLogic
    {
        /// <summary>
        /// Метод добавления аудио в БД
        /// </summary>
        /// <param name="audio">Аудиозапись</param>
        /// <returns>Возвращает true, если успешно</returns>
        bool AddAudio(SocialNetworkAudio audio);


        /// <summary>
        /// Получить список аудиозаписей по айди социальной сети пользователей в бд
        /// </summary>
        /// <param name="ID">Айди социальной сети в БД</param>
        /// <returns>Список аудио</returns>
        Task<SocialNetworkAudio[]> GetAudio(int ID);

        /// <summary>
        /// Получить аудио юзера по названию
        /// </summary>
        /// <param name="UserID">Айди социальной сети пользователя</param>
        /// <param name="NameAudio">Название аудио</param>
        /// <returns>Если есть, то вернет аудио, иначе null</returns>
        Task<SocialNetworkAudio> GetOneAudio(int UserID, string NameAudio);
    }
}
