using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Threading;

namespace TestUserControl
{
    public class ucTimeModel : ViewModelBase
    {
        public String chemin;
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
            protected set
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
            chemin = "";
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
            Console.WriteLine("test mediaopened");
        }

        private bool CanMediaOpened(object param)
        {
            return true;
        }


        private bool CanPlay()
        {
            return true;
        }

        private void doPlay(object param)
        {
            Console.WriteLine("I do a Play");
            if (mediaLoaded == true)
            {
                if (pause == true)
                {
                 //   this.MedElem.Play();
                    isPlay = false;
                    TextPlay = "||";
                    pause = false;
                }
                else
                {
                 //   MedElem.Pause();
                    isPlay = true;
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
            Console.WriteLine("I do a Stop");
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
