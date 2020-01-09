using ArmyClient.View.ExtremistMaterials.DataBase;
using ArmyClient.View.ExtremistMaterials.Resoults;
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

namespace ArmyClient.View.ExtremistMaterials
{
    /// <summary>
    /// Логика взаимодействия для ExtremistMaterialsMainPage.xaml
    /// </summary>
    public partial class ExtremistMaterialsMainPage : Page
    {
        public ExtremistMaterialsMainPage()
        {
            InitializeComponent();

            Frame tabFrame = new Frame();
            tabFrame.Content = new ExmMatDataBasePage();
            dbTabItem.Content = tabFrame;

            tabFrame = new Frame();
            tabFrame.Content = new ResoultExmPage();
            resTabItem.Content = tabFrame;
        }


    }
}
