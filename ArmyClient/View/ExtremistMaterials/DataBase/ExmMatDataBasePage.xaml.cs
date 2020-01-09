using ArmyClient.ViewModel.ExtremistMaterial.DataBase;
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

namespace ArmyClient.View.ExtremistMaterials.DataBase
{
    /// <summary>
    /// Логика взаимодействия для ExmMatDataBasePage.xaml
    /// </summary>
    public partial class ExmMatDataBasePage : Page
    {
        public ExmMatDataBasePage()
        {
            InitializeComponent();

            DataContext = new ExmDataBaseVM();
            
        }

    }
}
