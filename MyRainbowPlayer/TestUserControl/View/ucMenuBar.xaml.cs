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
using Microsoft.Win32;

namespace TestUserControl
{
	/// <summary>
	/// Interaction logic for ucMenuBar.xaml
	/// </summary>
	public partial class ucMenuBar : UserControl
	{
		public ucMenuBar()
		{
			this.InitializeComponent();
		}

		private void CreateaPlaylist(object sender, System.Windows.RoutedEventArgs e)
		{
			//Todo, jai fait un code vite fait mais faut voir si playlist
			//existe pas deja etc
			    Window window = new Window 
   			    {
                Title = "Create a New Playlist",
                Content = new ucNewPlaylist(),
				Height = 200,
				Width = 435
                // ResizeMode = NoResize defuck ?
				};
				var bc = new BrushConverter();
				window.Background = (Brush)bc.ConvertFrom("#FF9EDBF8");
                window.ShowDialog();
		}

		private void OpenNewFile(object sender, System.Windows.RoutedEventArgs e)
		{
            // TODO: Add event handler implementation here.
		}

		private void PlayPauseClick(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}

		private void StopButtonClick(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}

		private void ShuffleButtonClick(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}

		private void LoopButtonClick(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}

		private void AboutMLPClick(object sender, System.Windows.RoutedEventArgs e)
		{
				Window window = new Window 
   			    {
                Title = "About My Little (Pony) Player",
                Content = new AboutUs(),
				Height = 400,
				Width = 435
                // ResizeMode = NoResize defuck ?
				};
				var bc = new BrushConverter();
				window.Background = (Brush)bc.ConvertFrom("#FF9EDBF8");
                window.ShowDialog();
		}
	}
}