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

            TagLib.File tagfile = TagLib.File.Create(path);

            TagLib.Properties p = tagfile.Properties;
            TagLib.MediaTypes mt = p.MediaTypes;
            media.artist = tagfile.Tag.FirstArtist;
            media.album = tagfile.Tag.Album;
            media.name = tagfile.Tag.Title;
            media.path = path;
            media.genre = tagfile.Tag.FirstGenre;
            media.copyright = tagfile.Tag.Copyright;

            if (mt == TagLib.MediaTypes.Audio)
                media.type = eMediaType.SOUND;
            else if (mt == TagLib.MediaTypes.Photo)
                media.type = eMediaType.PICTURE;
            else if (mt == TagLib.MediaTypes.Video)
                media.type = eMediaType.VIDEO;
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

        public void SaveB()
        {
            savemedia("songs.xml", listSound);
            savemedia("pictures.xml", ListPicture);
            savemedia("videos.xml", ListVideo);
        }

        public void savemedia(String s, List<Media> list)
        {
            XmlSerializer xse = new XmlSerializer(typeof(List<Media>));
            FileStream fs = new FileStream(s, FileMode.Create);

            Console.WriteLine("count is " + list.Count);
            xse.Serialize(fs, list);
        }

        public void LoadB()
        {
            ListSound = Loadmedia("songs.xml", ListSound);
            ListPicture = Loadmedia("pictures.xml", ListPicture);
            ListVideo = Loadmedia("videos.xml", ListVideo);
         }

        public List<Media> Loadmedia(String s, List<Media> list)
        {
            XmlSerializer xse = new XmlSerializer(typeof(List<Media>));
            string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string filePath = Path.Combine(directory, s);

            if (File.Exists(filePath) == true)
            {
                FileStream fs = new FileStream(s, FileMode.Open);
                if (fs.CanRead == true)
                {
                    try
                    {
                        list = (List<Media>)xse.Deserialize(fs);
                        return (list);
                    }
                    catch (Exception e)
                    {                        

                    }
                }
            }
            return(new List<Media>());
        }



        public void addInLibrary(Media newMed)
        {

        }

        public void addSound(String path)
        {
            Media media = new Media();

            var stuff = from entry in listSound
                        where (entry.path == path)
                        select entry;

            foreach (Media med in stuff)
            {
                return;
            }
            TagLib.File tagfile = TagLib.File.Create(path);

            TagLib.Properties p = tagfile.Properties;
            TagLib.MediaTypes mt = p.MediaTypes;
            media.artist = tagfile.Tag.FirstArtist;
            media.album = tagfile.Tag.Album;
            media.name = tagfile.Tag.Title;
            media.path = path;
            media.genre = tagfile.Tag.FirstGenre;
            media.copyright = tagfile.Tag.Copyright;

            listSound.Add(media);
        }
        public void deleteSound(Media it)
        {
            listSound.Remove(it);
        }
        public void addVideo(String path)
        {
            Media media = new Media();

            var stuff = from entry in listVideo
                        where (entry.path == path)
                        select entry;

            foreach (Media med in stuff)
            {
                return;
            }

            TagLib.File tagfile = TagLib.File.Create(path);

            TagLib.Properties p = tagfile.Properties;
            TagLib.MediaTypes mt = p.MediaTypes;
            media.artist = tagfile.Tag.FirstArtist;
            media.album = tagfile.Tag.Album;
            media.name = tagfile.Tag.Title;
            media.path = path;
            media.genre = tagfile.Tag.FirstGenre;
            media.copyright = tagfile.Tag.Copyright;

            listVideo.Add(media);
        }
        public void addPicture(String path)
        {
            Media media = new Media();

            var stuff = from entry in listVideo
                        where (entry.path == path)
                        select entry;

            foreach (Media med in stuff)
            {
                return;
            }

            TagLib.File tagfile = TagLib.File.Create(path);

            TagLib.Properties p = tagfile.Properties;
            TagLib.MediaTypes mt = p.MediaTypes;
            media.artist = tagfile.Tag.FirstArtist;
            media.album = tagfile.Tag.Album;
            media.name = tagfile.Tag.Title;
            media.path = path;
            media.genre = tagfile.Tag.FirstGenre;
            media.copyright = tagfile.Tag.Copyright;

            ListPicture.Add(media);
        }
    }
}
