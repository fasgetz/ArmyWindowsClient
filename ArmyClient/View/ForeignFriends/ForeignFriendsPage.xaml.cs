using ArmyClient.ViewModel.ForeignFriends;
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

namespace ArmyClient.View.ForeignFriends
{
    /// <summary>
    /// Логика взаимодействия для ForeignFriendsPage.xaml
    /// </summary>
    public partial class ForeignFriendsPage : Page
    {
        public ForeignFriendsPage(Model.ForeignFriends friend)
        {
            InitializeComponent();

            this.DataContext = new ForeignFriendsVM(friend);
        }
    }
}
