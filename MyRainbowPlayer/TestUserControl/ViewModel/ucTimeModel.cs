using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows;

namespace TestUserControl
{
    public class ucTimeModel : ViewModelBase
    {
        private String _path;
        public String path
        {
            get { return _path; }
            set { _path = value; OnPropertyChanged("path"); Console.WriteLine("path dans uctime changed"); }
        }

        private MediaElement _myMedElem;
        public MediaElement myMedElem
        {
            get { return _myMedElem; }
            set { _myMedElem = value; }
        }
        public bool mediaLoaded;
        public bool pause;
        private bool fullScreen = false;
        public bool isPlay;
        DatabasePlaylist db;

        string _TextPlay;
        MediaElement MyMediaElement;

        public string TextPlay
        {
            get { return _TextPlay; }
            set
            {
                _TextPlay = value;
                OnPropertyChanged("TextPlay");
            }
        }

        public ucTimeModel()
        {
            db = null;
        }
        public ucTimeModel(DatabasePlaylist _db)
        {
            db = _db;
            Console.WriteLine("path is " + path + " current path is " + _db.currentPath);
            db.currentPath = "lolilol";
            Console.WriteLine("path is " + path + " current path is " + db.currentPath);
            mediaLoaded = false;
            pause = false;
            isPlay = false;
            TextPlay = "|>";
            PlayCommand = new DelegateCommand(doPlay, CanPlay);
            NextCommand = new DelegateCommand(doNext, CanNext);
            PrevCommand = new DelegateCommand(doPrev, CanPrev);
            ShuffleCommand = new DelegateCommand(doShuffle, CanShuffle);
            StopCommand = new DelegateCommand(doStop, CanStop);
            RepeatCommand = new DelegateCommand(doRepeat, CanRepeat);
         //   Fullscreen = new DelegateCommand(doFullscreen, CanFullscreen);
        }

        public ICommand Fullscreen
        { get; set; }

        public bool CanFullscreen()
        {
            return true;
        }

        public void doFullscreen(object param)
        {
/*            if (!fullScreen)
            {
                ucTime lol = new ucTime();
                lol.DataContext = this;
                lol.MedElem = myMedElem;
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
            fullScreen = !fullScreen;*/
        }

        public void setTimer()
        {
            DTimer = new DispatcherTimer(DispatcherPriority.Background, myMedElem.Dispatcher);
            DTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            DTimer.Tick += new EventHandler(DTimer_Tick);
            DTimer.Start();
            this.myMedElem.MediaOpened += new RoutedEventHandler(myMedOpened);
        }
        public ICommand PlayCommand
        { get; set; }
        public ICommand StopCommand
        { get; set; }
        public ICommand RepeatCommand
        { get; set; }
        public ICommand ShuffleCommand
        { get; set; }
        public ICommand PrevCommand
        { get; set; }
        public ICommand NextCommand
        { get; set; }

        private Uri _SelectedVideoProperty;
        public Uri SelectedVideoProperty
        {
            get
            {
                return this._SelectedVideoProperty;
            }
            set
            {
                this._SelectedVideoProperty = value;
                OnPropertyChanged("SelectedVideoProperty");
            }
        }

        public ICommand MediaOpenedCommand { get; set; }
        public void MediaOpened(object param)
        {
            MediaElement parmMediaElement = (MediaElement)param;
            MyMediaElement = parmMediaElement;
        }

        private void myMedOpened(object sender, RoutedEventArgs e)
        {
            MaxSlidValue = myMedElem.NaturalDuration.TimeSpan.TotalMilliseconds;

        }
        private bool CanMediaOpened(object param)
        {
            return true;
        }


        private bool CanPlay()
        {
            return true;
        }

        private double _ValueTimer;
        public double ValueTimer
        {
            get { return _ValueTimer; }
            set { _ValueTimer = value; OnPropertyChanged("ValueTimer"); }
        }

        private DispatcherTimer DTimer;
        public bool _userUpdatingTime;

        private double _MaxSlidValue;
        public double MaxSlidValue
        {
            get { return _MaxSlidValue; }
            set { _MaxSlidValue = value; OnPropertyChanged("MaxSlidValue"); }
        }

        void DTimer_Tick(object sender, EventArgs e)
        {
            if (myMedElem != null && myMedElem.IsLoaded)
            {
                if (path != null && myMedElem.Source != null && path != myMedElem.Source.ToString())
                {

                    myMedElem.Source = new Uri(path);

                    myMedElem.Play();

                }
                if (!_userUpdatingTime)
                    ValueTimer = myMedElem.Position.TotalMilliseconds;
                //                txtBuffer.Text = (myMedElem.BufferingProgress * 100).ToString();


                /*TimeSpan ts = myMedEle.Position;
                StringBuilder sb = new StringBuilder();
                sb.Append(ts.Hours + ":");
                sb.Append(ts.Minutes + ":");
                sb.Append(ts.Seconds);*/
                //  txtPosition.Text = sb.ToString();

            }
        }

        public void sldTimeLine_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _userUpdatingTime = true;
        }

        public void sldTimeLine_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Slider sldTimeLine = sender as Slider;

            if (myMedElem != null && myMedElem.NaturalDuration.HasTimeSpan && this._userUpdatingTime)
                myMedElem.Position = new TimeSpan(0, 0, 0, 0, (int)sldTimeLine.Value);
            _userUpdatingTime = false;
        }


        public void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider s = sender as Slider;
            myMedElem.Volume = s.Value;
        }


        public void loadPath(String path)
        {
            pause = true;
            TextPlay = "|>";
            myMedElem.Source = new Uri(path);
        }

        private void doPlay(object param)
        {
            if (myMedElem.IsLoaded == true)
            {

                if (pause == true)
                {
                    myMedElem.Play();

                    pause = false;
                    TextPlay = "||";
                }
                else
                {
                    myMedElem.Pause();
                    TextPlay = "|>";
                    pause = true;
                }
            }
        }

        private bool CanStop()
        {
            return true;
        }

        private void doStop(object param)
        {
            if (myMedElem.IsLoaded == true)
            {
                myMedElem.Stop();
                pause = true;
                TextPlay = "|>";
            }
        }

        private bool CanRepeat()
        {
            return true;
        }

        private void doRepeat(object param)
        {
            Console.WriteLine("I do a Repeat");
        }

        private bool CanShuffle()
        {
            return true;
        }

        private void doShuffle(object param)
        {
            Console.WriteLine("I do a shuffle");
        }

        private bool CanPrev()
        {
            return true;
        }

        private void doPrev(object param)
        {

        }

        private bool CanNext()
        {
            return true;
        }

        private void doNext(object param)
        {

        }

    }


}
