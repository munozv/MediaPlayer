using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tags
{
    class Program
    {
        static private void PrintInfo(JPGTag tag)
        {
            Console.WriteLine("========= Picture =========");
            Console.WriteLine("Width:     " + tag.ImageWidth);
            Console.WriteLine("Height:    " + tag.ImageHeight);
            Console.WriteLine("Artist:    " + tag.ImageArtist);
            Console.WriteLine("Title:     " + tag.ImageTitle);
            Console.WriteLine("Copyright: " + tag.Copyright);
            Console.WriteLine("Date:      " + tag.ImageDate);
        }

        static private void PrintInfo(Mp3Tag tag)
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
        }

        static void Main(string[] args)
        {
            /*
             *   MUSIC 
             */
            Mp3Tag.InitTags();
            Mp3Tag MusicTag = new Mp3Tag("../../audio.mp3");
            Mp3Tag MusicTag2 = new Mp3Tag("../../audio3.mp3");

            if (MusicTag.ReadData())
                PrintInfo(MusicTag);
            if (MusicTag2.ReadData())
                PrintInfo(MusicTag2);
            /*
             *   PICTURE
             */
            JPGTag PicTag = new JPGTag("../../picture.jpg");
            JPGTag PicTag2 = new JPGTag("../../lol.jpg");

            if (PicTag.ReadData())
                PrintInfo(PicTag);
            if (PicTag.ReadData())
                PrintInfo(PicTag2);
        }
    }
}
