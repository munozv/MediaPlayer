using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestUserControl
{
    public class DatabasePlaylist
    {
        private List<myPicture> listPicture;
        public List<myPicture> ListPicture
        {
            get { return listPicture; }
            set { listPicture = value; }
        }

        private List<mySound> listSound;
        public List<mySound> ListSound
        {
            get { return listSound; }
            set { listSound = value; }
        }

        private List<myVideo> listVideo;
        public List<myVideo> ListVideo
        {
            get { return listVideo; }
            set { listVideo = value; }
        }

        public DatabasePlaylist()
        {
            ListPicture = new List<myPicture>();
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

        public void deleteSound(mySound it)
        {
            listSound.Remove(it);
        }

        public void addVideo(String path)
        {
            // gettage des infos depuis le path
            myVideo video = new myVideo();

            video.name = "recupfrompath";
            video.genre = "action";
            // blablabla

            listVideo.Add(video);
        }
        public void addPicture(String path)
        {
            // gettage des infos depuis le path
            myPicture picture = new myPicture();

            picture.name = "recupfrompath";
            // blablabla

            ListPicture.Add(picture);
        }
        

    }
}
