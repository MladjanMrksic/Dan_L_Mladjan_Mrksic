using MusicPlayer.ViewModel;
using System.Windows;

namespace MusicPlayer.View
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : Window
    {
        public UserView()
        {
            DataContext = new UserViewModel(this);
            InitializeComponent();
        }
    }
}
