using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace TestUserControl
{
    class ucNewPlaylistModel : ViewModelBase
    {
        public ucNewPlaylistModel()
        {
            create = new DelegateCommand(doCreate, CanCreate);
            close = new DelegateCommand(doClose, CanClose);
            text = "New Playlist";
        }

        public ICommand create
        { get; set; }
        public ICommand close
        { get; set; }

        private String _text;
        public String text
        {
            get { return _text; }
            set { _text = value; OnPropertyChanged("text"); }
        }
    
        public void doClose(object param)
        {
            ucNewPlaylist np = param as ucNewPlaylist;
            text = "";
            np.Close();
        }
        
        public void doCreate(object param)
        {
            if (text != "")
            {
                ucNewPlaylist np = param as ucNewPlaylist;
                np.Close();
            }
        }

        public bool CanCreate()
        {
            if (text == "")
                return false;
            return true;
        }

        public bool CanClose()
        {
            return true;
        }
    }
}
