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
        public String path { get; set; }
        public String copyright { get; set; }
        public eMediaType type { get; set; }
    }

  
}
