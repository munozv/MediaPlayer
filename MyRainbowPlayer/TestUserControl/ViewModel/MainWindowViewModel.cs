using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Input;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using System.IO;

namespace TestUserControl
{
    class MainWindowViewModel : ViewModelBase
    {
        public String chemin;
        public bool mediaLoaded;
        public bool pause;
        DatabasePlaylist db = new DatabasePlaylist();
        private bool fullScreen = false;

        private int _MyIndexTab;
        public int MyIndexTab
        {
            get { return _MyIndexTab; }

            set
            {
                _MyIndexTab = value;
                OnPropertyChanged("MyIndexTab");
            }
        }
        private ucTimeModel _timeViewModel;
        public ucTimeModel TimeViewModel
        {
            get { return _timeViewModel; }
            set
            {
                _timeViewModel = value;
            }
        }
        private ucPlaylistModel _playlistViewModel;
        public ucPlaylistModel PlaylistViewModel
        {
            get { return _playlistViewModel; }
            set
            {
                _playlistViewModel = value;
            }
        }

        public MainWindowViewModel()
        {
            MyIndexTab = 0;
            this.TimeViewModel = new ucTimeModel(db);
            this.PlaylistViewModel = new ucPlaylistModel(db);
            

            db.LoadB();
            this.PlaylistViewModel.MediaChanged += new EventHandler<MediaChangedEventArgs>(lib_MediaChanged);
        }


        public void aboutToClose(object sender, EventArgs e)
        {
            db.SaveB();
        }

        void lib_MediaChanged(object sender, MediaChangedEventArgs e)
        {
            MyIndexTab = 0;
            this._timeViewModel.loadPath(e.NewMedia.path, e.nb, e.l);
        }

        private void PlayList_Loaded(object sender, RoutedEventArgs e)
        {

        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
