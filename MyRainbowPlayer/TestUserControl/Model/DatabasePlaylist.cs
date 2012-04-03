using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

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

        public void SaveSoundB()
        {
            XmlSerializer xse = new XmlSerializer(typeof(List<mySound>));
            FileStream fs = new FileStream("songs.xml", FileMode.Create);

            xse.Serialize(fs, ListSound);
        }

        public void LoadSoundB()
        {
            int i = 0;
            XmlSerializer xse = new XmlSerializer(typeof(List<mySound>));
            FileStream fs = new FileStream("songs.xml", FileMode.Open);
            listSound = (List<mySound>) xse.Deserialize(fs);
            
            while (i != listSound.Count())
            {
                Console.WriteLine("album " + i + " " + listSound[i].path);
                i++;
            }
        }

        public void addSound(String path)
        {
            // gettage des infos depuis le path
            mySound sound = new mySound();

            sound.path = path;
            sound.Name = "recupfrompath";
            sound.genre = "rock";
            sound.Artist = "rocco";
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

            video.Name = "recupfrompath";
            video.genre = "action";
            // blablabla

            listVideo.Add(video);
        }
        public void addPicture(String path)
        {
            // gettage des infos depuis le path
            myPicture picture = new myPicture();

            picture.Name = "recupfrompath";
            // blablabla

            ListPicture.Add(picture);
        }
    }
}
