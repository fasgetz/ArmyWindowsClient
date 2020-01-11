using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace ArmyClient.ViewModel.Helpers
{
    internal class MainVM : INotifyPropertyChanged
    {
        // Логика программы
        protected LogicApp.Realisation.LogicApp logic;

        // Команда перехода на страницу назаад
        public DelegateCommand GoBackPage
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    MyNavigation.GoBack();
                });
            }
        }

        public MainVM()
        {
            logic = new LogicApp.Realisation.LogicApp();
        }

        #region Реализация интерфейса INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
