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

namespace Last.fmInfo
{
    public partial class ChangeUser : PhoneApplicationPage
    {
        User user;
        User usr;
        public ChangeUser()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<User> users = User.Get();
            LstUser.ItemsSource = users;
        }

        private void onSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            user = (sender as ListBox).SelectedItem as User;
            usr = user;
        }

        private void click_change(object sender, RoutedEventArgs e)
        {
            if (usr != null)
            {
                User.UpdateCurrentUser(usr);
            }
            else
            {
                MessageBox.Show("Please select a user!");
            }
        }
    }
}