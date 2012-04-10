using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using System.Reflection;

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
                Console.WriteLine("_curPath = " + _curPath);
            }
        }

        public void addCurrent(String path)
        {
            Media media = new Media();
            if (path == currentPath)
                return;
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
            {
                JPGTag tagjpg = new JPGTag(path);
                if (tagjpg.ReadData() == true)
                {
                    media.path = path;
                    media.artist = tagjpg.ImageArtist;
                    media.copyright = tagjpg.Copyright;
                    media.date = tagjpg.ImageDate;
                    media.height = tagjpg.ImageHeight;
                    media.width = tagjpg.ImageWidth;
                    media.type = eMediaType.SOUND;
                }
                else
                {
                    media.path = path;
                    media.name = path;
                }
            }

            listCurrent.Add(media);
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
            createDico();
        }

        public Dictionary<String, ObservableCollection<Media>> playlists;

        public void createDico()
        {
            playlists = new Dictionary<string, ObservableCollection<Media>>();

        }

        public void addPlaylist(String str)
        {
            playlists.Add(str, new ObservableCollection<Media>(listCurrent));

            var stuff = from entry in listSound
                        where (entry.artist == "test")
                        select entry;
            Console.WriteLine("stuff is a " + stuff.ToString());
            foreach (Media med in stuff)
            {
                Console.WriteLine("one media " + med.artist);
            }
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
            string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string filePath = Path.Combine(directory, "songs.xml");

            if (File.Exists(filePath) == true)
            {
                FileStream fs = new FileStream("songs.xml", FileMode.Open);
                if (fs.CanRead == true)
                {
                    try
                    {
                        listSound = (List<Media>)xse.Deserialize(fs);
                    }
                    catch (Exception e)
                    {
                        return;
                    }
                    while (i != listSound.Count())
                    {
                        Console.WriteLine("album " + i + " " + listSound[i].path);
                        i++;
                    }
                }
            }
        }

        public void addInLibrary(Media newMed)
        {

        }

        public void addSound(String path)
        {
            Media sound = new Media();

            Mp3Tag tag = new Mp3Tag(path);
            Console.WriteLine("");
            sound.path = path;
            sound.name = tag.Title;
            sound.genre = tag.Genre;
            sound.artist = tag.Artist;
            sound.type = eMediaType.SOUND;
            listSound.Add(sound);
        }
        public void deleteSound(Media it)
        {
            listSound.Remove(it);
        }
        public void addVideo(String path)
        {
            Media video = new Media();

            video.name = path;

            listVideo.Add(video);
        }
        public void addPicture(String path)
        {
            Media picture = new Media();

            JPGTag tag = new JPGTag(path);
            Console.WriteLine("");
            picture.path = path;
            picture.artist = tag.ImageArtist;
            picture.copyright = tag.Copyright;
            picture.date = tag.ImageDate;
            picture.height = tag.ImageHeight;
            picture.width = tag.ImageWidth;
            picture.type = eMediaType.SOUND;

            ListPicture.Add(picture);
        }
    }
}
