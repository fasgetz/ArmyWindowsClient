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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace ArmyClient.ViewModel.Users
{
    class AddUserPageVM : MainPageVM
    {

        #region Секция команд


        // Команда по добавлению соц. сети пользователю
        public DelegateCommand AddSocNetType
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    if (!string.IsNullOrWhiteSpace(WebAddress) && SelectedType != null)
                    {
                        MySocNetTypes.Add(new SocialNetworkUser() { WebAddress = WebAddress, SocialNetworkId = SelectedType.Id, SocialNetworkType = SocialNetworkTypesList.FirstOrDefault(i => i.Id == SelectedType.Id) });
                        user.SocialNetworkUser.Add(new SocialNetworkUser() { SocialNetworkId = SelectedType.Id, WebAddress = WebAddress, Opened = true });
                        WebAddress = null;
                        SelectedType = null;
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
