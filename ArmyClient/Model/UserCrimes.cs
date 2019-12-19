namespace ArmyClient.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserCrimes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserCrimes()
        {
            UserCrimesCategory = new HashSet<UserCrimesCategory>();
        }

        public int Id { get; set; }

        public int IdUser { get; set; }

        public int? IdSocialNetworkUser { get; set; }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        public DateTime? DateLoad { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public virtual SocialNetworkUser SocialNetworkUser { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCrimesCategory> UserCrimesCategory { get; set; }
    }
}
