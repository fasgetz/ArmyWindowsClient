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

        #region Свойства

        // Содержимое статьи загрузить
        private string _tooltiptext;
        public string tooltiptext
        {
            get => _tooltiptext;
            set
            {
                _tooltiptext = value;
                OnPropertyChanged("tooltiptext");
            }
        }


        private FoundMaterials _SelectedMaterial;
        public FoundMaterials SelectedMaterial
        {
            get => _SelectedMaterial;
            set
            {
                _SelectedMaterial = value;
                OnPropertyChanged("SelectedMaterial");
            }
        }

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

        #endregion

        #region Команды

        // Копировать ссылку в буффер обмена
        public DelegateCommand EnteredMouse
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    MessageBox.Show("mouse is entered");
                });
            }
        }

        // Копировать ссылку в буффер обмена
        public DelegateCommand CopyBuffer
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    if (SelectedMaterial != null)
                        Clipboard.SetText($"{SelectedMaterial.WebAddress}");

                });
            }
        }

        // Добавить материал в бд
        public DelegateCommand AddMaterial
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    material.DateOfEntry = DateTime.Now;

                    // Добавляем в бд
                    AddMaterialDB();

                });
            }
        }

        #endregion

        #region Вспомогательные методы




        private async void AddMaterialDB()
        {
            bool added = await Task.Run(() =>
            {
                using (var db = new ExmMaterialsDB())
                {
                    try
                    {
                        db.FoundMaterials.Add(material);
                        db.SaveChanges();

                        return true;

                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException)
                    {
                        MessageBox.Show("Введите правильный № экстремисткого материала!");

                        return false;
                    }
                }
            });

            if (added == true)
            {
                // Если успешно, то добавь в UI список и обнули
                LoadMaterials();
                material = new FoundMaterials();
            }

        }


        private async void LoadMaterials()
        {
            await Task.Run(() =>
            {
                using (var db = new ExmMaterialsDB())
                {
                    materials = new ObservableCollection<FoundMaterials>(db.FoundMaterials.Include("Materials").ToList());                    
                }
            });
        }
        #endregion




        public ResExmVM()
        {
            material = new FoundMaterials();

            LoadMaterials();

        }
    }
}
