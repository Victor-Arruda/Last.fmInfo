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
    public partial class Login : PhoneApplicationPage
    {
        public bool valid;
        public User usr;
        public Login()
        {
            InitializeComponent();

            
        }

        private void Click_login(object sender, RoutedEventArgs e)
        {
            
            WebClient CheckUser = new WebClient();

            CheckUser.DownloadStringCompleted += CheckUser_DownloadStringCompleted;
            CheckUser.DownloadStringAsync(new Uri(@"http://ws.audioscrobbler.com/2.0/?method=user.gettopalbums&user="+ TxtNome.Text.ToString() +"&api_key=099cb0a887d95cdcdccf153cb9293e4a"));
            /*
            if (valid == false)
            {
                MessageBox.Show("Invalid User!");
            }
            else
            {
                User u = new User() { UserName = TxtNome.Text };
                User.Create(u);
            }
             */
            if (valid)
            {
                User u = new User() { UserName = TxtNome.Text, CurrentUser = 1 };
                User.Create(u);
                Navigate("/MainPage.xaml");
            }
            /*
            User u = new User() { UserName = TxtNome.Text };
            User.Create(u);
             */
        }
        
        void CheckUser_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                var rssList = from rss in XElement.Parse(e.Result).Descendants("album")
                              select new AlbumChart
                              {
                                  Name = "Album: " + rss.Element("name").Value,
                                  PlayCount = rss.Element("playcount").Value + " Scrobbles",
                                  Artist = "Artista: " + rss.Element("artist").Element("name").Value
                              };
                valid = true;
            }
            catch
            {
                MessageBox.Show("Invalid User!");
                valid = false;
            }
        }
         
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (User.Get().Count > 0)
            {
                usr = User.Get()[0];
                Navigate("/MainPage.xaml");
            }
        }
        private void Navigate(string pPage)
        {
            NavigationService.Navigate(new Uri(pPage, UriKind.Relative));
        }
    }
}