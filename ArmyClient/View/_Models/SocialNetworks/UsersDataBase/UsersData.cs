using ArmyClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.View._Models.SocialNetworks.UsersDataBase
{
    /// <summary>
    /// Модель отображения данных пользователей в главной таблице
    /// </summary>
    class UsersData
    {
        #region Дополнительные свойства


        public string GetFirstUS
        {
            get
            {
                if (UserSoldierService == null | UserSoldierService.Count == 0)
                    return "Нет сведений";

                return UserSoldierService.FirstOrDefault().SoldierUnit.Name;
            }
        }

        // Получить количество нарушений
        public int CrimesCount
        {
            get
            {
                return SocialNetworkUser.Where(i => i.UserCrimes.Count > 0).Sum(i => i.UserCrimes.Count);
            }
        }



        public string GetCountryCity
        {
            get => $"{CountryResidence?.Name}, {City1?.Name}";

        }

        // Получить причастность к ВЧ
        public string GetUS
        {
            get
            {
                if (UserSoldierService.Count != 0)
                    return "Да";

                return "Нет";
            }
        }

        // Получить ФИО
        public string GetFIO
        {
            get => $"{Family} {Name} {Surname}";
        }

        #endregion

        public int Id { get; set; }


        public string Name { get; set; }


        public string Family { get; set; }


        public string Surname { get; set; }
        public virtual ICollection<SocialNetworkUser> SocialNetworkUser { get; set; }
        public virtual City City1 { get; set; }
        public virtual Countries CountryResidence { get; set; }
        public virtual ICollection<UserSoldierService> UserSoldierService { get; set; }
    }
}
