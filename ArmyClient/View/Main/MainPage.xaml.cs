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

namespace ArmyClient.View.Main
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        LogicApp.Realisation.LogicApp logic;
        public MainPage()
        {
            InitializeComponent();

            logic = new LogicApp.Realisation.LogicApp();

            load(); 
        }

        async void load()
        {

            cb.ItemsSource = await logic.CountriesLogic.GetCountries();
        }
    }
}
