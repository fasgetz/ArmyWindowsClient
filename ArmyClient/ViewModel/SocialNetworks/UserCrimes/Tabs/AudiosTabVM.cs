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
    class AudiosTabVM : MainVM
    {

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
                                LoadAudiosVK();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                            break;
                        default:
                            // Отключить кнопку загрузки, т.к. нет соответствующей социальной сети
                            MessageBox.Show($"Кнопка авто загрузки доступна только для социальной сети Вконтакте!");
                            enabledLoadButton = false;
                            break;
                    }
                });
            }
        }

        #endregion

        #region Вспомогательные методы

        private async void LoadAudiosVK()
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


                        var audiosVK = VkLogic.MyApi.AudiosLogic.GetAudious(UserID);

                        foreach (var item in audiosVK)
                        {
                            // Ищем аудио в БД
                            var findAudio = logic.GroupLogic.GetOneGroup(selectedSocialNetwork.Id, item.Title).Result;

                            // Если группа не найдена в БД, то добавь ее в БД
                            if (findAudio == null)
                            {
                                SocialNetworkAudio audio = new SocialNetworkAudio()
                                {
                                    SocialNetworkUserID = selectedSocialNetwork.Id,
                                    ArtistName = item.Artist,
                                    AudioName = item.Title,
                                    Duration = item.Duration,
                                    DateAddedOnDB = System.DateTime.Now,
                                    DateAddedSocNetw = item.Date
                                };

                                logic.AudiosLogic.AddAudio(audio);
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
                    MessageBox.Show($"{ex.Message}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.No, MessageBoxOptions.ServiceNotification);

                    return;
                }
                finally
                {
                    enabledLoadButton = true;
                    LoadAudios();
                }
            });
        }

        // Загрузка аудио с БД
        private async void LoadAudios()
        {
            audios = new ObservableCollection<SocialNetworkAudio>(await logic.AudiosLogic.GetAudio(selectedSocialNetwork.Id));
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

        //// Аудиозаписи
        private ObservableCollection<SocialNetworkAudio> _audios;
        public ObservableCollection<SocialNetworkAudio> audios
        {
            get => _audios;
            set
            {
                _audios = value;
                OnPropertyChanged("audios");
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

        public AudiosTabVM(SocialNetworkUser socialNetwork)
        {
            this.selectedSocialNetwork = socialNetwork;


            LoadAudios();
        }
    }
}
