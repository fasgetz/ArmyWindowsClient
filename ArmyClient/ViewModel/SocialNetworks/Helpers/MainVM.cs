using ArmyClient.ViewModel.SocialNetworks.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace ArmyClient.ViewModel.Helpers
{
    internal class MainVM : RealisationVM
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

    }
}
