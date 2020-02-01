using ArmyClient.View.Main;
using ArmyClient.View.SocialNetworks.VK;
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

namespace ArmyClient.View.SocialNetworks.Main
{
    /// <summary>
    /// Логика взаимодействия для SocialNetworksMainPage.xaml
    /// </summary>
    public partial class SocialNetworksMainPage : Page
    {
        public SocialNetworksMainPage()
        {
            InitializeComponent();

            Frame tabFrame = new Frame();
            tabFrame.Content = new MainPage();
            dbTabItem.Content = tabFrame;


            // Добавить страницу для работы с ВК
            tabFrame = new Frame();
            tabFrame.Content = new VK_SocialNetworks();
            vkTabItem.Content = tabFrame;
        }
    }
}
