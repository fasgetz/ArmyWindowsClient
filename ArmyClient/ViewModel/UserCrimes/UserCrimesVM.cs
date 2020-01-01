using ArmyClient.LogicApp.Helps;
using ArmyClient.Model;
using ArmyClient.ViewModel.Helpers;
using ArmyClient.ViewModel.Users;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.ViewModel.UserCrimes
{
    class UserCrimesVM : AboutUserPageVM
    {

        #region Свойства

        // Выбранный крайм в списке
        private CrimesType _SelectedCrimeOnLV;
        public CrimesType SelectedCrimeOnLV
        {
            get => _SelectedCrimeOnLV;
            set
            {
                _SelectedCrimeOnLV = value;
                OnPropertyChanged("SelectedCrimeOnLV");
            }
        }

        // Для отображения в списке
        private ObservableCollection<CrimesType> _MyCrimesCategory;
        public ObservableCollection<CrimesType> MyCrimesCategory
        {
            get => _MyCrimesCategory;
            set
            {
                _MyCrimesCategory = value;
                OnPropertyChanged("MyCrimesCategory");
            }
        }

        private CrimesType _SelectedCategory;
        public CrimesType SelectedCategory
        {
            get => _SelectedCategory;
            set
            {
                _SelectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        // Выбранная социальная сеть
        private SocialNetworkUser _selectedSocialNetwork;
        public SocialNetworkUser selectedSocialNetwork
        {
            get => _selectedSocialNetwork;
            set
            {
                _selectedSocialNetwork = value;
                OnPropertyChanged("selectedSocialNetwork");
            }
        }

        // Преступление
        private Model.UserCrimes _Crime;
        public Model.UserCrimes Crime
        {
            get => _Crime;
            set
            {
                _Crime = value;
                //ImageBytes = null;
                OnPropertyChanged("Crime");
            }
        }


        // Преступление
        private Model.UserCrimes _MyCrime;
        public Model.UserCrimes MyCrime
        {
            get => _MyCrime;
            set
            {
                _MyCrime = value;
                Crime = value;
                if (value != null)
                    ImageBytes = value.Photo;

                OnPropertyChanged("MyCrime");
            }
        }

        // Преступления пользователя
        private ObservableCollection<Model.UserCrimes> _Crimes;
        public ObservableCollection<Model.UserCrimes> Crimes
        {
            get => _Crimes;
            set
            {
                _Crimes = value;
                OnPropertyChanged("Crimes");
            }
        }


        // Типы преступлений
        private ObservableCollection<CrimesType> _CrimesCategory;
        public ObservableCollection<CrimesType> CrimesCategory
        {
            get => _CrimesCategory;
            set
            {
                _CrimesCategory = value;
                OnPropertyChanged("CrimesCategory");
            }
        }

        #endregion

        #region Вспомогательные методы

        private async void LoadData()
        {
            if (CrimesCategory == null)
                CrimesCategory = new ObservableCollection<CrimesType>(await logic.CrimesLogic.LoadCrimesCategory());

            Crimes = new ObservableCollection<Model.UserCrimes>(await logic.CrimesLogic.GetSocialNetworkCrimes(selectedSocialNetwork.Id));
        }

        private async void UpdateCrime()
        {
            bool updated = await logic.CrimesLogic.EditCrime(Crime);

            // Если успешно, то прогрузи
            if (updated == true)
                LoadData();


            ImageBytes = null;
            Crime = null;
            MyCrime = null;
        }


        private async void AddCrimeDB()
        {

            // Добавляем преступление в БД
            bool added = await logic.CrimesLogic.AddCrime(Crime);

            // Если успешно, то прогрузи
            if (added == true)
                LoadData();


            ImageBytes = null;
            Crime = null;
            MyCrime = null;
        }

        #endregion

        #region Команды

        // Команда по удалению категории из списка
        public DelegateCommand RemoveCrimesCategory
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    if (SelectedCrimeOnLV != null)
                    {
                        SelectedCategory = SelectedCrimeOnLV;
                        MyCrimesCategory.Remove(SelectedCategory);
                        CrimesCategory.Add(SelectedCategory);
                        SelectedCategory = null;
                    }
                });
            }
        }


        // Команда по добавлению категории в список
        public DelegateCommand AddCategory
        {
            get
            {
                return new DelegateCommand(obj =>
                {   
                    MyCrimesCategory.Add(SelectedCategory);
                    CrimesCategory.Remove(SelectedCategory);
                    SelectedCategory = null;
                });
            }
        }

        // Команда по добавлению изображения нарушению
        public DelegateCommand AddCrimeImage
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

                        ImageBytes = ImageLogic.GetImageBinary(FilePath); // Изображение в бинарном формате
                        Crime.Photo = ImageBytes;
                    }

                });
            }
        }

        // Команда по добавлению изображения нарушению
        public DelegateCommand RemoveCrimeImage
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    ImageBytes = null;
                    Crime.Photo = ImageBytes;
                });
            }
        }

        // Команда по добавлению нарушения
        public DelegateCommand AddCrime
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    Crime = new Model.UserCrimes()
                    {
                        DateEnty = DateTime.Now,
                        IdSocialNetworkUser = selectedSocialNetwork.Id
                    };

                    //MyCrime = null;
                    ImageBytes = null;
                });
            }
        }

        // Команда по сохранению нарушения
        public DelegateCommand SaveCrime
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    if (Crime != null)
                    {
                        // Добавляем преступление в БД, если айди == 0, т.к. объект только создан
                        if (Crime.Id == 0)
                            AddCrimeDB();

                        // Иначе обновляем объект в БД
                        UpdateCrime();
                    }

                });
            }
        }


        #endregion
        
        public UserCrimesVM(Model.Users user, SocialNetworkUser selectedSocialNetwork)
        {
            this.user = user;
            this.selectedSocialNetwork = selectedSocialNetwork;
            ImageBytes = null;
            MyCrimesCategory = new ObservableCollection<CrimesType>();

            // Загружаем данные
            LoadData();
        }


    }
}
