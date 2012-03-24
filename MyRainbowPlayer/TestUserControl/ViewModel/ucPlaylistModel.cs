using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace TestUserControl
{
    public class ucPlaylistModel
    {
        public MediaElement medelem;

        public ucPlaylistModel()
        {

        }

        public ucPlaylistModel(MediaElement medel)
        {
            medelem = medel;
        }

    }
}
