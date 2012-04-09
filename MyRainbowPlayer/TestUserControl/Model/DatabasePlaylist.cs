using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;

namespace TestUserControl
{
    public class DatabasePlaylist : ViewModelBase
    {
        private String _curPath;

        public String currentPath
        {
            get { return _curPath; }
            set
            {
                _curPath = value;
                OnPropertyChanged("currentPath");
            }
        }

        public void addCurrent(String path)
        {
            Media media = new Media();
            Mp3Tag tag = new Mp3Tag(path);

            if (tag.ReadData())
            {
                Console.WriteLine("========= " + tag.FileName + " =========");
                Console.WriteLine("Title:   " + tag.Title);
                Console.WriteLine("Artist:  " + tag.Artist);
                Console.WriteLine("Album:   " + tag.Album);
                Console.WriteLine("Year:    " + tag.Year);
                Console.WriteLine("Track:   " + tag.Track);
                Console.WriteLine("Comment: " + tag.Comment);
                Console.WriteLine("Genre:   " + tag.Genre);
                Console.WriteLine("");
                media.path = path;
                media.name = tag.Title;
                media.genre = tag.Genre;
                media.artist = tag.Artist;
                media.type = eMediaType.SOUND;
                listCurrent.Add(media);
            }
            else
                Console.WriteLine("EPIC FAIL");
        }
        private List<Media> listCurrent;
        public List<Media> ListCurrent
        {
            get { return listCurrent; }
            set { listCurrent = value; }
        }

        
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
            currentPath = "debut";
            ListPicture = new List<Media>();
            listSound = new List<Media>();
            listVideo = new List<Media>();
            ListCurrent = new List<Media>();
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
            listSound = (List<Media>)xse.Deserialize(fs);

            while (i != listSound.Count())
            {
                Console.WriteLine("album " + i + " " + listSound[i].path);
                i++;
            }
        }

        public void addInLibrary(Media newMed)
        {

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
