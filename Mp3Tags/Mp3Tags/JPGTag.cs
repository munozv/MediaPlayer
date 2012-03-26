using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;

namespace Tags
{
    class JPGTag
    {
        const int WidthId       = 256;
        const int LengthId      = 257;
        const int TitleId       = 270;
        const int ArtistId      = 315;
        const int DateId        = 36868;
        const int CopyrightId   = 33432;
        public System.Drawing.Image Bmp {get; private set; }

        public string     ImageWidth { get; private set; }
        public string     ImageHeight { get; private set; }
        public string   ImageTitle { get; private set; }
        public string   ImageArtist { get; private set; }
        public string   ImageDate { get; private set; }
        public string   Copyright { get; private set; } 

        public JPGTag(System.Drawing.Bitmap bmp)
        {
            this.Init();
            this.Bmp = bmp;
        }

        public JPGTag(string file)
        {
            this.Init();
            this.Bmp = new System.Drawing.Bitmap(file);
        }

        public void Init()
        {
            this.Copyright = "";
            this.ImageWidth = "";
            this.ImageHeight = "";
            this.ImageTitle = "";
            this.ImageArtist = "";
            this.ImageDate = "";
        }

        public bool ReadData()
        {
            PropertyItem[] PropItems = this.Bmp.PropertyItems;
            Encoding Ascii = Encoding.ASCII;

            foreach (PropertyItem item in PropItems)
            {
                //Console.WriteLine("Id: " + item.Id);
                //if (item.Type == 0x1)
                //    Console.WriteLine(item.Value[0].ToString());
                //else if (item.Type == 0x02)
                //    Console.WriteLine(Ascii.GetString(item.Value));
                switch (item.Id)
                {
                    case WidthId:
                        //Console.WriteLine("Width here" + item.Value[0].ToString());
                        this.ImageWidth = item.Value[0].ToString();
                        break;
                    case LengthId:
                        //Console.WriteLine("Length here" + item.Value[0].ToString());
                        this.ImageHeight = item.Value[0].ToString();
                        break;
                    case TitleId:
                        //Console.WriteLine("Title here" + Ascii.GetString(item.Value));
                        this.ImageTitle = Ascii.GetString(item.Value);
                        break;
                    case ArtistId:
                        //Console.WriteLine("Artist here" + Ascii.GetString(item.Value));
                        this.ImageArtist = Ascii.GetString(item.Value);
                        break;
                    case DateId:
                        //Console.WriteLine("Date here" + Ascii.GetString(item.Value));
                        this.ImageDate = Ascii.GetString(item.Value);
                        break;
                    case CopyrightId:
                        //Console.WriteLine("Copyright here" + Ascii.GetString(item.Value));
                        this.Copyright = Ascii.GetString(item.Value);
                        break;
                    default:
                        break;
                }
            }
            return (true);
        }
    }
}
