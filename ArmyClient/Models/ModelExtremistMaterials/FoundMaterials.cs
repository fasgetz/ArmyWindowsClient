namespace ArmyClient.Models.ModelExtremistMaterials
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FoundMaterials : IDataErrorInfo
    {
        public int Id { get; set; }

        public int IdMaterial { get; set; }

        [StringLength(150)]
        [Index(IsUnique = true)]
        public string WebAddress { get; set; }

        public DateTime? DateOfEntry { get; set; }

        public virtual Materials Materials { get; set; }


        #region �������������� �������� ���������

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
                            error = "����� ������ ���� ��������������� ������ �������������� ���������";
                        }
                        break;
                    case "Name":
                        //��������� ������ ��� �������� Name
                        break;
                    case "Position":
                        //��������� ������ ��� �������� Position
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
    }
}
