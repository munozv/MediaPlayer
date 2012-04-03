using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestUserControl
{
    public enum eMediaType
    {
        PICTURE,
        VIDEO,
        SOUND,
        NOTHING
    }

    public abstract class AMedia : ViewModelBase
    {
        private String name;
        public String Name
        {
            get {return name;}
            set
            {
                name = value;
                OnPropertyChanged("name");
            }
        }

        public String path { get; set; }
        public uint kbsize { get; set; }
        public eMediaType type { get; set; }
    }

    public class myPicture : AMedia
    {
        public DateTime date;

        public myPicture()
        {
            this.type = eMediaType.PICTURE;
        }
    }
    public class myVideo : AMedia
    {
        public DateTime time { get; set; }
        public uint year { get; set; }
        public String genre { get; set; }

        public myVideo()
        {
            this.type = eMediaType.VIDEO;
        }
    }

    public class mySound : AMedia
    {
        private String artist;
        public String Artist
        {
            get { return artist; }
            set
            {
                artist = value;
                OnPropertyChanged("artist");
            }
        }

        public String album { get; set; }
        public String genre { get; set; }
        public DateTime time { get; set; }

        public mySound()
        {
            this.type = eMediaType.SOUND;
        }
    }
}
