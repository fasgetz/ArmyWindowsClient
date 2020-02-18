using ArmyClient.Models.ModelExtremistMaterials;
using ArmyClient.ViewModel.Helpers;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ArmyClient.ViewModel.ExtremistMaterial.DataBase
{
    class ExmDataBaseVM : MainVM
    {
        #region Свойства

        private bool _enabledSearchBox;
        public bool enabledSearchBox
        {
            get => _enabledSearchBox;
            set
            {
                _enabledSearchBox = value;
                OnPropertyChanged("enabledSearchBox");
            }
        }


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

        // Команда по поиску
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
            await Task.Run(() =>
            {
                materials = new ObservableCollection<Materials>(logic.ExtremistMaterialLogic.GetMaterialsAll().Result);
            });
            

            enabledSearchBox = true;
        }


        #endregion

        public ExmDataBaseVM()
        {
            LoadData();

            //LoadData();
        }
    }
}
