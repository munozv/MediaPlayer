using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Controls;

namespace TestUserControl
{
    public class ucTimeModel : ViewModelBase
    {
        public String chemin;
        public bool mediaLoaded;
        public bool pause;
        private bool fullScreen = false;
        //public String Name;
        public string PlayText;

        private ICommand playCommand;
        private ICommand stopCommand;
        private ICommand repeatCommand;
        private ICommand shuffleCommand;
        private ICommand prevCommand;
        private ICommand nextCommand;
        private MediaElement medElem;

        public ucTimeModel()
        {

        }
        public ucTimeModel(MediaElement medelem)
        {
            chemin = "";
            mediaLoaded = false;
            pause = false;
            medElem = medelem;
            PlayText = "Play";
            //OnPropertyChanged("PlayText");
        }

        public ICommand PlayCommand
        {
            get
            {
                if (this.playCommand == null)
                    this.playCommand = new RelayCommand(() => this.doPlay(), () => this.CanPlay());
                return this.playCommand;
            }
        }

        public ICommand StopCommand
        {
            get
            {
                if (this.stopCommand == null)
                    this.stopCommand = new RelayCommand(() => this.doStop(), () => this.CanStop());
                return this.stopCommand;
            }
        }

        public ICommand RepeatCommand
        {
            get
            {
                if (this.repeatCommand == null)
                    this.repeatCommand = new RelayCommand(() => this.doRepeat(), () => this.CanRepeat());
                return this.repeatCommand;
            }
        }

        public ICommand ShuffleCommand
        {
            get
            {
                if (this.shuffleCommand == null)
                    this.shuffleCommand = new RelayCommand(() => this.doShuffle(), () => this.CanShuffle());

                return this.shuffleCommand;
            }
        }

        public ICommand PrevCommand
        {
            get
            {
                if (this.prevCommand == null)
                    this.prevCommand = new RelayCommand(() => this.doPrev(), () => this.CanPrev());
                return this.prevCommand;
            }
        }

        public ICommand NextCommand
        {
            get
            {
                if (this.nextCommand == null)
                    this.nextCommand = new RelayCommand(() => this.doNext(), () => this.CanNext());
                return this.nextCommand;
            }
        }

        private bool CanPlay()
        {
            return true;
        }

        private void doPlay()
        {
            Console.WriteLine("I do a Play");
            if (mediaLoaded == true)
            {
                if (pause == true)
                {
                    medElem.Play();
                    PlayText = "Pause";
                    OnPropertyChanged("PlayText");
                    pause = false;
                }
                else
                {
                    medElem.Pause();
                    PlayText = "Play";
                    OnPropertyChanged("PlayText");
                    pause = true;
                }
            }
        }

        private bool CanStop()
        {
            return true;
        }

        private void doStop()
        {
            Console.WriteLine("I do a Stop");
        }

        private bool CanRepeat()
        {
            return true;
        }

        private void doRepeat()
        {
            Console.WriteLine("I do a Repeat");
        }

        private bool CanShuffle()
        {
            return true;
        }

        private void doShuffle()
        {
            Console.WriteLine("I do a shuffle");
        }

        private bool CanPrev()
        {
            return true;
        }

        private void doPrev()
        {
            Console.WriteLine("I do a Prev");
        }

        private bool CanNext()
        {
            return true;
        }

        private void doNext()
        {
            Console.WriteLine("I do a next");
        }

    }

    
}
