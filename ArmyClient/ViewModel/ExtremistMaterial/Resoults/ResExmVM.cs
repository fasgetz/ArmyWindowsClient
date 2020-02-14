using ArmyClient.LogicApp.Helps;
using ArmyClient.Models.ModelExtremistMaterials;
using ArmyClient.View.ExtremistMaterials;
using ArmyClient.ViewModel.Helpers;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ArmyClient.ViewModel.ExtremistMaterial.Resoults
{

    #region Микро класс фильтрации

    class TypeFilter
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    #endregion


    class ResExmVM : MainVM
    {

        #region Свойства

        #region Фильтр

        private byte[] _Image;
        public byte[] Image
        {
            get => _Image;
            set
            {
                _Image = value;
                OnPropertyChanged("Image");
            }
        }


        // Выбранный фильтр
        private TypeFilter _selectedFilter;
        public TypeFilter selectedFilter
        {
            get => _selectedFilter;
            set
            {
                _selectedFilter = value;
                text = string.Empty;
                OnPropertyChanged("selectedFilter");
            }
        }

        // Строка поиска
        private string _text;
        public string text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged("text");
            }
        }

        // Фильтр для поиска
        ObservableCollection<TypeFilter> _filter;
        public ObservableCollection<TypeFilter> filter
        {
            get => _filter;
            set
            {
                _filter = value;
                OnPropertyChanged("filter");
            }
        }

        #endregion


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

        // Удалить изображение
        public DelegateCommand RemoveImage
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    if (material.ScreenShot != null)
                    {
                        material.ScreenShot = null;
                        Image = null;
                    }
                        
                });
            }
        }
        // Добавить
        public DelegateCommand AddImage
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Файлы изображений (*.jpg, *.png)|*.jpg;*.png";

                    if (openFileDialog.ShowDialog() == true)
                    {
                        string FilePath = openFileDialog.FileName; // Путь файла изображения

                        material.ScreenShot = ImageLogic.GetImageBinary(FilePath); // Изображение в бинарном формате                        
                        Image = material.ScreenShot;
                    }
                });
            }
        }


        // Команда по поиску
        public DelegateCommand SearchText
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    if (selectedFilter != null && text != null)
                    {
                        ICollectionView cv = CollectionViewSource.GetDefaultView(materials);

                        cv.Filter = o =>
                        {
                            FoundMaterials material = o as FoundMaterials;
                            switch (selectedFilter.Id)
                            {
                                // По номеру статьи
                                case (1):
                                    return (material.IdMaterial.ToString().StartsWith(text));
                                // По веб адресу
                                case (2):
                                    return (material.WebAddress.IndexOf(text, StringComparison.OrdinalIgnoreCase) != -1);
                                // По дате добавления
                                case (3):
                                    return (material.DateOfEntry.ToString().StartsWith(text));
                                default:
                                    return false;
                            }
                            
                        };
                    }
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
                        MessageBox.Show("Такой веб адрес уже есть в базе данных!");

                        return false;
                    }
                }
            });

            if (added == true)
            {
                // Если успешно, то добавь в UI список и обнули
                LoadMaterials();
                material = new FoundMaterials();
                Image = null;
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
            filter = new ObservableCollection<TypeFilter>()
            {
                new TypeFilter() { Id = 1, Name = "№ статьи" },
                new TypeFilter() { Id = 2, Name = "Веб адрес" },
                new TypeFilter() { Id = 3, Name = "Дата добавления" }
            };


            ICollection<TypeFilter> list = new ObservableCollection<TypeFilter>();
        }
    }
}
