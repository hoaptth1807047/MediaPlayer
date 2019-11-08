using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UWPAssignment.Entity;
using UWPAssignment.Service;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPAssignment.Pages
{
    public sealed partial class ListSongPage : Page
    { 
        static ObservableCollection<Song> ListSong;
        static bool refresh = true; 
        bool running = false;
        private ISongService _songService;
        public ListSongPage()
        {
            Debug.WriteLine("Init list song");
            this.Loaded += CheckMemberCredential;
            this.InitializeComponent();
            this._songService = new SongService();
            LoadSongs();
        }

        private void CheckMemberCredential(object sender, RoutedEventArgs e)
        {
            {
                if (ProjectConfiguration.CurrentMemberCredential == null)
                {
                    this.Frame.Navigate(typeof(LoginPage));
                }
            }
        }


        private void LoadSongs()
        {
            if (refresh)
            {
                Debug.WriteLine("Fetching Song");
                var list = this._songService.GetAllSong(ProjectConfiguration.CurrentMemberCredential);
                ListSong = new ObservableCollection<Song>(list);
                refresh = false;
            }
            else
            {
                Debug.WriteLine("Have all song.");
            }

            ListViewSong.ItemsSource = ListSong;
        }

        private void UIElement_OnDoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var playIcon = sender as SymbolIcon;
            var currentSong = playIcon.Tag as Song;
            Debug.WriteLine(currentSong.name);
            MyMediaElement.Source = new Uri(currentSong.link);
            NowPlayingText.Text = "Now Playing: " + currentSong.name + " - " + currentSong.singer;
            MyMediaElement.Play();
            PlayAndPauseButton.Icon = new SymbolIcon(Symbol.Pause);
            running = true;
        }

        private void Play(object sender, RoutedEventArgs e)
        {
            if (running)
            {
                MyMediaElement.Play();
                PlayAndPauseButton.Icon = new SymbolIcon(Symbol.Pause);
                running = false;
            }
            else
            {
                MyMediaElement.Pause();
                PlayAndPauseButton.Icon = new SymbolIcon(Symbol.Play);
                running = true;
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
