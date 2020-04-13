using ArmyClient.LogicApp.VK;
using ArmyClient.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.ViewModel.Settings
{
    class SettingsVM : MainVM
    {
        #region Команды
        private string _login;
        public string login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged("login");
            }
        }
        private string _password;
        public string password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged("password");
            }
        }


        public string IsAuthorized
        {
            get
            {
                if (VkLogic.MyApi != null && VkLogic.IsAuthorized())
                    return "Авторизован";
                else
                    return "Не авторизован";
            }
        }

        #endregion

        #region Команды

        // Команда по добавлению нарушения
        public DelegateCommand Auth
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    try
                    {
                        VkLogic.Auth(login, password);
                        OnPropertyChanged("IsAuthorized");
                    }
                    catch (Exception)
                    {

                    }

                });
            }
        }

        #endregion

        public SettingsVM()
        {

        }
    }
}
