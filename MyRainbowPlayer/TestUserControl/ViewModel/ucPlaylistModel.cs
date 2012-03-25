using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace TestUserControl
{
    public class ucPlaylistModel : ViewModelBase
    {
        public DatabasePlaylist db;

        public ucPlaylistModel(DatabasePlaylist ddb)
        {
            db = ddb;
        }
        public ucPlaylistModel()
        {
            db = null;
        }
    }
}
