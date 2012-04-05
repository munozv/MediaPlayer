using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace TestUserControl
{
    public class ucPlaylistModel : ViewModelBase
    {
        private ObservableCollection<mySound> p_list;
        public enum eMediaType
        {
            PICTURES,
            MUSIC,
            VIDEOS
        }

        public DatabasePlaylist db;
        public ObservableCollection<mySound> soundList
        {
            get { return p_list; }

            set
            {
                p_list = value;
                OnPropertyChanged("soundList");
            }
        }
       public eMediaType _listdata;
        public eMediaType Listdata
        {
            get { return _listdata; }
            protected set
            {
                _listdata = value;
                OnPropertyChanged("Listdata");
            }
        }
        public ucPlaylistModel(DatabasePlaylist ddb)
        {
            db = ddb;
            mySound sound = new mySound();

            sound.path = "test";
            sound.Name = "recupfrompath";
            sound.genre = "rock";
            sound.Artist = "rocco";
            db.ListSound.Add(sound);
            // blablabla
            MusicsFocusCommand = new DelegateCommand(doListFocus, CanListFocus);
            Listdata = eMediaType.MUSIC;
            soundList = new ObservableCollection<mySound>(db.ListSound);
        }
        public ucPlaylistModel()
        {
            db = null;
        }

        public ICommand MusicsFocusCommand
        { get; set; }

        private bool CanListFocus()
        {
            return true;
        }

        private void doListFocus(object param)
        {
            if (param != null)
                Console.WriteLine(param.ToString());
            TreeViewItem tv = param as TreeViewItem;
            if (tv.Header == "Musics")
            {
                Console.WriteLine(param.ToString());
                Listdata = eMediaType.MUSIC;
                soundList = new ObservableCollection<mySound>(db.ListSound);
            }
            else if (tv.Header == "Pictures")
                ;
            else if (tv.Header == "Videos")
                ;
        }
    }
}
