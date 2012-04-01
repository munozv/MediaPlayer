using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestUserControl
{
    public class ucPlaylistModel : ViewModelBase
    {
        public DatabasePlaylist db;

        public ucPlaylistModel(DatabasePlaylist ddb)
        {
            db = ddb;
            MusicsFocusCommand = new DelegateCommand(doListFocus, CanListFocus);
          
        }
        public ucPlaylistModel()
        {
            db = null;
        }

        public ICommand MusicsFocusCommand
        { get; set; }

        private bool CanListFocus()
        {
            return true;
        }

        private void doListFocus(object param)
        {
            if (param != null)
                Console.WriteLine(param.ToString());
            TreeViewItem tv = param as TreeViewItem;
            if (tv.Header == "Musics")
                ;
            else if (tv.Header == "Pictures")
                ;
            else if (tv.Header == "Videos")
                ;
        }
    }
}
