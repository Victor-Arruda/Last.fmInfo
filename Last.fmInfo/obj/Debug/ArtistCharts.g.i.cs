﻿#pragma checksum "C:\Users\victo_000\Last.fmInfo\Last.fmInfo\ArtistCharts.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1B76C47F63DC8413B681E4A3AFD1E1F6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Last.fmInfo {
    
    
    public partial class ArtistCharts : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.ListBox LstWeek;
        
        internal System.Windows.Controls.TextBlock charge;
        
        internal System.Windows.Controls.ListBox LstThreeMonths;
        
        internal System.Windows.Controls.ListBox LstSixMonths;
        
        internal System.Windows.Controls.ListBox LstTwelveMonths;
        
        internal System.Windows.Controls.ListBox LstTopArtists;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Last.fmInfo;component/ArtistCharts.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.LstWeek = ((System.Windows.Controls.ListBox)(this.FindName("LstWeek")));
            this.charge = ((System.Windows.Controls.TextBlock)(this.FindName("charge")));
            this.LstThreeMonths = ((System.Windows.Controls.ListBox)(this.FindName("LstThreeMonths")));
            this.LstSixMonths = ((System.Windows.Controls.ListBox)(this.FindName("LstSixMonths")));
            this.LstTwelveMonths = ((System.Windows.Controls.ListBox)(this.FindName("LstTwelveMonths")));
            this.LstTopArtists = ((System.Windows.Controls.ListBox)(this.FindName("LstTopArtists")));
        }
    }
}

