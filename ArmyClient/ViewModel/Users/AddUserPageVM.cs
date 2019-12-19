using ArmyClient.LogicApp;
using ArmyClient.LogicApp.Helps;
using ArmyClient.LogicApp.Realisation;
using ArmyClient.Model;
using ArmyClient.ViewModel.Helpers;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace ArmyClient.ViewModel.Users
{
    class AddUserPageVM : MainVM
    {


        #region Свойства        

        // Выбранный социальный статус
        private SocialStatuses _SelectedSocStatus;
        public SocialStatuses SelectedSocStatus
        {
            get => _SelectedSocStatus;
            set
            {
                _SelectedSocStatus = value;
                user.SocialStatusID = value.IdStatus;
                OnPropertyChanged("SelectedSocStatus");
            }
        }

        // Страны
        private ObservableCollection<SocialStatuses> _SocStatuses;
        public ObservableCollection<SocialStatuses> SocStatuses
        {
            get => _SocStatuses;
            set
            {
                _SocStatuses = value;
                OnPropertyChanged("SocStatuses");
            }
        }

        // Страны
        private ObservableCollection<Countries> _Countries;
        public ObservableCollection<Countries> Countries
        {
            get => _Countries;
            set
            {
                _Countries = value;
                OnPropertyChanged("Countries");
            }
        }

        // Выбранная страна проживания
        private Countries _SelectedCountryUS;
        public Countries SelectedCountryUS
        {
            get => _SelectedCountryUS;
            set
            {
                _SelectedCountryUS = value;
                user.IdCurrentCountryResidence = value.Id;
                loadunits(value.Id);
                OnPropertyChanged("SelectedCountryUS");
            }
        }

        // Выбранная страна рождения
        private Countries _SelectedCountryBirth;
        public Countries SelectedCountryBirth
        {
            get => _SelectedCountryBirth;
            set
            {
                _SelectedCountryBirth = value;
                user.IdCountryBirth = value.Id;
                OnPropertyChanged("SelectedCountryBirth");
            }
        }

        // Изображение в байтах
        byte[] _ImageBytes;                         
        public byte[] ImageBytes
        {
            get => _ImageBytes;
            set
            {
                _ImageBytes = value;
                OnPropertyChanged("ImageBytes");
            }
        }

        // Данные пользователя
        private Model.Users _user;
        public Model.Users user
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged("user");
            }
        }

        // Веб адрес соц сети
        private string _WebAddress;
        public string WebAddress
        {
            get => _WebAddress;
            set
            {
                _WebAddress = value;
                OnPropertyChanged("WebAddress");
            }
        }

        // Тип соц сети пользователя
        private SocialNetworkType _selectedType;
        public SocialNetworkType SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value;
                OnPropertyChanged("SelectedType");
            }
        }

        // Список соц сетей пользователя
        private ObservableCollection<SocialNetworkUser> _MySocNetTypes;
        public ObservableCollection<SocialNetworkUser> MySocNetTypes
        {
            get => _MySocNetTypes;
            set
            {
                _MySocNetTypes = value;
                OnPropertyChanged("_MySocNetTypes");
            }
        }

        // Список соц сетей из БД
        private ObservableCollection<SocialNetworkType> _SocialNetworkTypesList;
        public ObservableCollection<SocialNetworkType> SocialNetworkTypesList
        {
            get => _SocialNetworkTypesList;
            set
            {
                _SocialNetworkTypesList = value;
                OnPropertyChanged("SocialNetworkTypesList");
            }
        }

        // Список В/Ч из БД
        private ObservableCollection<SoldierUnit> _SoldierUnits;
        public ObservableCollection<SoldierUnit> SoldierUnits
        {
            get => _SoldierUnits;
            set
            {
                _SoldierUnits = value;
                OnPropertyChanged("SoldierUnits");
            }
        }

        #endregion

        #region Секция команд

        // Команда по добавлению соц. сети пользователю
        public DelegateCommand AddSocNetType
        {
            get
            {
                return new DelegateCommand(obj =>
                {

                    MySocNetTypes.Add(new SocialNetworkUser() { WebAddress = WebAddress, SocialNetworkId = SelectedType.Id});
                    user.SocialNetworkUser.Add(new SocialNetworkUser() { SocialNetworkId = SelectedType.Id, WebAddress = WebAddress });
                });
            }
        }

        // Команда по добавлению пользователя в БД
        public DelegateCommand AddUser
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    MyNavigation.GoToTest();

                });
            }
        }

        // Команда вернуться назад
        public DelegateCommand GoBack
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    MyNavigation.navigation.GoBack();

                });
            }
        }

        // Метод по добавлению изображения
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

                        ImageBytes = ImageLogic.GetImageBinary(FilePath); // Изображение в бинарном формате
                        user.Photo = ImageBytes;
                    }
                });
            }
        }

        #endregion

        public AddUserPageVM()
        {
            // Выделяем память
            logic = new LogicApp.Realisation.LogicApp();
            SelectedType = new SocialNetworkType();
            MySocNetTypes = new ObservableCollection<SocialNetworkUser>();
            user = new Model.Users();
            

            // Загружаем данные с БД
            LoadData();
        }

        // Вспомогательный метод для загрузки данных
        private async void LoadData()
        {            
            SocialNetworkTypesList =  new ObservableCollection<SocialNetworkType>(await logic.socialNetworksLogic.LoadSocialNetworkTypesAsync());
            Countries = new ObservableCollection<Countries>(await logic.CountriesLogic.GetCountries());
            SocStatuses = new ObservableCollection<SocialStatuses>(await logic.SocStatusesLogic.GetSocialStatuses());
        }

        // Метод для загрузки В/Ч
        private async void loadunits(byte id)
        {
            SoldierUnits = new ObservableCollection<SoldierUnit>(await logic.SoldierUnitLogic.GetSoldierUnitsAsync(id));
        }
    }
}
