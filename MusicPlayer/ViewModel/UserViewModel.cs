using MusicPlayer.Command;
using MusicPlayer.Model;
using MusicPlayer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicPlayer.ViewModel
{
    class UserViewModel : ViewModelBase
    {
        UserView view;
        SongModel sm = new SongModel();
        public UserViewModel(UserView uv)
        {
            view = uv;
            SongList = sm.GetAllSongs();
        }

        private List<Song> songList;
        public List<Song> SongList
        {
            get { return songList; }
            set { songList = value; OnPropertyChanged("SongList"); }
        }

        private Song song;
        public Song Song
        {
            get { return song; }
            set { song = value; OnPropertyChanged("Song"); }
        }

        private ICommand logout;
        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand(param => LogoutExecute(), param => CanLogoutExecute());
                }
                return logout;
            }
        }
        private void LogoutExecute()
        {
            LoginView logout = new LoginView();
            view.Close();
            logout.Show();
        }
        private bool CanLogoutExecute()
        {
            return true;
        }

        private ICommand deleteSong;
        public ICommand DeleteSong
        {
            get
            {
                if (deleteSong == null)
                {
                    deleteSong = new RelayCommand(param => DeleteSongExecute(), param => CanDeleteSongExecute());
                }
                return deleteSong;
            }
        }
        private void DeleteSongExecute()
        {
            sm.DeleteSong(Song.SongID);
            SongList = sm.GetAllSongs();
        }
        private bool CanDeleteSongExecute()
        {
            if (Song == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand playSong;
        public ICommand PlaySong
        {
            get
            {
                if (playSong == null)
                {
                    playSong = new RelayCommand(param => PlaySongExecute(), param => CanPlaySongExecute());
                }
                return playSong;
            }
        }
        private void PlaySongExecute()
        {
            view.btnStopSong.Visibility = System.Windows.Visibility.Visible;
            view.btnPlaySong.Visibility = System.Windows.Visibility.Hidden;
        }
        private bool CanPlaySongExecute()
        {
            if (Song == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand stopSong;
        public ICommand StopSong
        {
            get
            {
                if (stopSong == null)
                {
                    stopSong = new RelayCommand(param => StopSongExecute(), param => CanStopSongExecute());
                }
                return stopSong;
            }
        }
        private void StopSongExecute()
        {
            view.btnStopSong.Visibility = System.Windows.Visibility.Hidden;
            view.btnPlaySong.Visibility = System.Windows.Visibility.Visible;
        }
        private bool CanStopSongExecute()
        {
            if (Song == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
