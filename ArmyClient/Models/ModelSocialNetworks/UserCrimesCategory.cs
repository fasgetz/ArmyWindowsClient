namespace ArmyClient.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserCrimesCategory")]
    public partial class UserCrimesCategory
    {
        public int Id { get; set; }

        public int UserCrimesId { get; set; }

        public byte CrimesTypeId { get; set; }

        public virtual CrimesType CrimesType { get; set; }

        public virtual UserCrimes UserCrimes { get; set; }
    }
}
