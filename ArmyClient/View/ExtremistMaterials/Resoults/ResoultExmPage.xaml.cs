using ArmyClient.ViewModel.ExtremistMaterial.Resoults;
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

namespace ArmyClient.View.ExtremistMaterials.Resoults
{
    /// <summary>
    /// Логика взаимодействия для ResoultExmPage.xaml
    /// </summary>
    public partial class ResoultExmPage : Page
    {
        public ResoultExmPage()
        {
            InitializeComponent();

            DataContext = new ResExmVM();
        }
    }
}
