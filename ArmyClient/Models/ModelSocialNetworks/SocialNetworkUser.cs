namespace ArmyClient.Model
{
    using ArmyClient.Models.ModelSocialNetworks;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SocialNetworkUser")]
    public partial class SocialNetworkUser
    {

        #region Дополнительные свойства

        public string GetSocialName
        {
            get => $"{SocialNetworkType?.Name} - {WebAddress}";
        }

        #endregion


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SocialNetworkUser()
        {
            ForeignFriends = new HashSet<ForeignFriends>();
            Groups = new HashSet<SocialNetworkGroup>();
            UserCrimes = new HashSet<UserCrimes>();
            SocialNetworkUserSessions = new HashSet<SocialNetworkSessions>();
        }

        public int Id { get; set; }

        public int IdUser { get; set; }

        public byte SocialNetworkId { get; set; }

        [Required]
        [StringLength(100)]
        public string WebAddress { get; set; }

        public bool Opened { get; set; }

        public bool? isChecked { get; set; } // Свойство которое указывает, необходимо ли чекать онлайн пользователя

        // Список сессий пользователя
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SocialNetworkSessions> SocialNetworkUserSessions { get; set; }

        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ForeignFriends> ForeignFriends { get; set; }
        public virtual ICollection<SocialNetworkGroup> Groups { get; set; }

        public virtual SocialNetworkType SocialNetworkType { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCrimes> UserCrimes { get; set; }
    }
}
