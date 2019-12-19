namespace ArmyClient.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SocialNetworkUser")]
    public partial class SocialNetworkUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SocialNetworkUser()
        {
            ForeignFriends = new HashSet<ForeignFriends>();
            UserCrimes = new HashSet<UserCrimes>();
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public byte SocialNetworkId { get; set; }

        [Required]
        [StringLength(100)]
        public string WebAddress { get; set; }

        public bool Opened { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ForeignFriends> ForeignFriends { get; set; }

        public virtual SocialNetworkType SocialNetworkType { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCrimes> UserCrimes { get; set; }
    }
}
