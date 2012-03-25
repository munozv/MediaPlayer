using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestUserControl
{
	/// <summary>
	/// Interaction logic for ucTime.xaml
	/// </summary>
	public partial class ucTime : UserControl
	{
		public ucTime()
		{
            this.InitializeComponent();
           this.DataContext = new ucTimeModel();
		}
     /*   public ucTime(ucTimeModel m)
        {
            this.InitializeComponent();
            this.DataContext = m;
        }
        */
		//
		// Les bouttons Play/Pause/Stop/Shuffle/Repeat existe aussi
		// dans le controller ucMenuBar <----- Todo
		//

       

		private void ButtonPrevClick(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}

		private void ButtonPlayClick(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}

		private void ButtonStopClick(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}

		private void ButtonNextClick(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}

		private void ButtonRepeatClick(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}

		private void ButtonShuffleClick(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}
	}
}