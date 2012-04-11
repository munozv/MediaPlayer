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
        public ICommand RequestFocusCommand
        { get; set; }
        public ICommand OpenFile
        { get; set; }
        public ICommand CreatePlaylist
        { get; set; }
        public ICommand affAbout
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
        private bool CanAffAbout()
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

        private List<String> _listdico;
        public List<String> listdico
        {
            get { return _listdico; }
            set { _listdico = value; OnPropertyChanged("listdico"); }
        }
        public eMediaType Listdata;

        public ucPlaylistModel(DatabasePlaylist ddb)
        {
            db = ddb;
            MusicsFocusCommand = new DelegateCommand(doListFocus, CanListFocus);
            RequestFocusCommand = new DelegateCommand(doRequestFocus, CanRequestFocus);
            OpenFile = new DelegateCommand(doOpenFile, CanOpenFile);
            Listdata = eMediaType.MUSIC;
            //            mediaList = new ObservableCollection<Media>(db.ListCurrent);
            CreatePlaylist = new DelegateCommand(doCreateList, CanCreateList);
            affAbout = new DelegateCommand(doAffAbout, CanAffAbout);
            islinqRequest = false;
            Actualizedico();
        }

        public void doAffAbout(object param)
        {
            AboutUs window = new AboutUs();
            window.Title = "About Us";
            window.ShowDialog();
        }

        public void Actualizedico()
        {
            listdico = new List<string>();
            foreach (KeyValuePair<String, ObservableCollection<Media>> entry in db.playlists)
            {
                listdico.Add(entry.Key);
                Console.WriteLine("coucou lol" + entry.Key);
            }
            OnPropertyChanged("listdico");
        }

        public bool CanRequestFocus()
        {
            return true;
        }

        public void doRequestFocus(object param)
        {

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
            db.addPlaylist(npm.text);
            Actualizedico();
        }

        private bool islinqRequest;
        private String medRequest;
        private void doListFocus(object param)
        {
            TreeViewItem tv = param as TreeViewItem;
            islinqRequest = false;
            if (tv == null)
            {
                String s = param as String;
                var v = from entry in db.playlists
                        where (entry.Key == s)
                        select entry;

                Listdata = eMediaType.ALL;
                foreach (KeyValuePair<String, ObservableCollection<Media>> r in v)
                {
                    mediaList = new ObservableCollection<Media>(r.Value);
                    return;
                }
                return;
           }
            else
            {
                String header = tv.Header.ToString();
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
                #region linq_request
                else if (header == "Artist")
                {
                    var stuff = from entry in db.ListSound
                                group entry by entry.artist
                                    into g
                                    select new { Remainder = g.Key };
                    ObservableCollection<Media> ocm = new ObservableCollection<Media>();
                    foreach (var g in stuff)
                    {
                        Media m = new Media();
                        m.artist = g.Remainder;
                        m.type = TestUserControl.eMediaType.SOUND;
                        ocm.Add(m);
                        mediaList = ocm;
                    }
                    islinqRequest = true;
                    medRequest = "Artist";
                }
                else if (header == "Genre")
                {
                    var stuff = from entry in db.ListSound
                                group entry by entry.genre
                                    into g
                                    select new { Remainder = g.Key };
                    ObservableCollection<Media> ocm = new ObservableCollection<Media>();
                    foreach (var g in stuff)
                    {
                        Media m = new Media();
                        m.genre = g.Remainder;
                        m.type = TestUserControl.eMediaType.SOUND;
                        ocm.Add(m);
                        mediaList = ocm;
                    }
                    islinqRequest = true;
                    medRequest = "Genre";
                }
                else if (header == "Album")
                {
                    var stuff = from entry in db.ListSound
                                group entry by entry.album
                                    into g
                                    select new { Remainder = g.Key };
                    ObservableCollection<Media> ocm = new ObservableCollection<Media>();
                    foreach (var g in stuff)
                    {
                        Media m = new Media();
                        m.album = g.Remainder;
                        m.type = TestUserControl.eMediaType.SOUND;
                        ocm.Add(m);
                        mediaList = ocm;
                    }
                    islinqRequest = true;
                    medRequest = "Album";
                }
                #endregion
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
                mediaList = new ObservableCollection<Media>(db.ListCurrent);
            }
        }

        public void OnMouseDoubleClick2(object sender, MouseButtonEventArgs e)
        {
            DataGrid myplay = (DataGrid)sender;


            if (islinqRequest == true)
            {
                Media med = (Media)myplay.SelectedItem;
                if (medRequest == "Artist")
                {
                    var stuff = from entry in db.ListSound
                                where (entry.artist == med.artist)
                                select entry;
                    List<Media> nwList = new List<Media>();
                    foreach (Media m in stuff)
                        nwList.Add(m);
                    mediaList = new ObservableCollection<Media>(nwList);
                    Console.WriteLine("time to play artist");
                    islinqRequest = false;
                }
                else if (medRequest == "Album")
                {
                    var stuff = from entry in db.ListSound
                                where (entry.album == med.album)
                                select entry;
                    List<Media> nwList = new List<Media>();
                    foreach (Media m in stuff)
                        nwList.Add(m);
                    mediaList = new ObservableCollection<Media>(nwList);
                    islinqRequest = false;
                }
                else if (medRequest == "Genre")
                {
                    var stuff = from entry in db.ListSound
                                where (entry.genre == med.genre)
                                select entry;
                    List<Media> nwList = new List<Media>();
                    foreach (Media m in stuff)
                        nwList.Add(m);
                    mediaList = new ObservableCollection<Media>(nwList);
                    islinqRequest = false;
                }

            }
            else if (myplay.SelectedItem != null)
            {
                Media med = (Media)myplay.SelectedItem;
                db.currentPath = med.path;
                e.Handled = true;
                OnMediaChanged(med, myplay.SelectedIndex, mediaList);
            }
        }


        public void OnMediaChanged(Media MediaSource, int n, ObservableCollection<Media> t)
        {
            if (MediaChanged != null)
                MediaChanged(this, new MediaChangedEventArgs(MediaSource, n, t));
        }
        public event EventHandler<MediaChangedEventArgs> MediaChanged;


    }
}
