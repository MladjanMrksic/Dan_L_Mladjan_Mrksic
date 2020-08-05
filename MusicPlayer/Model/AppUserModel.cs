using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicPlayer.Model
{
    class AppUserModel
    {
        public List<AppUser> GetAllAppUsers()
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    return (from x in context.AppUsers select x).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public AppUser GetAppUser(int ID)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    return (from x in context.AppUsers where x.AppUserID == ID select x).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public void AddAppUser(AppUser au)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    context.AppUsers.Add(au);
                    context.SaveChanges();
                    MessageBox.Show("Action successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void DeleteAppUser(int ID)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    context.AppUsers.Remove((from x in context.AppUsers where x.AppUserID == ID select x).FirstOrDefault());
                    context.SaveChanges();
                    MessageBox.Show("Action successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void UpdateAppUser(AppUser au)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    AppUser user = (from x in context.AppUsers where x.AppUserID == au.AppUserID select x).FirstOrDefault();
                    user = au;
                    context.SaveChanges();
                    MessageBox.Show("Action successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
