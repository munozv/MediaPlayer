using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestUserControl
{
    public class MediaChangedEventArgs : EventArgs
    {
        public MediaChangedEventArgs(Media newMedia)
        {
            this.NewMedia = newMedia;
        }

        public Media NewMedia { get; private set; }
    }
}
