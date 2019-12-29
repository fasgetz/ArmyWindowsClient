using ArmyClient.Model;
using ArmyClient.ViewModel.Helpers;
using ArmyClient.ViewModel.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyClient.ViewModel.UserCrimes
{
    class UserCrimesVM : AboutUserPageVM
    {

        #region Свойства


        // Преступления пользователя
        private ObservableCollection<Model.UserCrimes> _Crimes;
        public ObservableCollection<Model.UserCrimes> Crimes
        {
            get => _Crimes;
            set
            {
                _Crimes = value;
                OnPropertyChanged("Crimes");
            }
        }


        // Типы преступлений
        private ObservableCollection<CrimesType> _CrimesCategory;
        public ObservableCollection<CrimesType> CrimesCategory
        {
            get => _CrimesCategory;
            set
            {
                _CrimesCategory = value;
                OnPropertyChanged("CrimesCategory");
            }
        }

        #endregion

        #region Вспомогательные методы

        private async void LoadData()
        {
            CrimesCategory = new ObservableCollection<CrimesType>(await logic.CrimesLogic.LoadCrimesCategory());
        }


        #endregion

        #region Команды

        public DelegateCommand AddCrime
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    Crimes.Add(new Model.UserCrimes() { Id = 123 });

                });
            }
        }


        #endregion

        public UserCrimesVM(Model.Users user)
        {
            this.user = user;

            // Загружаем данные
            LoadData();

            Crimes = new ObservableCollection<Model.UserCrimes>()
            {
                new Model.UserCrimes(){ Id = 1},
                new Model.UserCrimes() { Id = 5 }
            };

        }


    }
}
