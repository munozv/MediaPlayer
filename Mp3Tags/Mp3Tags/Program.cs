using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mp3Tags
{
    class Program
    {
        static private void PrintInfo(Tags tag)
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
            Tags.InitTags();
            Tags MusicTag = new Tags("../../audio.mp3");
            Tags MusicTag2 = new Tags("../../audio3.mp3");
            Tags MusicTag3 = new Tags("fileThatDontExist");


            if (MusicTag.ReadData())
                PrintInfo(MusicTag);
            else
                Console.WriteLine("Error With file " + MusicTag.FileName);
            if (MusicTag2.ReadData())
                PrintInfo(MusicTag2);
            else
                Console.WriteLine("Error With file " + MusicTag2.FileName);
            if (MusicTag3.ReadData())
                PrintInfo(MusicTag3);
            else
                Console.WriteLine("Error With file " + MusicTag3.FileName);
        }
    }
}
