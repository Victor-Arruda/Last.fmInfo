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
        List<AlbumChart> rssListo = new List<AlbumChart>();
        public User usr;
        public Login()
        {
            InitializeComponent();

            
        }

        private void Click_login(object sender, RoutedEventArgs e)
        {
            /*
            WebClient CheckUser = new WebClient();

            CheckUser.DownloadStringCompleted += CheckUser_DownloadStringCompleted;
            if (rssListo.Count() == 0)
            {
                MessageBox.Show("Invalid User!");
            }
            else
            {
                User u = new User() { UserName = TxtNome.Text };
                User.Create(u);
            }*/

            User u = new User() { UserName = TxtNome.Text };
            User.Create(u);
        }
        /*
        void CheckUser_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var rssList = from rss in XElement.Parse(e.Result).Descendants("album")
                          select new AlbumChart
                          {
                              Name = "Album: " + rss.Element("name").Value,
                              PlayCount = rss.Element("playcount").Value + " Scrobbles",
                              Artist = "Artista: " + rss.Element("artist").Element("name").Value
                          };
            foreach (AlbumChart a in rssList)
            {
                rssListo.Add(a);
            }
        }
         */
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (User.Get().Count > 0)
            {
                usr = User.Get()[0];
                Navigate("MainPage.xaml");
            }
        }
        private void Navigate(string pPage)
        {
            NavigationService.Navigate(new Uri(pPage, UriKind.Relative));
        }
    }
}