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
    public partial class Profile : PhoneApplicationPage
    {
        string username;
        User User;
        private string apiKey = "099cb0a887d95cdcdccf153cb9293e4a";
        public Profile()
        {
            InitializeComponent();
            loading.Text = "Loading...";
            username = User.GetCurrentUser()[0].UserName;

            WebClient user = new WebClient();

            user.DownloadStringCompleted += user_DownloadStringCompleted;

            user.DownloadStringAsync(new Uri(@"http://ws.audioscrobbler.com/2.0/?method=user.getinfo&user="+ username +"&api_key="+ apiKey));
        }

        void user_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                var rssUser = from rss in XElement.Parse(e.Result).Descendants("user")
                                      select new User
                                      {
                                          UserName = "Name: " + rss.Element("name").Value,
                                          RealName = "Real name: " + rss.Element("realname").Value,
                                          Country = "Country: " + rss.Element("country").Value,
                                          Age = "Age: " + rss.Element("age").Value,
                                          PlayCount = "Playcount: " + rss.Element("playcount").Value
                                      };
                LstUser.ItemsSource = rssUser;
                loading.Text = "";
            }
            catch
            {
                loading.Text = "";
                MessageBox.Show("No Internet!");
            }
        }

        private void click_ch(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ChangeUser.xaml", UriKind.Relative));
        }
    }
}