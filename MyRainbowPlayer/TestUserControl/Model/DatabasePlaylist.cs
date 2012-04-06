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
        private List<Media> listPicture;
        public List<Media> ListPicture
        {
            get { return listPicture; }
            set { listPicture = value; }
        }
        private List<Media> listSound;
        public List<Media> ListSound
        {
            get { return listSound; }
            set { listSound = value; }
        }
        private List<Media> listVideo;
        public List<Media> ListVideo
        {
            get { return listVideo; }
            set { listVideo = value; }
        }

        public DatabasePlaylist()
        {
            ListPicture = new List<Media>();
            listSound = new List<Media>();
            listVideo = new List<Media>();
        }

        public void SaveSoundB()
        {
            XmlSerializer xse = new XmlSerializer(typeof(List<Media>));
            FileStream fs = new FileStream("songs.xml", FileMode.Create);

            xse.Serialize(fs, ListSound);
        }

        public void LoadSoundB()
        {
            int i = 0;
            XmlSerializer xse = new XmlSerializer(typeof(List<Media>));
            FileStream fs = new FileStream("songs.xml", FileMode.Open);
            listSound = (List<Media>) xse.Deserialize(fs);
            
            while (i != listSound.Count())
            {
                Console.WriteLine("album " + i + " " + listSound[i].path);
                i++;
            }
        }

        public void addSound(String path)
        {
            // gettage des infos depuis le path
            Media sound = new Media();

            sound.path = path;
            sound.name = "recupfrompath";
            sound.genre = "rock";
            sound.artist = "rocco";
            // blablabla

            listSound.Add(sound);
        }
        public void deleteSound(Media it)
        {
            listSound.Remove(it);
        }
        public void addVideo(String path)
        {
            // gettage des infos depuis le path
            Media video = new Media();

            video.name = "recupfrompath";
            video.genre = "action";
            // blablabla

            listVideo.Add(video);
        }
        public void addPicture(String path)
        {
            // gettage des infos depuis le path
            Media picture = new Media();

            picture.name = "recupfrompath";
            // blablabla

            ListPicture.Add(picture);
        }
    }
}
