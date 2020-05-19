using ArmyClient.ViewModel.Helpers;
using ProgressBarDB;

namespace ArmyClient.ViewModel.SocialNetworks.Helpers
{
    class ProgressBarVM : MainVM
    {
        private int _valueBar;
        public int valueBar
        {
            get => _valueBar;
            set
            {
                _valueBar = value;
                OnPropertyChanged("valueBar");
            }
        }

        private int _maxBar;
        public int maxBar
        {
            get => _maxBar;
            set
            {
                _maxBar = value;
                OnPropertyChanged("maxBar");
            }
        }

        protected MyProgressBar bar;

        private string _messageBar;
        public string messageBar
        {
            set
            {
                _messageBar = value;
                OnPropertyChanged("messageBar");
            }
            get => _messageBar;
        }
    }
}
