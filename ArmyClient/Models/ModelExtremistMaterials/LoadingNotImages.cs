namespace ArmyClient.Models.ModelExtremistMaterials
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LoadingNotImages
    {
        [StringLength(150)]
        public string WebAddress { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdMaterial { get; set; }

        public string Material { get; set; }

        public DateTime? DateOfEntry { get; set; }

        public DateTime? DateOfLoading { get; set; }
    }
}
