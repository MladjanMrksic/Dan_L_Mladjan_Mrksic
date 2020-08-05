using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicPlayer.Model
{
    class SongModel
    {
        public List<Song> GetAllSongs()
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    return (from x in context.Songs select x).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public Song GetSong(int ID)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    return (from x in context.Songs where x.SongID == ID select x).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public void DeleteSong(int ID)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    context.Songs.Remove((from x in context.Songs where x.SongID == ID select x).FirstOrDefault());
                    context.SaveChanges();
                    MessageBox.Show("Action successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void AddSong (Song song)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    context.Songs.Add(song);
                    context.SaveChanges();
                    MessageBox.Show("Action successfull!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void UpdateSong (Song song)
        {
            try
            {
                using (AudioPlayerEntities context = new AudioPlayerEntities())
                {
                    Song s = (from x in context.Songs where x.SongID == song.SongID select x).FirstOrDefault();
                    s = song;
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
