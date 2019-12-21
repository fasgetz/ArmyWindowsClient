using ArmyClient.Model;
using ArmyClient.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.ViewModel.Main
{
    class MainPageVM : MainVM
    {
        #region Свойства        

        private bool _facebook;
        public bool facebook
        {
            get => _facebook;
            set
            {
                _facebook = value;
                OnPropertyChanged("facebook");
            }
        }

        private bool _vk;
        public bool vk
        {
            get => _vk;
            set
            {
                _vk = value;
                OnPropertyChanged("vk");
            }
        }

        private bool _instagram;
        public bool instagram
        {
            get => _instagram;
            set
            {
                _instagram = value;
                OnPropertyChanged("instagram");
            }
        }


        private List<Model.Users> _users;
        public List<Model.Users> users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged("users");
            }
        }


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

        #region Команды

        // Команда по переходу на страницу добавить пользователя
        public DelegateCommand GoToAddUserPage
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    MyNavigation.GoAddUserPage();
                });
            }
        }

        // Команда найти пользователей
        public DelegateCommand SearchUsers
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    LoadUsers();
                });
            }
        }

        #endregion

        public MainPageVM()
        {
            // Выделяем память
            logic = new LogicApp.Realisation.LogicApp();
            SelectedType = new SocialNetworkType();
            MySocNetTypes = new ObservableCollection<SocialNetworkUser>();
            user = new Model.Users();
            user.IsMonitoring = false;
            vk = true;
            instagram = true;
            facebook = true;


            // Загружаем данные с БД
            LoadData();
        }

        #region Вспомогательные методы 

        private async void LoadUsers()
        {
            users = await logic.userLogic.GetUsersAsync(user, vk, instagram, facebook);
        }


        // Вспомогательный метод для загрузки данных
        private async void LoadData()
        {
            SocialNetworkTypesList = new ObservableCollection<SocialNetworkType>(await logic.socialNetworksLogic.LoadSocialNetworkTypesAsync());
            Countries = new ObservableCollection<Countries>(await logic.CountriesLogic.GetCountries());
            SocStatuses = new ObservableCollection<SocialStatuses>(await logic.SocStatusesLogic.GetSocialStatuses());
        }

        // Метод для загрузки В/Ч
        private async void loadunits(byte id)
        {
            SoldierUnits = new ObservableCollection<SoldierUnit>(await logic.SoldierUnitLogic.GetSoldierUnitsAsync(id));
        }

        #endregion


    }
}
