using ArmyClient.Models.ModelExtremistMaterials;
using ArmyClient.ViewModel.Helpers;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace ArmyClient.ViewModel.ExtremistMaterial.DataBase
{
    class ExmDataBaseVM : MainVM
    {
        #region Свойства

        private string _searchtext;
        public string searchtext
        {
            get => _searchtext;
            set
            {
                _searchtext = value;
                OnPropertyChanged("searchtext");
            }
        }

        private ObservableCollection<Materials> _materials;
        public ObservableCollection<Materials> materials
        {
            get => _materials;
            set
            {
                _materials = value;
                OnPropertyChanged("materials");
            }
        }

        #endregion

        #region Команды

        // Команда по удалению изображения
        public DelegateCommand SearchText
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    if (searchtext != null)
                    {
                        ICollectionView cv = CollectionViewSource.GetDefaultView(materials);

                        cv.Filter = o =>
                        {
                            Materials material = o as Materials;
                            return (material.Material.IndexOf(searchtext, StringComparison.OrdinalIgnoreCase) != -1);
                        };
                    }
                });
            }
        }

        #endregion

        #region Вспомогательные методы

        private async void LoadData()
        {
            materials = new ObservableCollection<Materials>(await logic.ExtremistMaterialLogic.GetMaterialsAll());
        }


        #endregion

        public ExmDataBaseVM()
        {
            LoadData();
        }
    }
}
