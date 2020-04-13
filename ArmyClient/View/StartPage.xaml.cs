using ArmyClient.LogicApp.VK;
using ArmyClient.View.ExtremistMaterials;
using ArmyClient.View.Main;
using ArmyClient.View.Settings;
using ArmyClient.View.SocialNetworks.Main;
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

namespace ArmyClient.View
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();

            //Frame tabFrame = new Frame();
            //tabFrame.Content = new SocialNetworksMainPage();
            //plan.Content = tabFrame;

            //tabFrame = new Frame();
            //tabFrame.Content = new ExtremistMaterialsMainPage();
            //em.Content = tabFrame;

            var tabFrame = new Frame();
            tabFrame.Content = new SettingsView();
            settings.Content = tabFrame;

            tabFrame = new Frame();
            tabFrame.Content = new ExtremistMaterialsMainPage();
            em.Content = tabFrame;

            tabFrame = new Frame();
            tabFrame.Content = new SocialNetworksMainPage();
            plan.Content = tabFrame;
        }
    }
}
