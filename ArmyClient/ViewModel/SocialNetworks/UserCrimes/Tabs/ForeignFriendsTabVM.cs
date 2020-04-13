using ArmyClient.LogicApp.VK;
using ArmyClient.Model;
using ArmyClient.View.SocialNetworks.UserCrimes;
using ArmyClient.ViewModel.Helpers;
using ArmyClient.ViewModel.UserCrimes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VkNet.Model;

namespace ArmyClient.ViewModel.SocialNetworks.UserCrimes.Tabs
{
    class ForeignFriendsTabVM : MainVM
    {

        #region Вспомогательные методы

        // Загрузка иностранных друзей
        private async void LoadFF()
        {
            //ForeignFriends = new ObservableCollection<Model.ForeignFriends>();

            //ForeignFriends.Add(new Model.ForeignFriends() { Id = 1, Name = "An", Family = "set" });
            //await logic.ForeignFriendsLogic.GetForeignFriends(selectedSocialNetwork.Id);
            try
            {
                ForeignFriends = new ObservableCollection<Model.ForeignFriends>(await logic.ForeignFriendsLogic.GetForeignFriends(selectedSocialNetwork.Id));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion

        public ForeignFriendsTabVM(SocialNetworkUser socialNetwork)
        {

            selectedSocialNetwork = socialNetwork;

            // Загружаем иностранных друзей
            LoadFF();
        }

        #region Блок "иностранных друзей"

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

        private Model.ForeignFriends _SelectedForeignFriend;
        public Model.ForeignFriends SelectedForeignFriend
        {
            get => _SelectedForeignFriend;
            set
            {
                _SelectedForeignFriend = value;
                OnPropertyChanged("SelectedForeignFriend");
            }
        }

        // Команда перехода на страницу иностранного друга
        public DelegateCommand GoToForeignFriendPage
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    if (SelectedForeignFriend != null)
                    {
                        MyNavigation.GoToForeignFriendPage(SelectedForeignFriend);
                    }
                });
            }
        }


        // Команда по добавлению иностранного друга
        public DelegateCommand AddForeignFriend
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    if (new AddForeignFriendWindow(selectedSocialNetwork.Id).ShowDialog() == true)
                        LoadFF();
                });
            }
        }


        // Команда по автозагрузке иностранных друзей
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
                                LoadForeignFriendsVK();
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

        private async void LoadForeignFriendsVK()
        {
            await Task.Run(() =>
            {

                enabledLoadButton = false;
                var vkfriends = new List<User>();

                // Нужно выбрать только цифры из адреса вк
                int UserID = 0;
                int.TryParse(string.Join("", selectedSocialNetwork.WebAddress.Where(c => char.IsDigit(c))), out UserID);

                // Если айди юзера указан, то загрузи
                if (UserID != 0)
                {
                    //api = new MyApiVK();

                    //api.Authorization("89629007965", "andrey06122SASISA");

                    try
                    {
                        // Сформировали список друзей
                        vkfriends = VkLogic.MyApi.UserLogic.GetForeignFriends(UserID).ToList();
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Авторизируйтесь в социальной сети!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.No, MessageBoxOptions.ServiceNotification);

                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.No, MessageBoxOptions.ServiceNotification);

                        return;
                    }
                    finally
                    {
                        enabledLoadButton = true;
                    }


                    // Далее сравниваем. Есть ли необходимость добавления новых друзей и тп.
                    if (ForeignFriends.Count != vkfriends.Count)
                    {
                        // Веб клиент для загрузки изображений
                        webclient = new WebClient();

                        // Делаем перебор и сравниваем кого нету. Кого нет, тех добавляем
                        foreach (var item in vkfriends)
                        {
                            var friend = ForeignFriends.Where(i => i.WebAddress.Contains(item.Id.ToString()) && i.SocialNetworkUserID == selectedSocialNetwork.Id).FirstOrDefault();

                            //var friend = friends.FirstOrDefault();

                            // Если друга не нашлось, то необходимо добавить в базу данных
                            if (friend == null)
                            {
                                // Дату рождения парсим
                                DateTime date;

                                DateTime.TryParse(item.BirthDate, out date);


                                // Добавляем друга
                                friend = new Model.ForeignFriends()
                                {
                                    CountryId = (byte)item.Country?.Id,
                                    Name = item.FirstName,
                                    Family = item.LastName,
                                    SocialNetworkUserID = selectedSocialNetwork.Id,
                                    BirthDay = date,
                                    WebAddress = $"https://vk.com/id{item.Id}",
                                    Photo = LoadImage(item.Photo400Orig?.AbsoluteUri) // Загружаем фотографию

                                };

                                // Добавляем друга
                                logic.ForeignFriendsLogic.AddForeignFriend(friend);
                            }
                        }



                    }
                    else
                    {
                        enabledLoadButton = false;
                        MessageBox.Show("все уже загружены");
                        return;
                    }

                }

                // Загружаем иностранных друзей после добавления
                LoadFF();
                enabledLoadButton = true;

            });
        }

        WebClient webclient;
        // Загрузка изображения
        private byte[] LoadImage(string url)
        {
            byte[] imageData = null;
            if (url != null)
                imageData = webclient.DownloadData(url);

            return imageData;
        }
        //private async void AddFF(Model.ForeignFriends friend)
        //{
        //    bool isAdded = await logic.ForeignFriendsLogic.AddForeignFriend(friend);
        //}



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

        // Список иностранных друзей из БД
        private ObservableCollection<Model.ForeignFriends> _ForeignFriends;
        public ObservableCollection<Model.ForeignFriends> ForeignFriends
        {
            get => _ForeignFriends;
            set
            {
                _ForeignFriends = value;
                OnPropertyChanged("ForeignFriends");
            }
        }

        //

        #endregion

    }
}
