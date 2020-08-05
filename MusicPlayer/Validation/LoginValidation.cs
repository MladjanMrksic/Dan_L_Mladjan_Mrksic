using MusicPlayer.Model;
using MusicPlayer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicPlayer.Validation
{
    class LoginValidation
    {
        AppUserModel user = new AppUserModel();

        public void Login (string username, string password, LoginView view)
        {
            List<AppUser> users = user.GetAllAppUsers();
            if (users.Contains((from x in users where x.Username == username && x.Password == password select x).FirstOrDefault()))
            {
                UserView uv = new UserView();
                view.Close();
                uv.Show();
            }
            else if (MessageBox.Show("This user doesn't exis. Would you like to create it?", "Create User", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                AppUser au = new AppUser();
                au.Username = username;
                au.Password = password;
                user.AddAppUser(au);
                UserView uv = new UserView();
                view.Close();
                uv.Show();
            }
            else
            {
                MessageBox.Show("Please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
