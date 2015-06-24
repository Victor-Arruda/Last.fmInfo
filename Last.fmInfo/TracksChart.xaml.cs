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
        string username = "VictorArruda_";
        private string apiKey = "099cb0a887d95cdcdccf153cb9293e4a";
        public TracksChart()
        {
            InitializeComponent();

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
            var rssTopTracks = from rss in XElement.Parse(e.Result).Descendants("track")
                               select new TrackChart
                               {
                                   Name = "Song: " + rss.Element("name").Value,
                                   Playcount = rss.Element("playcount").Value + " Scrobbles",
                                   Artist = "Artist: " + rss.Element("artist").Element("name").Value
                               };
            LstTopTracks.ItemsSource = rssTopTracks;
        }

        void ChartTwelveMonths_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
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

        void ChartSixMonth_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
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

        void ChartThreeMonth_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
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

        void ChartWeek_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var rssWeek = from rss in XElement.Parse(e.Result).Descendants("track")
                                  select new TrackChart
                                  {
                                      Name = "Song: " + rss.Element("name").Value,
                                      Playcount = rss.Element("playcount").Value + " Scrobbles",
                                      Artist = "Artist: " + rss.Element("artist").Element("name").Value
                                  };

            
            LstWeek.ItemsSource = rssWeek;
        }
    }
}