using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Input;

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
            Mp3Tag.InitTags();
            MyIndexTab = 0;
            this.TimeViewModel = new ucTimeModel(db);
            this.PlaylistViewModel = new ucPlaylistModel(db);

            db.addSound("tamaman");
            db.addSound("tapapa");
            db.addSound("tachien");
            db.addSound("tachat");
            db.addSound("tafrere");
            db.addPicture("toncul");
            db.addPicture("toncul");
            db.addPicture("et toncul");
            db.SaveSoundB();
            this.PlaylistViewModel.MediaChanged += new EventHandler<MediaChangedEventArgs>(lib_MediaChanged);
        }


        void lib_MediaChanged(object sender, MediaChangedEventArgs e)
        {
            MyIndexTab = 0;

           // db.addCurrent(e.NewMedia.path);
            this._timeViewModel.loadPath(e.NewMedia.path);
        }

        private void PlayList_Loaded(object sender, RoutedEventArgs e)
        {

        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MenuBar_Clicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fenetre = new OpenFileDialog();

            fenetre.Filter = "All Files (*.*)|*.*";
            fenetre.Title = "Select your files      ";

            if (fenetre.ShowDialog() == true)
            {
                chemin = fenetre.FileName;
                Console.WriteLine(chemin);
                //medElem.Source = new Uri(chemin);
                mediaLoaded = true;
                pause = true;
            }
        }

    }
}
