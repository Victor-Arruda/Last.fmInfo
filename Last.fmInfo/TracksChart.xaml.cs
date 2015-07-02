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
    public partial class TracksChart : PhoneApplicationPage
    {
        string username = User.GetCurrentUser()[0].UserName;
        private string apiKey = "099cb0a887d95cdcdccf153cb9293e4a";
        public TracksChart()
        {
            InitializeComponent();

            charge.Text = "Loading...";

            WebClient ChartWeek = new WebClient();
            ChartWeek.DownloadStringCompleted += ChartWeek_DownloadStringCompleted;
            ChartWeek.DownloadStringAsync(new Uri(@"http://ws.audioscrobbler.com/2.0/?method=user.gettoptracks&user=" + username + "&api_key=" + apiKey + "&period=7day"));

            WebClient ChartThreeMonth = new WebClient();
            ChartThreeMonth.DownloadStringCompleted += ChartThreeMonth_DownloadStringCompleted;
            ChartThreeMonth.DownloadStringAsync(new Uri(@"http://ws.audioscrobbler.com/2.0/?method=user.gettoptracks&user=" + username + "&api_key=" + apiKey + "&period=3month"));

            WebClient ChartSixMonth = new WebClient();
            ChartSixMonth.DownloadStringCompleted += ChartSixMonth_DownloadStringCompleted;
            ChartSixMonth.DownloadStringAsync(new Uri(@"http://ws.audioscrobbler.com/2.0/?method=user.gettoptracks&user=" + username + "&api_key=" + apiKey + "&period=6month"));

            WebClient ChartTwelveMonths = new WebClient();
            ChartTwelveMonths.DownloadStringCompleted += ChartTwelveMonths_DownloadStringCompleted;
            ChartTwelveMonths.DownloadStringAsync(new Uri(@"http://ws.audioscrobbler.com/2.0/?method=user.gettoptracks&user=" + username + "&api_key=" + apiKey + "&period=12month"));

            WebClient ChartTopTracks = new WebClient();
            ChartTopTracks.DownloadStringCompleted += ChartTopTracks_DownloadStringCompleted;
            ChartTopTracks.DownloadStringAsync(new Uri(@"http://ws.audioscrobbler.com/2.0/?method=user.gettoptracks&user="+username+"&api_key="+apiKey+"&period=overall"));
        }

        void ChartTopTracks_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                var rssTopTracks = from rss in XElement.Parse(e.Result).Descendants("track")
                                   select new TrackChart
                                   {
                                       Name = "Song: " + rss.Element("name").Value,
                                       Playcount = rss.Element("playcount").Value + " Scrobbles",
                                       Artist = "Artist: " + rss.Element("artist").Element("name").Value
                                   };
                LstTopTracks.ItemsSource = rssTopTracks;
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
                var rssTwelveMonths = from rss in XElement.Parse(e.Result).Descendants("track")
                                      select new TrackChart
                                      {
                                          Name = "Song: " + rss.Element("name").Value,
                                          Playcount = rss.Element("playcount").Value + " Scrobbles",
                                          Artist = "Artist: " + rss.Element("artist").Element("name").Value
                                      };
                LstTwelveMonth.ItemsSource = rssTwelveMonths;
            }
            catch
            {
                charge.Text = "";
            }
        }

        void ChartSixMonth_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                var rssSixMonths = from rss in XElement.Parse(e.Result).Descendants("track")
                                   select new TrackChart
                                   {
                                       Name = "Song: " + rss.Element("name").Value,
                                       Playcount = rss.Element("playcount").Value + " Scrobbles",
                                       Artist = "Artist: " + rss.Element("artist").Element("name").Value
                                   };
                LstSixMonth.ItemsSource = rssSixMonths;
            }
            catch
            {
                charge.Text = "";
            }
        }

        void ChartThreeMonth_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                var rssThreeMonths = from rss in XElement.Parse(e.Result).Descendants("track")
                                     select new TrackChart
                                     {
                                         Name = "Song: " + rss.Element("name").Value,
                                         Playcount = rss.Element("playcount").Value + " Scrobbles",
                                         Artist = "Artist: " + rss.Element("artist").Element("name").Value
                                     };
                LstThreeMonth.ItemsSource = rssThreeMonths;
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
                var rssWeek = from rss in XElement.Parse(e.Result).Descendants("track")
                              select new TrackChart
                              {
                                  Name = "Song: " + rss.Element("name").Value,
                                  Playcount = rss.Element("playcount").Value + " Scrobbles",
                                  Artist = "Artist: " + rss.Element("artist").Element("name").Value
                              };

                charge.Text = "";
                LstWeek.ItemsSource = rssWeek;
            }
            catch
            {
                MessageBox.Show("No Internet!");
                charge.Text = "";
            }
        }
    }
}