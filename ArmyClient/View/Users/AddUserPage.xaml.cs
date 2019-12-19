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

namespace ArmyClient.View.Users
{
    /// <summary>
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        AddUserPageVM vm;

        public AddUserPage()
        {
            InitializeComponent();
            
            vm = new AddUserPageVM();
            DataContext = vm;
        }


        /// <summary>
        /// Удалить фотографию при нажатии ПКМ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void img_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            vm.ImageBytes = null;
            vm.user.Photo = null;       
        }
    }
}
