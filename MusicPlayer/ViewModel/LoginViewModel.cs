using MusicPlayer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.ViewModel
{
    class LoginViewModel : ViewModelBase
    {
        LoginView view;

        public LoginViewModel(LoginView lv)
        {
            view = lv;
        }
    }
}
