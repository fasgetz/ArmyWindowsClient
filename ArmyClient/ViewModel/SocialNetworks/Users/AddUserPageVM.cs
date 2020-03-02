using ArmyClient.LogicApp;
using ArmyClient.LogicApp.Helps;
using ArmyClient.LogicApp.Realisation;
using ArmyClient.Model;
using ArmyClient.ViewModel.Helpers;
using ArmyClient.ViewModel.Main;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Navigation;

namespace ArmyClient.ViewModel.Users
{

    enum Status
    {
        [Description("Открытый")]
        Opened,
        [Description("Закрытый")]
        Closed
    }

    public class EnumerationExtension : MarkupExtension
    {
        private Type _enumType;


        public EnumerationExtension(Type enumType)
        {
            if (enumType == null)
                throw new ArgumentNullException("enumType");

            EnumType = enumType;
        }

        public Type EnumType
        {
            get { return _enumType; }
            private set
            {
                if (_enumType == value)
                    return;

                var enumType = Nullable.GetUnderlyingType(value) ?? value;

                if (enumType.IsEnum == false)
                    throw new ArgumentException("Type must be an Enum.");

                _enumType = value;
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var enumValues = Enum.GetValues(EnumType);

            return (
              from object enumValue in enumValues
              select new EnumerationMember
              {
                  Value = enumValue,
                  Description = GetDescription(enumValue)
              }).ToArray();
        }

        private string GetDescription(object enumValue)
        {
            var descriptionAttribute = EnumType
              .GetField(enumValue.ToString())
              .GetCustomAttributes(typeof(DescriptionAttribute), false)
              .FirstOrDefault() as DescriptionAttribute;


            return descriptionAttribute != null
              ? descriptionAttribute.Description
              : enumValue.ToString();
        }

        public class EnumerationMember
        {
            public string Description { get; set; }
            public object Value { get; set; }
        }
    }

    class AddUserPageVM : MainPageVM
    {

        #region Свойства

        private Status _CurrentStatus;
        public Status CurrentStatus
        {
            get => _CurrentStatus;
            set
            {
                _CurrentStatus = value;
                


                OnPropertyChanged("CurrentStatus");
            }
        }

        // Выбранная страна воинской части
        public new Countries SelectedCountryUS
        {
            get => _SelectedCountryUS;
            set
            {
                _SelectedCountryUS = value;

                if (value != null)
                {
                    user.CountryResidence_Id = value.Id;
                    LoadResidenceCities(value.Id); // Загружаем города страны
                }


                //user.City1.CountryId = value.Id;



                OnPropertyChanged("SelectedCountryUS");
            }
        }

        #endregion

        #region Секция команд

        private bool GetOpened()
        {
            switch (CurrentStatus)
            {
                case (Status.Opened):
                    return true;                    
                case (Status.Closed):
                    return false;                    
                default:
                    return false;
            }

        }

        // Команда по добавлению соц. сети пользователю
        public DelegateCommand AddSocNetType
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    if (!string.IsNullOrWhiteSpace(WebAddress) && SelectedType != null)
                    {
                        MySocNetTypes.Add(new SocialNetworkUser() { WebAddress = WebAddress, SocialNetworkId = SelectedType.Id, Opened = GetOpened(), SocialNetworkType = SocialNetworkTypesList.FirstOrDefault(i => i.Id == SelectedType.Id) });
                        user.SocialNetworkUser.Add(new SocialNetworkUser() { SocialNetworkId = SelectedType.Id, WebAddress = WebAddress, Opened = true });
                        WebAddress = null;
                        SelectedType = null;
                        CurrentStatus = Status.Opened;
                    }
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
                    // Добавляем юзера
                    AddUserDB();                    
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
                    MyNavigation.GoBack();
                });
            }
        }

        // Команда добавления службы пользователю
        public new DelegateCommand AddSoldierService
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    // Если выбрали В/Ч
                    if (SelectedSoldierUnit != null)
                    {
                        UserSoldierService service = new UserSoldierService()
                        {
                            IdSoldierUnit = SelectedSoldierUnit.Id,
                            IdUser = user.Id
                        };


                        user.UserSoldierService.Add(service);
                        UserSoldierServices.Add(SoldierUnits.Where(i => i.Id == service.IdSoldierUnit).FirstOrDefault());
                        SoldierUnits.Remove(SoldierUnits.Where(i => i.Id == service.IdSoldierUnit).FirstOrDefault());

                        SelectedSoldierUnit = null;
                    }
                });
            }
        }

        #endregion

        #region Вспомогательные методы

        /// <summary>
        /// Метод добавления юзера в БД
        /// </summary>
        private async void AddUserDB()
        {
            user.DateOfEntry = DateTime.Now;

            bool added = await logic.userLogic.AddUserAsync(user);

            if (added == true)
            {
                MyNavigation.navigation.GoBack();
            }
        }

        #endregion

        public AddUserPageVM(bool AddMod)
        {
            user.City1 = null;
            user.City = null;
        }

    }
}
