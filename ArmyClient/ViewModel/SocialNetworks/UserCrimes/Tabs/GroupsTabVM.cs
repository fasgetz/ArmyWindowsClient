using ArmyClient.LogicApp.VK;
using ArmyClient.Model;
using ArmyClient.Models.ModelSocialNetworks;
using ArmyClient.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ArmyClient.ViewModel.SocialNetworks.UserCrimes.Tabs
{
    class GroupsTabVM : MainVM
    {

        #region Вспомогательные методы

        private async void LoadGroupsVK()
        {
            await Task.Run(() =>
            {
                enabledLoadButton = false;

                try
                {
                    // Нужно выбрать только цифры из адреса вк
                    int UserID = 0;
                    int.TryParse(string.Join("", selectedSocialNetwork.WebAddress.Where(c => char.IsDigit(c))), out UserID);

                    var user = VkLogic.MyApi.UserLogic.GetUser(UserID);
                    if (!user.IsClosed.Value)
                    {
                        

                        var groupsVK = VkLogic.MyApi.GroupLogic.GetGroups(UserID);

                        foreach (var item in groupsVK)
                        {
                            // Ищем группу в БД
                            var findGroup = logic.GroupLogic.GetOneGroup(selectedSocialNetwork.Id, item.Name).Result;

                            // Если группа не найдена в БД, то добавь ее в БД
                            if (findGroup == null)
                            {
                                SocialNetworkGroup group = new SocialNetworkGroup()
                                {
                                    SocialNetworkUserID = selectedSocialNetwork.Id,
                                    Name = item.Name,
                                    Description = item.Description,
                                    MembersCount = item.MembersCount,
                                    GroupAddress = $"https://vk.com/club{item.Id}",
                                    DateAddedOnDB = System.DateTime.Now,
                                    GroupPublicity = true
                                };

                                logic.GroupLogic.AddGroup(group);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Профиль закрытый!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.No, MessageBoxOptions.ServiceNotification);
                    }

                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Авторизируйтесь в социальной сети!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.No, MessageBoxOptions.ServiceNotification);

                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Ошибкаыы!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.No, MessageBoxOptions.ServiceNotification);

                    return;
                }
                finally
                {
                    enabledLoadButton = true;
                    LoadGroups();
                }
            });
        }

        private async void LoadGroups()
        {
            groups = new ObservableCollection<SocialNetworkGroup>(await logic.GroupLogic.GetGroups(selectedSocialNetwork.Id));
        }

        #endregion

        #region Свойства

        private bool _enabledLoadButton = true;
        public bool enabledLoadButton
        {
            get => _enabledLoadButton;
            set
            {
                _enabledLoadButton = value;
                OnPropertyChanged("enabledLoadButton");
            }
        }

        // Группы
        private ObservableCollection<SocialNetworkGroup> _groups;
        public ObservableCollection<SocialNetworkGroup> groups
        {
            get => _groups;
            set
            {
                _groups = value;
                OnPropertyChanged("groups");
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

        #endregion

        #region Команды

        public DelegateCommand autoload
        {
            get
            {
                return new DelegateCommand(obj =>
                {

                    // По типу социальной сети загрузить иностранных друзей
                    switch (selectedSocialNetwork.SocialNetworkType.Id)
                    {
                        // Если ВК
                        case (1):
                            try
                            {
                                LoadGroupsVK();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                            break;
                        default:
                            // Отключить кнопку загрузки, т.к. нет соответствующей социальной сети
                            enabledLoadButton = false;
                            break;
                    }
                });
            }
        }

        #endregion

        public GroupsTabVM(SocialNetworkUser socialNetwork)
        {
            this.selectedSocialNetwork = socialNetwork;


            LoadGroups();
        }
    }
}
