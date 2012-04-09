using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;

namespace TestUserControl
{
    class JPGTag
    {
        const int WidthId = 256;
        const int LengthId = 257;
        const int TitleId = 270;
        const int ArtistId = 315;
        const int DateId = 36868;
        const int CopyrightId = 33432;
        public System.Drawing.Image Bmp { get; private set; }

        public string ImageWidth { get; private set; }
        public string ImageHeight { get; private set; }
        public string ImageTitle { get; private set; }
        public string ImageArtist { get; private set; }
        public string ImageDate { get; private set; }
        public string Copyright { get; private set; }

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
               switch (item.Id)
                {
                    case WidthId:
                        this.ImageWidth = item.Value[0].ToString();
                        break;
                    case LengthId:
                        this.ImageHeight = item.Value[0].ToString();
                        break;
                    case TitleId:
                        this.ImageTitle = Ascii.GetString(item.Value);
                        break;
                    case ArtistId:
                        this.ImageArtist = Ascii.GetString(item.Value);
                        break;
                    case DateId:
                        this.ImageDate = Ascii.GetString(item.Value);
                        break;
                    case CopyrightId:
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
