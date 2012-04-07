using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace TestUserControl
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        public String chemin;
        public bool mediaLoaded;
        public bool pause;
        DatabasePlaylist db = new DatabasePlaylist();
        private bool fullScreen = false;
        
	
        public MainWindow()
		{
			this.InitializeComponent();
            this.Timer.DataContext = new ucTimeModel(db);
            ucPlaylistModel playMod = new ucPlaylistModel(db);
            this.Playlist.DataContext = playMod;
            db.addSound("tamaman");
            db.addSound("tapapa");
            db.addSound("tachien");
            db.addSound("tachat");
            db.addSound("tafrere");
            db.addPicture("toncul");
            db.addPicture("toncul");
            db.addPicture("et toncul");
            db.SaveSoundB();
            this.Onglet.SelectedIndex = 1;
            playMod.MediaChanged += new EventHandler<MediaChangedEventArgs>(lib_MediaChanged);
 
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
          
           
           // db.LoadSoundB();
            /*
            this.Timer.buttonPlay.Click += new RoutedEventHandler(Timer_Play);
            this.MenuBar.Open.Click += new RoutedEventHandler(MenuBar_Clicked);
            chemin = "";
            mediaLoaded = false;
            pause = false;
            medElem.MouseLeftButtonDown += delegate
            {
                if (!fullScreen)
                {
                    ucTime lol = new ucTime();
                    lol.myGrid.Children.Add(medElem);
                    gridroot.Children.Remove(medElem);
                    this.Content = lol;
                    this.WindowStyle = WindowStyle.None;
                    this.WindowState = WindowState.Maximized;
                }

                else
                {
                    this.Content = myGrid;
                    gridroot.Children.Add(medElem);
                    this.WindowStyle = WindowStyle.SingleBorderWindow;
                    this.WindowState = WindowState.Normal;
                }
                fullScreen = !fullScreen;
            };
            */
        }

        void lib_MediaChanged(object sender, MediaChangedEventArgs e)
        {
            Console.WriteLine("new media is " + e.NewMedia);
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

        private void Timer_Play(object sender, RoutedEventArgs e)
        {
           /* if (mediaLoaded == true)
            {
                if (pause == true)
                {
                    medElem.Play();
                    this.Timer.buttonPlay.Content = "Pause";
                    pause = false;
                }
                else
                {
                    medElem.Pause();
                    this.Timer.buttonPlay.Content = "Play";
                    pause = true;
                }
            }
            else
            {
                MenuBar_Clicked(null, null);
            }*/
        }
	}   
}