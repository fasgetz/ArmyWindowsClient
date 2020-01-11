using ArmyClient.Models.ModelExtremistMaterials;
using ArmyClient.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ArmyClient.ViewModel.ExtremistMaterial.Resoults
{
    class ResExmVM : MainVM
    {
        

        // Список найденных экстремистских материалов
        ObservableCollection<FoundMaterials> _materials;
        public ObservableCollection<FoundMaterials> materials
        {
            get => _materials;
            set
            {
                _materials = value;
                OnPropertyChanged("materials");
            }
        }

        // Добавляемый материал
        private FoundMaterials _material;
        public FoundMaterials material
        {
            get => _material;
            set
            {
                _material = value;
                OnPropertyChanged("material");
            }
        }

        

        #region Команды

        public DelegateCommand AddMaterial
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    material.DateOfEntry = DateTime.Now;
                    materials.Add(material);
                    material = new FoundMaterials();
                });
            }
        }

        #endregion

        public ResExmVM()
        {
            material = new FoundMaterials();

            using (var db = new ExmMaterialsDB())
            {
                materials = new ObservableCollection<FoundMaterials>(db.FoundMaterials.ToList());
            }

        }
    }
}
