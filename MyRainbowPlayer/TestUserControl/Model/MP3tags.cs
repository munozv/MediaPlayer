using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TestUserControl
{
    class Mp3Tag
    {
        public const int TagsDataSize = 128;
        public const int MagicSize = 3;
        public const int StringDataSize = 30;
        public const int StringYearSize = 4;
        public const int TitleOffset = 3;
        public const int ArtistOffset = 33;
        public const int AlbumOffset = 63;
        public const int YearOffset = 93;
        public const int CommentOffset = 97;
        public const int SeparatorV1 = 125;
        public const int TrackOffset = 126;
        public const int GenreOffset = 127;

        public bool GoodFormat { get; private set; }
        public string FileName { get; private set; }
        public string FileData { get; private set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Year { get; set; }
        public string Comment { get; set; }
        public string Genre { get; set; }
        public int GenreId { get; set; }
        public int Track { get; set; }

        static private Dictionary<int, string> Dic;

        static public void InitTags()
        {
            Dic = new Dictionary<int, string>();

            Dic.Add(0, "Blues");
            Dic.Add(1, "Classic Rock");
            Dic.Add(2, "Country");
            Dic.Add(3, "Dance");
            Dic.Add(4, "Disco");
            Dic.Add(5, "Funk");
            Dic.Add(6, "Grunge");
            Dic.Add(7, "Hip-Hop");
            Dic.Add(8, "Jazz");
            Dic.Add(9, "Metal");
            Dic.Add(10, "New Age");
            Dic.Add(11, "Oldies");
            Dic.Add(12, "Other");
            Dic.Add(13, "Pop");
            Dic.Add(14, "R'n'B");
            Dic.Add(15, "Rap");
            Dic.Add(16, "Reggae");
            Dic.Add(17, "Rock");
            Dic.Add(18, "Techno");
            Dic.Add(19, "Industrial");
            Dic.Add(20, "Alternative");
            Dic.Add(21, "Ska");
            Dic.Add(22, "Death Metal");
            Dic.Add(23, "Pranks");
            Dic.Add(24, "Film Score");
            Dic.Add(25, "Euro-Techno");
            Dic.Add(26, "Ambient");
            Dic.Add(27, "Trip-Hop");
            Dic.Add(28, "Vocal");
            Dic.Add(29, "Jazz-Funk");
            Dic.Add(30, "Fusion");
            Dic.Add(31, "Trance");
            Dic.Add(32, "Classical");
            Dic.Add(33, "Instrumental");
            Dic.Add(34, "Acid");
            Dic.Add(35, "House");
            Dic.Add(36, "Video Game");
            Dic.Add(37, "Sample");
            Dic.Add(38, "Gospel");
            Dic.Add(39, "Noise");
            Dic.Add(40, "Alternative");
            Dic.Add(41, "Bass");
            Dic.Add(42, "Soul");
            Dic.Add(43, "Punk");
            Dic.Add(44, "Space");
            Dic.Add(45, "Meditative");
            Dic.Add(46, "Instrumental Pop");
            Dic.Add(47, "Instrumental Rock");
            Dic.Add(48, "Ethnic");
            Dic.Add(49, "Gothic");
            Dic.Add(50, "Darkwave");
            Dic.Add(51, "Techno-Industrial");
            Dic.Add(52, "Electro");
            Dic.Add(53, "Pop-Folk");
            Dic.Add(54, "Eurodance");
            Dic.Add(55, "Dream");
            Dic.Add(56, "Southern Rock");
            Dic.Add(57, "Comedy");
            Dic.Add(58, "Cult");
            Dic.Add(59, "Gangsta");
            Dic.Add(60, "Hit");
            Dic.Add(61, "Christian Rap");
            Dic.Add(62, "Pop-Funk");
            Dic.Add(63, "Jungle");
            Dic.Add(64, "Amerindian");
            Dic.Add(65, "Cabaret");
            Dic.Add(66, "New Wave");
            Dic.Add(67, "Psyko");
            Dic.Add(68, "Rave");
            Dic.Add(69, "Showtunes");
            Dic.Add(70, "BO");
            Dic.Add(71, "Lo-Fi");
            Dic.Add(72, "Tribal");
            Dic.Add(73, "Acid Punk");
            Dic.Add(74, "Acid Jazz");
            Dic.Add(75, "Polka");
            Dic.Add(76, "Retro");
            Dic.Add(77, "Theater");
            Dic.Add(78, "Rock & Roll");
            Dic.Add(79, "Hard Rock");
            Dic.Add(80, "Folk");
            Dic.Add(81, "Folk Rock");
            Dic.Add(82, "American Folk");
            Dic.Add(83, "Swing");
            Dic.Add(84, "Fast Fusion");
            Dic.Add(85, "Bebop");
            Dic.Add(86, "Latino");
            Dic.Add(87, "Revival");
            Dic.Add(88, "Celtic");
            Dic.Add(89, "Bluegrass");
            Dic.Add(90, "Avangarde");
            Dic.Add(91, "Gothic Rock");
            Dic.Add(92, "Progressive");
            Dic.Add(93, "Psyko");
            Dic.Add(94, "Symphonic Rock");
            Dic.Add(95, "Slow Rock");
            Dic.Add(96, "Big Band");
            Dic.Add(97, "Chorus");
            Dic.Add(98, "Easy Listening");
            Dic.Add(99, "Acoustic");
            Dic.Add(100, "Humour");
            Dic.Add(101, "Speech");
            Dic.Add(102, "Song");
            Dic.Add(103, "Opera");
            Dic.Add(104, "Bedroom");
            Dic.Add(105, "Sonate");
            Dic.Add(106, "Symphony");
            Dic.Add(107, "Booty Bass");
            Dic.Add(108, "Primus");
            Dic.Add(109, "Porn Groove");
            Dic.Add(110, "Satire");
            Dic.Add(111, "Slow Jam");
            Dic.Add(112, "Club");
            Dic.Add(113, "Tango");
            Dic.Add(114, "Samba");
            Dic.Add(115, "Folk");
            Dic.Add(116, "Balade");
            Dic.Add(117, "Power Ballad");
            Dic.Add(118, "Rythmic soul");
            Dic.Add(119, "Freestyle");
            Dic.Add(120, "Duet");
            Dic.Add(121, "Punk Rock");
            Dic.Add(122, "Drum Solo");
            Dic.Add(123, "A Cappella");
            Dic.Add(124, "Euro-House");
            Dic.Add(125, "DanceHall");
            Dic.Add(126, "Goa");
            Dic.Add(127, "Drum and Bass");
            Dic.Add(128, "Club House");
            Dic.Add(129, "Hardcore");
            Dic.Add(130, "Terror");
            Dic.Add(131, "Indie");
            Dic.Add(132, "BritPop");
            Dic.Add(133, "Negerpunk");
            Dic.Add(134, "Polsk Punk");
            Dic.Add(135, "Beat");
            Dic.Add(136, "Gangsta Christian Rap");
            Dic.Add(137, "Heavy Metal");
            Dic.Add(138, "Black Metal");
            Dic.Add(139, "Crossover");
            Dic.Add(140, "Christian Music");
            Dic.Add(141, "Christian Rock");
            Dic.Add(142, "Merangue");
            Dic.Add(143, "Salsa");
            Dic.Add(144, "Trash Metal");
            Dic.Add(145, "Anime");
            Dic.Add(146, "JPop");
            Dic.Add(147, "Synthpop");
        }

        public Mp3Tag(string file)
        {
            this.Init();
            this.FileName = file;
        }

        public Mp3Tag()
        {
            this.Init();
        }

        public void Init()
        {
            this.FileData = "";
            this.FileName = "";
            this.Title = "";
            this.Album = "";
            this.Artist = "";
            this.Year = "";
            this.Comment = "";
            this.Genre = "";
            this.Track = 0;
            this.GoodFormat = false;
        }

        private bool GoodMagic(string magic)
        {
            if (magic == "TAG")
                return (true);
            return (false);
        }

        static public string getGenre(int Id)
        {
            if (Dic.ContainsKey(Id))
            {
                return (Dic[Id]);
            }
            return ("undefined");
        }

        public bool ReadData()
        {
            if (FileName == "")
            {
                return false;
            }
            FileStream fs;
            try
            {
                fs = new FileStream(this.FileName, FileMode.Open);
                byte[] Buffer = new byte[TagsDataSize];
                fs.Seek(-128, SeekOrigin.End);
                int nb;
                nb = fs.Read(Buffer, 0, TagsDataSize);
                if (nb != TagsDataSize)
                    return (false);
                fs.Close();
                Encoding ascii = new ASCIIEncoding();
                this.FileData = ascii.GetString(Buffer);
                if (GoodMagic(this.FileData.Substring(0, MagicSize)) == true)
                {
                    this.GoodFormat = true;
                    this.Title = this.FileData.Substring(TitleOffset, StringDataSize).Trim();
                    this.Artist = this.FileData.Substring(ArtistOffset, StringDataSize).Trim();
                    this.Album = this.FileData.Substring(AlbumOffset, StringDataSize).Trim();
                    this.Year = this.FileData.Substring(YearOffset, StringYearSize).Trim();
                    this.GenreId = this.FileData[GenreOffset];
                    if (this.FileData[SeparatorV1] == 0)
                        this.Track = this.FileData[TrackOffset];
                    else
                        this.Track = 0;
                    this.Comment = this.FileData.Substring(CommentOffset, StringDataSize).Trim();
                    this.Genre = getGenre(this.GenreId);
                    return (true);
                }
                return (false);
            }
            catch (FileNotFoundException)
            {
                return (false);
            }
        }
    }
}
