using ArmyClient.LogicApp.Helps;
using ArmyClient.Model;
using ArmyClient.ViewModel.Helpers;
using ArmyClient.ViewModel.Main;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.ViewModel.Users
{
    class AboutUserPageVM : MainPageVM
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
                        user.SocialNetworkUser.Add(new SocialNetworkUser() { SocialNetworkId = SelectedType.Id, WebAddress = WebAddress });
                        WebAddress = null;
                        SelectedType = null;
                    }
                });
            }
        }

        // Команда по переходу на страницу преступлений
        public DelegateCommand GoToCrimes
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    // Если выбрали соц сеть, то перейти на страницу
                    if (SelectedSocialNetwork != null)
                    {
                        MyNavigation.GoToCrimes(user, SelectedSocialNetwork);
                    }
                    
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


        #endregion

        #region Вспомогательные методы



        private async void GetUser(int UserID)
        {
            user = await logic.userLogic.GetUserAsync(UserID);


            MySocNetTypes = new System.Collections.ObjectModel.ObservableCollection<SocialNetworkUser>(user.SocialNetworkUser);
            //Soldi = new System.Collections.ObjectModel.ObservableCollection<SoldierUnit>(user.UserSoldierService)
        }

        /// <summary>
        /// Метод сохранения юзера
        /// </summary>
        private async void SaveUserOnDB()
        {
            user.DateOfEntry = DateTime.Now;
            bool added = await logic.userLogic.AddUserAsync(user);

            if (added == true)
            {
                MyNavigation.navigation.GoBack();
            }
        }

        #endregion

        /// <summary>
        /// Конструктор, который прогружает информацию о юзере по айди
        /// </summary>
        /// <param name="UserID">Айди юзера</param>
        public AboutUserPageVM(int UserID)
            :base(UserID)
        {
            GetUser(UserID);
        }

        public AboutUserPageVM()
        {

        }

    }
}
