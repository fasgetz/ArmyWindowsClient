using ArmyClient.Model;
using ArmyClient.ViewModel.SocialNetworks.UserCrimes.Tabs;
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

namespace ArmyClient.View.SocialNetworks.UserCrimes.Tabs
{
    /// <summary>
    /// Логика взаимодействия для AudiousTab.xaml
    /// </summary>
    public partial class AudiousTab : Page
    {
        public AudiousTab(SocialNetworkUser socialNetwork)
        {
            InitializeComponent();

            DataContext = new AudiosTabVM(socialNetwork);
        }
    }
}
