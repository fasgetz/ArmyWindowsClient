using ArmyClient.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.Models.ModelSocialNetworks
{
    public class SocialNetworkGroup
    {
        [Key]
        public int Id { get; set; }

        public int SocialNetworkUserID { get; set; } // Айди социальной сети

        public string Name { get; set; } // Название группы
        public string GroupAddress { get; set; } // Адрес группы
        public string Description { get; set; } // Описание

        public int? MembersCount { get; set; } // Количество участников

        [Column(TypeName = "date")]
        public DateTime? DateAddedOnDB { get; set; } // Дата добавления группы на хранение в БД (для статистики)

        public bool GroupPublicity { get; set; } // Закрыта ли группа

        public virtual SocialNetworkUser SocialNetworkUser { get; set; }

    }
}
