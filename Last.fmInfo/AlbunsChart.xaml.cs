using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Xml.Linq;
using Last.fmInfo.Entity;

namespace Last.fmInfo
{
    public partial class AlbunsChart : PhoneApplicationPage
    {
        string username = User.GetCurrentUser()[0].UserName;
        private string apiKey = "099cb0a887d95cdcdccf153cb9293e4a";
        public AlbunsChart()
        {
            InitializeComponent();
            charge.Text = "Loading...";
            WebClient ChartWeek = new WebClient();

            ChartWeek.DownloadStringCompleted += ChartWeek_DownloadStringCompleted;

            ChartWeek.DownloadStringAsync(new Uri(@"http://ws.audioscrobbler.com/2.0/?method=user.gettopalbums&user="+username+"&api_key="+apiKey+"&period=7day"));

            

            WebClient ChartThreeMonths = new WebClient();

            ChartThreeMonths.DownloadStringCompleted += ChartThreeMonths_DownloadStringCompleted;

            ChartThreeMonths.DownloadStringAsync(new Uri(@"http://ws.audioscrobbler.com/2.0/?method=user.gettopalbums&user=" + username + "&api_key=" + apiKey + "&period=3month"));

            WebClient ChartSixMonths = new WebClient();

            ChartSixMonths.DownloadStringCompleted += ChartSixMonths_DownloadStringCompleted;

            ChartSixMonths.DownloadStringAsync(new Uri(@"http://ws.audioscrobbler.com/2.0/?method=user.gettopalbums&user=" + username + "&api_key=" + apiKey + "&period=6month"));

            WebClient ChartTwelveMonths = new WebClient();

            ChartTwelveMonths.DownloadStringCompleted += ChartTwelveMonths_DownloadStringCompleted;

            ChartTwelveMonths.DownloadStringAsync(new Uri(@"http://ws.audioscrobbler.com/2.0/?method=user.gettopalbums&user=" + username + "&api_key=" + apiKey + "&period=12month"));

            WebClient ChartTopAlbuns = new WebClient();
            ChartTopAlbuns.DownloadStringCompleted += ChartTopAlbuns_DownloadStringCompleted;

            ChartTopAlbuns.DownloadStringAsync(new Uri(@"http://ws.audioscrobbler.com/2.0/?method=user.gettopalbums&user=" + username + "&api_key=" + apiKey + "&period=overall"));
             
        }
        
        void ChartTopAlbuns_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                var rssTopAlbuns = from rss in XElement.Parse(e.Result).Descendants("album")
                                   select new AlbumChart
                                   {
                                       Name = "Album: " + rss.Element("name").Value,
                                       PlayCount = rss.Element("playcount").Value + " Scrobbles",
                                       Artist = "Artist: " + rss.Element("artist").Element("name").Value
                                   };
                LstTopAlbuns.ItemsSource = rssTopAlbuns;
            }
            catch
            {
                charge.Text = "";
            }
        }

        void ChartTwelveMonths_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                var rssTwelveMonths = from rss in XElement.Parse(e.Result).Descendants("album")
                                      select new AlbumChart
                                      {
                                          Name = "Album: " + rss.Element("name").Value,
                                          PlayCount = rss.Element("playcount").Value + " Scrobbles",
                                          Artist = "Artist: " + rss.Element("artist").Element("name").Value
                                      };
                Lst12month.ItemsSource = rssTwelveMonths;
            }
            catch
            {
                charge.Text = "";
            }
        }

        void ChartSixMonths_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                var rssSixMonths = from rss in XElement.Parse(e.Result).Descendants("album")
                                   select new AlbumChart
                                   {
                                       Name = "Album: " + rss.Element("name").Value,
                                       PlayCount = rss.Element("playcount").Value + " Scrobbles",
                                       Artist = "Artist: " + rss.Element("artist").Element("name").Value
                                   };
                Lst6month.ItemsSource = rssSixMonths;
            }
            catch
            {
                charge.Text = "";
            }
        }

        void ChartThreeMonths_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                var rssThreeMonths = from rss in XElement.Parse(e.Result).Descendants("album")
                                     select new AlbumChart
                                     {
                                         Name = "Album: " + rss.Element("name").Value,
                                         PlayCount = rss.Element("playcount").Value + " Scrobbles",
                                         Artist = "Artist: " + rss.Element("artist").Element("name").Value
                                     };
                Lst3month.ItemsSource = rssThreeMonths;
            }
            catch
            {
                charge.Text = "";
            }
        }
        
        void ChartWeek_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                var rssWeek = from rss in XElement.Parse(e.Result).Descendants("album")
                              select new AlbumChart
                              {
                                  Name = "Album: " + rss.Element("name").Value,
                                  PlayCount = rss.Element("playcount").Value + " Scrobbles",
                                  Artist = "Artist: " + rss.Element("artist").Element("name").Value
                              };
                charge.Text = "";
                LstWeek.ItemsSource = rssWeek;
            }
            catch
            {
                MessageBox.Show("No Internet Connection!");
            }
        }
    }
}