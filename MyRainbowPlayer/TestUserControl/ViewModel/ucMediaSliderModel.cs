using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace TestUserControl
{
    public class ucMediaSliderModel : ViewModelBase
    {
        public MediaElement medelem;

        public ucMediaSliderModel()
        {

        }

        public ucMediaSliderModel(MediaElement medel)
        {
            medelem = medel;
        }
    }
}
