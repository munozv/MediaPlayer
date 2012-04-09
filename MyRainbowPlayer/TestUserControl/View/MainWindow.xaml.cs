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
using System.Windows.Shapes;
using Microsoft.Win32;

namespace TestUserControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            this.InitializeComponent();
            MainWindowViewModel vm = new MainWindowViewModel();
            this.DataContext = vm;
            vm.TimeViewModel.myMedElem = this.Timer.MedElem;
            this.Timer.DataContext = vm.TimeViewModel;
            this.Playlist.DataContext = vm.PlaylistViewModel;
            this.Playlist.Tablesheet.MouseDoubleClick += new MouseButtonEventHandler(vm.PlaylistViewModel.OnMouseDoubleClick2);

        }
    }
}