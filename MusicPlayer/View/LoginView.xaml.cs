using MusicPlayer.ViewModel;
using System.Windows;

namespace MusicPlayer.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            DataContext = new LoginViewModel(this);
            InitializeComponent();
        }
    }
}
