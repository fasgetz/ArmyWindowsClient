namespace ArmyClient.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserSoldierService")]
    public partial class UserSoldierService
    {
        public int Id { get; set; }

        public int? IdUser { get; set; }

        public short? IdSoldierUnit { get; set; }

        //[Column(TypeName = "date")]
        public DateTime? DateStart { get; set; }

        //[Column(TypeName = "date")]
        public DateTime? DateEnd { get; set; }

        [StringLength(50)]
        public string Rank { get; set; }

        [StringLength(50)]
        public string Position { get; set; }

        //[Column(TypeName = "text")]
        public string Data { get; set; }

        public virtual SoldierUnit SoldierUnit { get; set; }

        public virtual Users Users { get; set; }
    }
}
