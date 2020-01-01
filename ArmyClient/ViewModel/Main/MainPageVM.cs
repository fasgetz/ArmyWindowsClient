using ArmyClient.LogicApp.Helps;
using ArmyClient.Model;
using ArmyClient.ViewModel.Helpers;
using Microsoft.Win32;
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

        private ObservableCollection<Model.SoldierUnit> _UserSoldierServices;
        public ObservableCollection<Model.SoldierUnit> UserSoldierServices
        {
            get => _UserSoldierServices;
            set
            {
                _UserSoldierServices = value;
                OnPropertyChanged("UserSoldierServices");
            }
        }


        private Model.Users _SelectedUser;
        public Model.Users SelectedUser
        {
            get => _SelectedUser;
            set
            {
                _SelectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        #region Социальные сети

        private bool _odnoklassniki;
        public bool odnoklassniki
        {
            get => _odnoklassniki;
            set
            {
                _odnoklassniki = value;
                OnPropertyChanged("odnoklassniki");
            }
        }

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

        #endregion


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

        #region Страны - города

        // Список стран
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


        // Города выбранной страны проживания
        private ObservableCollection<City> _CitiesResidence;
        public ObservableCollection<City> CitiesResidence
        {
            get => _CitiesResidence;
            set
            {
                _CitiesResidence = value;
                OnPropertyChanged("CitiesResidence");
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
                LoadResidenceCities(value.Id); // Загружаем города

                //user.City1.CountryId = value.Id;

                // Загружаем В/Ч страны
                LoadUnitsCountry(value.Id);

                OnPropertyChanged("SelectedCountryUS");
            }
        }

        // Выбранный город проживания
        private City _SelectedCityResidence;
        public City SelectedCityResidence
        {
            get => _SelectedCityResidence;
            set
            {
                _SelectedCityResidence = value;

                if (value != null)
                {                    
                    user.CurrentCityResience_Id = value.Id;

                    // Загружаем В/Ч города
                    LoadUnitsCity(value.Id);
                }
                    
                else
                    user.CurrentCityResience_Id = null;


                OnPropertyChanged("SelectedCityResidence");
            }
        }

        // Выбранный город рождения
        private City _SelectedCityBirth;
        public City SelectedCityBirth
        {
            get => _SelectedCityBirth;
            set
            {
                _SelectedCityBirth = value;

                if (value != null)
                    user.CityBirth_Id = value.Id;
                else
                    user.CityBirth_Id = null;

                OnPropertyChanged("SelectedCityBirth");
            }
        }

        // Города выбранной страны рождения
        private ObservableCollection<City> _CitiesBirthCountry;
        public ObservableCollection<City> CitiesBirthCountry
        {
            get => _CitiesBirthCountry;
            set
            {
                _CitiesBirthCountry = value;
                OnPropertyChanged("CitiesBirthCountry");
            }
        }

        // Выбранная страна рождения
        private Countries _SelectedCountryBirth;
        public Countries SelectedCountryBirth
        {
            get
            {
                return _SelectedCountryBirth;
            }
            set
            {
                _SelectedCountryBirth = value;
                LoadBirthCities(value.Id);

                //user.City.CountryId = value.Id;
                OnPropertyChanged("SelectedCountryBirth");
            }
        }


        #endregion


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
                if (user.Photo != null)
                    ImageBytes = user.Photo;
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
                OnPropertyChanged("MySocNetTypes");
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

        private SoldierUnit _SelectedSoldierUnit;
        public SoldierUnit SelectedSoldierUnit
        {
            get => _SelectedSoldierUnit;
            set
            {
                _SelectedSoldierUnit = value;
                OnPropertyChanged("SelectedSoldierUnit");
            }
        }

        private SocialNetworkUser _SelectedSocialNetwork;
        public SocialNetworkUser SelectedSocialNetwork
        {
            get => _SelectedSocialNetwork;
            set
            {
                _SelectedSocialNetwork = value;
                OnPropertyChanged("SelectedSocialNetwork");
            }
        }

        #endregion

        #region Команды

        // Команда по удалению изображения
        public DelegateCommand RemoveImage
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    ImageBytes = null;
                    user.Photo = null;
                    //Crimes.Add(new Model.UserCrimes() { Id = 123 });

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


        // Команда удаления социальной сети из списка добавленных
        public DelegateCommand RemoveSocNetType
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    if (SelectedSocialNetwork != null)
                    {
                        var item = MySocNetTypes.FirstOrDefault(i => i.GetSocialName == SelectedSocialNetwork.GetSocialName);

                        MySocNetTypes.Remove(item);
                        user.SocialNetworkUser = MySocNetTypes.ToList();
                        SelectedSocialNetwork = null;
                    }
                });
            }
        }



        // Команда добавления службы пользователю
        public DelegateCommand AddSoldierService
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    if (SelectedSoldierUnit != null)
                    {
                        UserSoldierService service = new UserSoldierService()
                        {
                            IdSoldierUnit = SelectedSoldierUnit.Id,
                            IdUser = user.Id
                        };
                        //service.IdSoldierUnit = SelectedSoldierUnit.Id;
                        //service.IdUser = user.Id;
                        //service.SoldierUnit = SelectedSoldierUnit;

                        user.UserSoldierService.Add(service);
                        UserSoldierServices.Add(SoldierUnits.Where(i => i.Id == service.IdSoldierUnit).FirstOrDefault());
                        SoldierUnits.Remove(SoldierUnits.Where(i => i.Id == service.IdSoldierUnit).FirstOrDefault());

                        SelectedSoldierUnit = null;
                    }
                });
            }
        }


        // Команда по переходу на страницу добавить пользователя

        public DelegateCommand GoToAboutUserPage
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    if (SelectedUser != null)
                        MyNavigation.GoToAboutUser(SelectedUser.Id);
                });
            }
        }

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
            //SelectedType = new SocialNetworkType();
            MySocNetTypes = new ObservableCollection<SocialNetworkUser>();
            user = new Model.Users() { City1 = new City(), City = new City() };
            user.IsMonitoring = false;
            UserSoldierServices = new ObservableCollection<SoldierUnit>();

            // Загружаем данные с БД
            LoadData();
        }

        public MainPageVM(bool WatchMod)
            :this()
        {
            vk = true;
            instagram = true;
            facebook = true;
            odnoklassniki = true;
        }

        /// <summary>
        /// Конструктор, который прогружает одного юзера
        /// </summary>
        /// <param name="UserID"></param>
        public MainPageVM(int UserID)
            :this()
        {

        }

        #region Вспомогательные методы 

        // Загрузка городов страны рождения
        protected async void LoadBirthCities(byte idCountry)
        {
            CitiesBirthCountry = new ObservableCollection<City>(await logic.citiesLogic.GetCities(idCountry));
        }

        // Загрузка городов страны проживания
        protected async void LoadResidenceCities(byte idCountry)
        {
            CitiesResidence = new ObservableCollection<City>(await logic.citiesLogic.GetCities(idCountry));
        }

        private async void LoadUsers()
        {
            users = await logic.userLogic.GetUsersAsync(user, vk, instagram, facebook, odnoklassniki);
        }


        // Вспомогательный метод для загрузки данных
        private async void LoadData()
        {
            SocialNetworkTypesList = new ObservableCollection<SocialNetworkType>(await logic.socialNetworksLogic.LoadSocialNetworkTypesAsync());
            Countries = new ObservableCollection<Countries>(await logic.CountriesLogic.GetCountries());
            SocStatuses = new ObservableCollection<SocialStatuses>(await logic.SocStatusesLogic.GetSocialStatuses());
        }

        // Метод для загрузки В/Ч по городу
        protected async void LoadUnitsCity(int id)
        {
            SoldierUnits = new ObservableCollection<SoldierUnit>(await logic.SoldierUnitLogic.GetSoldierUnitsCityAsync(id));
        }

        // Метод для загрузки В/Ч по стране
        protected async void LoadUnitsCountry(int id)
        {
            SoldierUnits = new ObservableCollection<SoldierUnit>(await logic.SoldierUnitLogic.GetSoldierUnitsCountryAsync(id));
        }

        #endregion


    }
}
