using ArmyClient.Model;
using ArmyClient.View.ForeignFriends;
using ArmyClient.View.UserCrimes;
using ArmyClient.View.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace ArmyClient.ViewModel.Helpers
{
    internal static class MyNavigation
    {
        public static NavigationService navigation { get; set; }

        public static void GoBack()
        {
            navigation.GoBack();
        }

        public static void GoAddUserPage()
        {
            navigation.Navigate(new AddUserPage());
        }

        public static void GoToAboutUser(int UserID)
        {
            navigation.Navigate(new AboutUserPage(UserID));
        }

        public static void GoToCrimes(Model.Users user, SocialNetworkUser selectedSocialNetwork)
        {
            navigation.Navigate(new UserCrimesPage(user, selectedSocialNetwork));
        }

        public static void GoToForeignFriendPage(Model.ForeignFriends friend)
        {
            navigation.Navigate(new ForeignFriendsPage(friend));
        }
    }
}
