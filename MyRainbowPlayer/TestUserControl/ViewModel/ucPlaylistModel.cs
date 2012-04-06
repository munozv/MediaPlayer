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
       
        public enum eMediaType
        {
            PICTURES,
            MUSIC,
            VIDEOS
        }

        public DatabasePlaylist db;
        private ObservableCollection<Media> p_list;
        public ObservableCollection<Media> mediaList
        {
            get { return p_list; }
            set
            {
                p_list = value;
                OnPropertyChanged("mediaList");
            }
        }
       public eMediaType Listdata;
       public ucPlaylistModel(DatabasePlaylist ddb)
        {
            db = ddb;
            Media sound = new Media();

            sound.path = "test";
            sound.name = "recupfrompath";
            sound.genre = "rock";
            sound.artist = "rocco";
            db.ListSound.Add(sound);
            MusicsFocusCommand = new DelegateCommand(doListFocus, CanListFocus);
            OnMouseDoubleClick = new DelegateCommand(doDoubleSelected, CanDoubleSelect);
            Listdata = eMediaType.MUSIC;
            mediaList = new ObservableCollection<Media>(db.ListSound);
        }
        public ucPlaylistModel()
        {
            db = null;
        }

        public ICommand MusicsFocusCommand
        { get; set; }
        public ICommand OnMouseDoubleClick
        { get; set; }

        private bool CanDoubleSelect()
        {
            return true;
        }

        private bool CanListFocus()
        {
            return true;
        }

        private bool CanChangeList()
        {
            return true;
        }

        private void doDoubleSelected(object param)
        {
            Console.WriteLine("here " + param.ToString());
        }

        private void doChangeList(object param)
        {

        }

        private void doListFocus(object param)
        {
            TreeViewItem tv = param as TreeViewItem;
            Console.WriteLine(tv.Header);
            String header = tv.Header.ToString();
            if (header == "Musics")
            {
                Listdata = eMediaType.MUSIC;
                mediaList = new ObservableCollection<Media>(db.ListSound);
            }
            else if (header == "Pictures")
            {
                Listdata = eMediaType.PICTURES;
                mediaList = new ObservableCollection<Media>(db.ListPicture);
            }
            else if (header == "Videos")
            {
                Listdata = eMediaType.VIDEOS;
                mediaList = new ObservableCollection<Media>(db.ListVideo);
            }
        }
    }
}
