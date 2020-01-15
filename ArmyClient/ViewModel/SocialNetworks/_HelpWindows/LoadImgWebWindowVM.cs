using ArmyClient.ViewModel.Helpers;
using ArmyClient.ViewModel.Main;
using ArmyClient.ViewModel.SocialNetworks.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ArmyClient.ViewModel.SocialNetworks._HelpWindows
{
    class LoadImgWebWindowVM : RealisationVM
    {
        #region Свойства

        // Адресная строка
        private string _webAddress;
        public string webAddress
        {
            get => _webAddress;
            set
            {
                _webAddress = value;
                OnPropertyChanged("webAddress");
            }
        }


        MainPageVM vm;
        Window window;


        #endregion

        #region Команды

        // Команда по удалению изображения
        public DelegateCommand LoadImgWeb
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    // Если адресная строка не пуста, то загрузи изображение
                    if (!string.IsNullOrWhiteSpace(webAddress)) 
                    {
                        // Загрузка изображения
                        var img = vm.LoadImage(webAddress);

                        if (img != null)
                        {
                            vm.ImageBytes = img;
                            vm.user.Photo = img;
                        }

                        window.Close();
                        //var res = LoadImg().Result;
                        
                        //window.Close();
                    } 
                });
            }
        }

        #endregion


        #region Вспомогательные методы

        private async void LoadImg()
        {
            await Task.Run(() =>
            {
                // Загрузка изображения
                var img = vm.LoadImage(webAddress);

                if (img != null)
                {
                    vm.ImageBytes = img;
                    vm.user.Photo = img;
                }


                //return vm.ImageBytes == null ? false : true;
                // Закрываем изображение
                window.Close();
            });
        }

        #endregion

        public LoadImgWebWindowVM(Window window, MainPageVM vm)
        {
            this.vm = vm;
            this.window = window;
        }        
    }
}
