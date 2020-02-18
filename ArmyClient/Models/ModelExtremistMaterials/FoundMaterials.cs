namespace ArmyClient.Models.ModelExtremistMaterials
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FoundMaterials
    {

        #region Дополнительные свойства валидации

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "IdMaterial":
                        if ((IdMaterial < 0) || (IdMaterial > 10000))
                        {
                            error = "Номер должен быть соответствующим пункта экстремисткого материала";
                        }
                        break;
                    case "Name":
                        //Обработка ошибок для свойства Name
                        break;
                    case "Position":
                        //Обработка ошибок для свойства Position
                        break;
                }
                return error;
            }
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        public int Id { get; set; }

        public int IdMaterial { get; set; }

        [StringLength(150)]
        public string WebAddress { get; set; }

        public DateTime? DateOfEntry { get; set; }

        public byte[] ScreenShot { get; set; }

        public DateTime? DateOfLoading { get; set; }

        public virtual Materials Materials { get; set; }
    }
}
