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

    public class Media : ViewModelBase
    {
        public String name { get; set; }
        public String artist { get; set; }
        public String album { get; set; }
        public String genre { get; set; }
        public DateTime time { get; set; }
        public String path { get; set; }
        public uint kbsize { get; set; }
        public eMediaType type { get; set; }
        public String width { get; set; }
        public String height { get; set; }
        public String date { get; set; }
        public String copyright { get; set; }
    }

    public class myPicture : Media
    {
        public DateTime date;

        public myPicture()
        {
            this.type = eMediaType.PICTURE;
        }
    }
    public class myVideo : Media
    {
        public DateTime time { get; set; }
        public uint year { get; set; }
        public String genre { get; set; }

        public myVideo()
        {
            this.type = eMediaType.VIDEO;
        }
    }

    public class mySound : Media
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
