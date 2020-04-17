using ArmyClient.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.Models.ModelSocialNetworks
{
    public class SocialNetworkAudio
    {
        [Key]
        public int Id { get; set; }

        public int SocialNetworkUserID { get; set; } // Айди социальной сети

        public string ArtistName { get; set; } // Имя исполнителя

        public string AudioName { get; set; } // Название аудиозаписи

        public DateTime? DateAddedSocNetw { get; set; } // Дата добавления аудио на странице

        public DateTime? DateAddedOnDB { get; set; } // Дата добавления группы на хранение в БД (для статистики)

        public int Duration { get; set; } // Продолжительность аудио в секундах
        public virtual SocialNetworkUser SocialNetworkUser { get; set; }
    }
}
