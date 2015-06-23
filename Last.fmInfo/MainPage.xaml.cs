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
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            
        }

        

        private void btnAC_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ArtistCharts.xaml", UriKind.Relative));
        }
    }
}