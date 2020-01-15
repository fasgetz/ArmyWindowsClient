using ArmyClient.ViewModel.Main;
using ArmyClient.ViewModel.SocialNetworks._HelpWindows;
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
using System.Windows.Shapes;

namespace ArmyClient.View.SocialNetworks._HelpWindows
{
    /// <summary>
    /// Логика взаимодействия для LoadImgWebWindow.xaml
    /// </summary>
    public partial class LoadImgWebWindow : Window
    {
        internal LoadImgWebWindow(MainPageVM vm)
        {
            InitializeComponent();

            DataContext = new LoadImgWebWindowVM(this, vm);
        }
    }
}
