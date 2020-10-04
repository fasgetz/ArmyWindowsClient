using ArmyClient.View;
using ArmyClient.View.Main;
using ArmyClient.View.Users;
using ArmyClient.ViewModel.Helpers;
using ArmyClient.ViewModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArmyClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            MyNavigation.navigation = myframe.NavigationService;

            MyNavigation.navigation.Content = new StartPage();


            //MyNavigation.navigation.Navigate(new AddUserPage());
            //myframe.Navigate(new AddUserPage());

            //myframe.NavigationService.
        }
    }
}
