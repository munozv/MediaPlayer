using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Media;

namespace TestUserControl
{
    public class ucPlaylistModel : ViewModelBase
    {
        public enum eMediaType
        {
            ALL,
            PICTURES,
            MUSIC,
            VIDEOS
        }

        #region Command

        public ICommand MusicsFocusCommand
        { get; set; }
        public ICommand OpenFile
        { get; set; }
        public ICommand CreatePlaylist
        { get; set; }


        public bool CanOpenFile()
        {
            return true;
        }

        public bool CanCreateList()
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
        #endregion

        public string chemin { get; set; }
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

        private Visibility _createVisibility;
        public Visibility createVisibility
        {
            get { return _createVisibility; }
            set { _createVisibility = value; OnPropertyChanged("createVisibility"); }
        }

        private Dictionary<String, ObservableCollection<Media>> _dico;

        public Dictionary<String, ObservableCollection<Media>> dico
        {
            get { return _dico; }
            set { _dico = value; OnPropertyChanged("dico"); }
        }

        public eMediaType Listdata;
        public ucPlaylistModel(DatabasePlaylist ddb)
        {
            db = ddb;
            MusicsFocusCommand = new DelegateCommand(doListFocus, CanListFocus);
            OpenFile = new DelegateCommand(doOpenFile, CanOpenFile);
            Listdata = eMediaType.MUSIC;
//            mediaList = new ObservableCollection<Media>(db.ListCurrent);
            CreatePlaylist = new DelegateCommand(doCreateList, CanCreateList);
            dico = db.playlists;
            Media m = new Media();
            m.artist = "lol";
            m.path = "coucou";
            ObservableCollection<Media> oc = new ObservableCollection<Media>();
            oc.Add(m);
            dico.Add("test", oc);
            dico.Add("test2", oc);
        }

        public void setVisibilityCreate(object param, RoutedEventArgs e)
        {
            if (db.ListCurrent.Count() != 0)
                createVisibility = Visibility.Visible;
            else
                createVisibility = Visibility.Collapsed;
        }

        public void doCreateList(object param)
        {
            ucNewPlaylistModel npm = new ucNewPlaylistModel();
            ucNewPlaylist window = new ucNewPlaylist();
            window.DataContext = npm;
            window.Title = "Create a New Playlist";
            window.ShowDialog();
            Console.WriteLine("Playlist name = " + npm.text);
            db.addPlaylist(npm.text);
        }

        private void doListFocus(object param)
        {
            TreeViewItem tv = param as TreeViewItem;
            if (tv == null)
            {
                KeyValuePair<String, ObservableCollection<Media>> di = (KeyValuePair<String, ObservableCollection<Media>>)param;
                Listdata = eMediaType.ALL;
                mediaList = new ObservableCollection<Media>(di.Value);
            }
            else
            {
                String header = tv.Header.ToString();
                Console.WriteLine("header is " + header); 
                if (header == "Current Playlist")
                {
                    Listdata = eMediaType.ALL;
                    mediaList = new ObservableCollection<Media>(db.ListCurrent);
                }
                else if (header == "Musics")
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

        public void doOpenFile(object param)
        {
            OpenFileDialog fenetre = new OpenFileDialog();

            fenetre.Filter = "All Files (*.*)|*.*";
            fenetre.Title = "Select your files     ";

            if (fenetre.ShowDialog() == true)
            {
                chemin = fenetre.FileName;
                db.addCurrent(chemin);
                Console.WriteLine("chemin is " + chemin);
                mediaList = new ObservableCollection<Media>(db.ListCurrent);
            }
        }

        public void OnMouseDoubleClick2(object sender, MouseButtonEventArgs e)
        {
            DataGrid myplay = (DataGrid)sender;

            if (myplay.SelectedItem != null)
            {
                Media med = (Media)myplay.SelectedItem;
                Console.WriteLine("med.path = " + med.path);
                db.currentPath = med.path;
                e.Handled = true;
                OnMediaChanged(med);
            }
        }
        public void OnMediaChanged(Media MediaSource)
        {
            if (MediaChanged != null)
                MediaChanged(this, new MediaChangedEventArgs(MediaSource));
        }
        public event EventHandler<MediaChangedEventArgs> MediaChanged;


    }
}
