using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Last.fmInfo.Entity;
using System.Xml.Linq;

namespace Last.fmInfo
{
    public partial class ArtistCharts : PhoneApplicationPage
    {
        string username = "VictorArruda_";
        private string apiKey = "099cb0a887d95cdcdccf153cb9293e4a";
        public ArtistCharts()
        {
            InitializeComponent();

            WebClient ChartWeek = new WebClient();

            ChartWeek.DownloadStringCompleted += ChartWeek_DownloadStringCompleted;

            ChartWeek.DownloadStringAsync(
                new Uri(@"http://ws.audioscrobbler.com/2.0/?method=user.gettopartists&user=" + username + "&api_key=" + apiKey + "&period=7day"));

            WebClient CharThreeMonths = new WebClient();

            CharThreeMonths.DownloadStringCompleted += CharThreeMonths_DownloadStringCompleted;

            CharThreeMonths.DownloadStringAsync(new Uri(@"http://ws.audioscrobbler.com/2.0/?method=user.gettopartists&user=" + username + "&api_key=" + apiKey + "&period=3month"));

            WebClient ChartSixMonths = new WebClient();

            ChartSixMonths.DownloadStringCompleted += ChartSixMonths_DownloadStringCompleted;

            ChartSixMonths.DownloadStringAsync(new Uri(@"http://ws.audioscrobbler.com/2.0/?method=user.gettopartists&user=" + username + "&api_key=" + apiKey + "&period=6month"));

            WebClient ChartTwelveMonths = new WebClient();

            ChartTwelveMonths.DownloadStringCompleted += ChartTwelveMonths_DownloadStringCompleted;

            ChartTwelveMonths.DownloadStringAsync(new Uri(@"http://ws.audioscrobbler.com/2.0/?method=user.gettopartists&user=" + username + "&api_key=" + apiKey + "&period=12month"));

            WebClient ChartTopArtists = new WebClient();

            ChartTopArtists.DownloadStringCompleted += ChartTopArtists_DownloadStringCompleted;

            ChartTopArtists.DownloadStringAsync(new Uri(@"http://ws.audioscrobbler.com/2.0/?method=user.gettopartists&user=" + username + "&api_key=" + apiKey + "&period=overall"));
        }

        void ChartTopArtists_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var rssTopArtists = from rss in XElement.Parse(e.Result).Descendants("artist")
                                  select new ArtistChart
                                  {
                                      Name = rss.Element("name").Value,
                                      PlayCount = rss.Element("playcount").Value
                                  };
            LstTopArtists.ItemsSource = rssTopArtists;
        }

        void ChartTwelveMonths_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var rssTwelveMonths = from rss in XElement.Parse(e.Result).Descendants("artist")
                                 select new ArtistChart
                                 {
                                     Name = rss.Element("name").Value,
                                     PlayCount = rss.Element("playcount").Value
                                 };
            LstTwelveMonths.ItemsSource = rssTwelveMonths;
        }

        void ChartSixMonths_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var rssSixMonths = from rss in XElement.Parse(e.Result).Descendants("artist")
                                 select new ArtistChart
                                 {
                                     Name = rss.Element("name").Value,
                                     PlayCount = rss.Element("playcount").Value
                                 };
            LstSixMonths.ItemsSource = rssSixMonths;
        }

        void CharThreeMonths_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var rssThreeMonths = from rss in XElement.Parse(e.Result).Descendants("artist")
                          select new ArtistChart
                          {
                              Name = rss.Element("name").Value,
                              PlayCount = rss.Element("playcount").Value
                          };
            LstThreeMonths.ItemsSource = rssThreeMonths;
        }

        void ChartWeek_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var rssWeek = from rss in XElement.Parse(e.Result).Descendants("artist")
                          select new ArtistChart
                          {
                              Name = rss.Element("name").Value,
                              PlayCount = rss.Element("playcount").Value
                          };
            LstWeek.ItemsSource = rssWeek;
        }
    }
}