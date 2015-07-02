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
        string username = User.GetCurrentUser()[0].UserName;
        private string apiKey = "099cb0a887d95cdcdccf153cb9293e4a";
        public ArtistCharts()
        {
            InitializeComponent();

            charge.Text = "Loading...";

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
            try
            {
                var rssTopArtists = from rss in XElement.Parse(e.Result).Descendants("artist")
                                    select new ArtistChart
                                    {
                                        Name = rss.Element("name").Value,
                                        PlayCount = rss.Element("playcount").Value + " Scrobbles"
                                    };
                LstTopArtists.ItemsSource = rssTopArtists;
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
                var rssTwelveMonths = from rss in XElement.Parse(e.Result).Descendants("artist")
                                      select new ArtistChart
                                      {
                                          Name = rss.Element("name").Value,
                                          PlayCount = rss.Element("playcount").Value + " Scrobbles"
                                      };
                LstTwelveMonths.ItemsSource = rssTwelveMonths;
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
                var rssSixMonths = from rss in XElement.Parse(e.Result).Descendants("artist")
                                   select new ArtistChart
                                   {
                                       Name = rss.Element("name").Value,
                                       PlayCount = rss.Element("playcount").Value + " Scrobbles"
                                   };
                LstSixMonths.ItemsSource = rssSixMonths;
            }
            catch
            {
                charge.Text = "";
            }
        }

        void CharThreeMonths_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                var rssThreeMonths = from rss in XElement.Parse(e.Result).Descendants("artist")
                                     select new ArtistChart
                                     {
                                         Name = rss.Element("name").Value,
                                         PlayCount = rss.Element("playcount").Value + " Scrobbles"
                                     };
                LstThreeMonths.ItemsSource = rssThreeMonths;
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
                var rssWeek = from rss in XElement.Parse(e.Result).Descendants("artist")
                              select new ArtistChart
                              {
                                  Name = rss.Element("name").Value,
                                  PlayCount = rss.Element("playcount").Value + " Scrobbles"
                              };
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