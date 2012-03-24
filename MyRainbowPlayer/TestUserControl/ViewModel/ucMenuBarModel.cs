using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace TestUserControl
{
    class ucMenuBarModel : ViewModelBase
    {
        public MediaElement medelem;

        public ucMenuBarModel()
        {

        }
        public ucMenuBarModel(MediaElement med)
        {
            medelem = med;
        }
    }
}
