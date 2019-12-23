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
                        user.SocialNetworkUser.Add(new SocialNetworkUser() { SocialNetworkId = SelectedType.Id, WebAddress = WebAddress });
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

        #region Вспомогательные методы

        /// <summary>
        /// Метод добавления юзера в БД
        /// </summary>
        private async void AddUserDB()
        {
            user.DateOfEntry = DateTime.Now;
            //user.
            bool added = await logic.userLogic.AddUserAsync(user);

            if (added == true)
            {
                MyNavigation.navigation.GoBack();
            }
        }

        #endregion

        public AddUserPageVM(bool AddMod)
        {

        }

    }
}
