namespace ArmyClient.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SoldierUnit")]
    public partial class SoldierUnit
    {
        #region Вспомогательные свойства

        public string GetSU
        {
            get => $"{Name} - {Affilation}";
        }

        #endregion


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SoldierUnit()
        {
            UserSoldierService = new HashSet<UserSoldierService>();
        }

        public short Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Affilation { get; set; }

        public byte? IdCountry { get; set; }

        [StringLength(35)]
        public string City { get; set; }

        [StringLength(150)]
        public string AddressResidence { get; set; }

        [Column(TypeName = "text")]
        public string AbountInform { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserSoldierService> UserSoldierService { get; set; }
    }
}
