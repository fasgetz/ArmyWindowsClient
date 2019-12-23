namespace ArmyClient.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Users
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
        public int GetCrimesCount
        {
            get
            {
                return UserCrimes.Where(i => i.IsCrime == true).Count();
            }
        }

        public string GetCountryCity
        {
            get => $"{Countries1.Name}, {CurrentCityResience}";
 
        }

        // Получить причастность к ВЧ
        public string GetUS
        {
            get
            {
                if (UserSoldierService == null)
                    return "Нет";

                return "Да";
            }
        }

        // Получить ФИО
        public string GetFIO
        {
            get => $"{Family} {Name} {Surname}";
        }

        #endregion

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            SocialNetworkUser = new HashSet<SocialNetworkUser>();
            UserCrimes = new HashSet<UserCrimes>();
            UserSoldierService = new HashSet<UserSoldierService>();
        }

        public int Id { get; set; }

        [StringLength(25)]
        public string Name { get; set; }

        [StringLength(25)]
        public string Family { get; set; }

        [StringLength(25)]
        public string Surname { get; set; }

        //[Column(TypeName = "Bytea")]
        public byte[] Photo { get; set; }

        //[Column(TypeName = "date")]
        public DateTime? DateBirth { get; set; }

        public byte? IdCountryBirth { get; set; }

        [StringLength(35)]
        public string CityBirth { get; set; }

        public byte? IdCurrentCountryResidence { get; set; }

        [StringLength(35)]
        public string CurrentCityResience { get; set; }

        [StringLength(150)]
        public string AddressResidence { get; set; }

        //[Column(TypeName = "text")]
        public string Characteristic { get; set; }

        public bool? IsMonitoring { get; set; }

        public byte? SocialStatusID { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(15)]
        public string phone { get; set; }

        public DateTime? DateOfEntry { get; set; }

        public virtual Countries Countries { get; set; }

        public virtual Countries Countries1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SocialNetworkUser> SocialNetworkUser { get; set; }

        public virtual SocialStatuses SocialStatuses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCrimes> UserCrimes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserSoldierService> UserSoldierService { get; set; }
    }
}
