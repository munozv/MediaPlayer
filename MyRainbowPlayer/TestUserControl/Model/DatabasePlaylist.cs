using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestUserControl
{
    class DatabasePlaylist
    {
        public List<myPicture> listPicture;
        public List<mySound> listSound;
        public List<myVideo> listVideo;
        
        public DatabasePlaylist()
        {
            listPicture = new List<myPicture>();
            listSound = new List<mySound>();
            listVideo = new List<myVideo>();
        }

        public void addSound(String path)
        {
            // gettage des infos depuis le path
            mySound sound = new mySound();

            sound.name = "recupfrompath";
            sound.genre = "rock";
            // blablabla

            listSound.Add(sound);
        }
    }
}
