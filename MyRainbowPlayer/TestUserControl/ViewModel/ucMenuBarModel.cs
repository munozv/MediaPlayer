using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;

namespace TestUserControl
{
    class ucMenuBarModel : ViewModelBase
    {
        public MediaElement medelem;

        private ICommand addIn;

        private string filetoload;

        public string FileToLoad
        {
            get { return filetoload; }
            set
            {
                filetoload = value;
                OnPropertyChanged("FileToLoad");
            }
        }
        

        public ucMenuBarModel()
        {

        }
        public ICommand AddInCommand
        {
            get
            {
                if (this.addIn == null)
                    this.addIn = new RelayCommand(() => this.DoAddIn(), () => this.CanAddIn());
                return this.addIn;
            }
        }

        public void DoAddIn()
        {
            OpenFileDialog dial = new OpenFileDialog();

            dial.Filter = "Media File (*.mp3, *.wmv, *.jpg)|*.mp3; *.wma; *.wmv; *.avi; *.jpg";
            dial.Title = "Select your media ";

            if (dial.ShowDialog() == true)
            {
                filetoload = dial.FileName;
                Console.WriteLine("ajout dune musique.");
            }
            
        }

        public bool CanAddIn()
        {
            return (true);
        }
    }
}
