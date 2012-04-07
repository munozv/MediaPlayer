using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestUserControl
{
    public class MediaChangedEventArgs : EventArgs
    {
        public MediaChangedEventArgs(string newMedia)
        {
            this.NewMedia = newMedia;
        }

        public string NewMedia { get; private set; }
    }
}
