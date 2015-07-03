using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Last.fmInfo.Resources;
using System.Xml.Linq;
using Last.fmInfo.Entity;

namespace Last.fmInfo
{
    public partial class MainPage : PhoneApplicationPage
    {
        public User user { get; set; }
        string username;

        
        private string apiKey = "099cb0a887d95cdcdccf153cb9293e4a";
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            if (User.Get().Count > 0)
            {
                username = User.GetCurrentUser()[0].UserName;

                WebClient RecentTracks = new WebClient();

                RecentTracks.DownloadStringCompleted += RecentTracks_DownloadStringCompleted;

                RecentTracks.DownloadStringAsync(new Uri(@"http://ws.audioscrobbler.com/2.0/?method=user.getrecenttracks&user=" + username + "&api_key=" + apiKey));
            }
            
            
        }

        void RecentTracks_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                var rssRecentTracks = from rss in XElement.Parse(e.Result).Descendants("track")
                                      select new TrackChart
                                      {
                                          Name = rss.Element("name").Value + " - " + rss.Element("artist").Value,
                                          Artist = rss.Element("artist").Value
                                      };
                LstRecentTracks.ItemsSource = rssRecentTracks;
            }
            catch
            {
                MessageBox.Show("No Internet!");
            }
        }

        

        private void btnAC_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ArtistCharts.xaml", UriKind.Relative));
        }

        private void btnALc_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AlbunsChart.xaml", UriKind.Relative));
        }

        private void btnTC_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/TracksChart.xaml", UriKind.Relative));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (User.Get().Count <= 0)
            {
                
                Navigate("/Login.xaml");
            }
        }

        private void Navigate(string pPage)
        {
            NavigationService.Navigate(new Uri(pPage, UriKind.Relative));
        }
        
        
         
    }
}