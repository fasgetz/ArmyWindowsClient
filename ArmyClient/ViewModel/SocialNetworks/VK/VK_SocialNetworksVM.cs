﻿using ArmyClient.LogicApp.VK;
using ArmyClient.ViewModel.Helpers;
using ArmyClient.ViewModel.SocialNetworks.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using VkNet.Model;

namespace ArmyClient.ViewModel.SocialNetworks.VK
{
    class VK_SocialNetworksVM : VK_MainVM
    {

        #region Свойства

        private int _mytext;
        public int mytext
        {
            get => _mytext;
            set
            {
                _mytext = value;
                OnPropertyChanged("mytext");
            }
        }

        private bool _enabled;
        public bool enabled
        {
            get => _enabled;
            set
            {
                _enabled = value;
                OnPropertyChanged("enabled");
            }
        }

        // Список неимеющих вч
        private ObservableCollection<User> _error;
        public ObservableCollection<User> error
        {
            get => _error;
            set
            {
                _error = value;
                OnPropertyChanged("error");
            }
        }

        // Список имеющих вч
        private ObservableCollection<User> _list;
        public ObservableCollection<User> list
        {
            get => _list;
            set
            {
                _list = value;
                OnPropertyChanged("list");
            }
        }

        #endregion

        #region Команды

        public DelegateCommand test
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    testd();                    
                });
            }
        }


        private async void testd()
        {
            await Task.Run(() =>
            {
                enabled = false;

                // Апи
 
                var users = VkLogic.MyApi.UserLogic.GetFriendsUser(mytext);

                // Использовать многопоточную версию
                Parallel.For(0, users.Length / 10, (int i) =>
                {
                    for (int s = i * 10; s < (i + 1) * 10; s++)
                    {
                        try
                        {
                            // Получаем юзера
                            var resoult = VkLogic.MyApi.UserLogic.UserHasUnitSoldier(users[s]);

                            if (resoult == false)
                            {
                                App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                                {
                                    error.Add(users[s]);
                                });

                            }
                            else
                            {
                                App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                                {
                                    list.Add(users[s]);
                                });

                            }



                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }


                    }
                });

                

                enabled = true;
            });
        }

        #endregion

        public VK_SocialNetworksVM()
        {
            list = new ObservableCollection<User>();
            error = new ObservableCollection<User>();
            enabled = true;
        }
    }
}
