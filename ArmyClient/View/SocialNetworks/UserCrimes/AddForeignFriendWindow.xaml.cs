using ArmyClient.Model;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace ArmyClient.View.SocialNetworks.UserCrimes
{
    /// <summary>
    /// Логика взаимодействия для AddForeignFriendWindow.xaml
    /// </summary>
    public partial class AddForeignFriendWindow : Window
    {
        List<Countries> countriesList;
        ArmyClient.Model.ForeignFriends friend;
        ArmyClient.LogicApp.Realisation.LogicApp logic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SocialNetworkUserID">Айди социальной сети</param>
        public AddForeignFriendWindow(int SocialNetworkUserID)
        {
            InitializeComponent();

            logic = new LogicApp.Realisation.LogicApp();
            friend = new Model.ForeignFriends()
            {
                SocialNetworkUserID = SocialNetworkUserID
            };

            LoadData();
            
        }

        private async void LoadData()
        {
            countriesList = await logic.CountriesLogic.GetCountries();

            country.ItemsSource = countriesList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            friend = new Model.ForeignFriends()
            {
                SocialNetworkUserID = friend.SocialNetworkUserID,
                Name = name.Text,
                Family = family.Text,
                WebAddress = webAddress.Text,
                Photo = friend.Photo
            };

            var selectedCountry = ((Countries)country.SelectedItem);

            if (selectedCountry != null)
                friend.CountryId = selectedCountry.Id;

            if (dateBirth.SelectedDate != null)
                friend.BirthDay = dateBirth.SelectedDate;


            var added = logic.ForeignFriendsLogic.AddForeignFriend(friend) ? this.DialogResult = true : this.DialogResult = false;
            
            this.Close();
        }

        private void AddOnBufer_Click(object sender, RoutedEventArgs e)
        {
            if (Clipboard.ContainsImage() == true && friend != null)
            {
                var image = Clipboard.GetImage();

                var imgbytes = ImageToByte(image);

                MyImage.Source = LoadImage(imgbytes);
                friend.Photo = imgbytes;
            }
        }



        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        public Byte[] ImageToByte(BitmapSource source)
        {
            var encoder = new System.Windows.Media.Imaging.PngBitmapEncoder();
            var frame = System.Windows.Media.Imaging.BitmapFrame.Create(source);
            encoder.Frames.Add(frame);
            var stream = new MemoryStream();

            encoder.Save(stream);
            return stream.ToArray();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (friend.Photo != null)
            {
                friend.Photo = null;
                MyImage.Source = null;
            }
        }
    }
}
