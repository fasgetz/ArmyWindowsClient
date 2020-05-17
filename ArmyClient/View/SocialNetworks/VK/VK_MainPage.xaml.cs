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

namespace ArmyClient.View.SocialNetworks.VK
{
    /// <summary>
    /// Логика взаимодействия для VK_MainPage.xaml
    /// </summary>
    public partial class VK_MainPage : Page
    {
        public VK_MainPage()
        {
            InitializeComponent();

            Frame tabFrame = new Frame();
            tabFrame.Content = new VK_SearchUser();
            SearchUserItem.Content = tabFrame;
        }
    }
}
