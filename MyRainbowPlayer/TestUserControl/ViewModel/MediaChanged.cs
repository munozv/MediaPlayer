using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace TestUserControl
{
    public class MediaChangedEventArgs : EventArgs
    {
        public MediaChangedEventArgs(Media newMedia, int _n, ObservableCollection<Media> _l)
        {
            this.NewMedia = newMedia;
            nb = _n;
            l = _l;
        }

        public Media NewMedia { get; private set; }
        public int nb { get; private set; }
        public ObservableCollection<Media> l { get; private set; }
    }
}
