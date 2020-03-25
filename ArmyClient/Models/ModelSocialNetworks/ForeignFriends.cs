namespace ArmyClient.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ForeignFriends
    {

        #region Дополнительные свойства

        public string GetFioCountry
        {
            get => $"{Name} {Family} - {Country?.Name}";
        }

        #endregion

        public int Id { get; set; }

        public int SocialNetworkUserID { get; set; }

        [StringLength(60)]
        public string WebAddress { get; set; }

        [StringLength(25)]
        public string Name { get; set; }

        [StringLength(25)]
        public string Family { get; set; }

        [StringLength(25)]
        public string Surname { get; set; }

        public int? IdCity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDay { get; set; }

        public byte[] Photo { get; set; }

        public virtual City City { get; set; }

        // Страна
        public virtual Countries Country { get; set; }
        public byte? CountryId { get; set; }


        public virtual SocialNetworkUser SocialNetworkUser { get; set; }
    }
}
