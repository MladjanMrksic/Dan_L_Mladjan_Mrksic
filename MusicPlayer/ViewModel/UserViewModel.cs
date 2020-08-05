using MusicPlayer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.ViewModel
{
    class UserViewModel : ViewModelBase
    {
        UserView view;

        public UserViewModel(UserView uv)
        {
            view = uv;
        }
    }
}
