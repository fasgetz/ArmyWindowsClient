using ArmyClient.Model;
using ArmyClient.View.SocialNetworks.UserCrimes.Tabs;
using ArmyClient.ViewModel.UserCrimes;
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

namespace ArmyClient.View.UserCrimes
{
    /// <summary>
    /// Логика взаимодействия для UserCrimesPage.xaml
    /// </summary>
    public partial class UserCrimesPage : Page
    {
        public UserCrimesPage(Model.Users user, SocialNetworkUser selectedSocialNetwork)
        {
            InitializeComponent();
            DataContext = new UserCrimesVM(user, selectedSocialNetwork);

            Frame tabFrame = new Frame();
            tabFrame.Content = new ForeignFriendsTab(selectedSocialNetwork);
            friends.Content = tabFrame;

            tabFrame = new Frame();
            tabFrame.Content = new GroupsTabs(selectedSocialNetwork);
            groups.Content = tabFrame;

            //tabFrame = new Frame();
            //tabFrame.Content = new SettingsView();
            //settings.Content = tabFrame;
        }

    }
}
