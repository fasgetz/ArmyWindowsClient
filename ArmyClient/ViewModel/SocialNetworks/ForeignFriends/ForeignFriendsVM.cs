using ArmyClient.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ArmyClient.ViewModel.ForeignFriends
{
    class ForeignFriendsVM : MainVM
    {
        private Model.ForeignFriends _friend;
        public Model.ForeignFriends friend
        {
            get => _friend;
            set
            {
                _friend = value;                
                OnPropertyChanged("friend");
            }
        }


        public ForeignFriendsVM(Model.ForeignFriends friend)
        {
            this.friend = friend;
            LoadFriend(friend);
        }

        private async void LoadFriend(Model.ForeignFriends myfriend)
        {
            friend = await logic.ForeignFriendsLogic.GetOneForeignFriend(friend.Id);
        }
    }
}
