﻿#pragma checksum "C:\Users\victo_000\Last.fmInfo\Last.fmInfo\TracksChart.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "68810DBEE9369FCADA3F5D3B572EA128"
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
    
    
    public partial class TracksChart : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock charge;
        
        internal System.Windows.Controls.ListBox LstWeek;
        
        internal System.Windows.Controls.ListBox LstThreeMonth;
        
        internal System.Windows.Controls.ListBox LstSixMonth;
        
        internal System.Windows.Controls.ListBox LstTwelveMonth;
        
        internal System.Windows.Controls.ListBox LstTopTracks;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Last.fmInfo;component/TracksChart.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.charge = ((System.Windows.Controls.TextBlock)(this.FindName("charge")));
            this.LstWeek = ((System.Windows.Controls.ListBox)(this.FindName("LstWeek")));
            this.LstThreeMonth = ((System.Windows.Controls.ListBox)(this.FindName("LstThreeMonth")));
            this.LstSixMonth = ((System.Windows.Controls.ListBox)(this.FindName("LstSixMonth")));
            this.LstTwelveMonth = ((System.Windows.Controls.ListBox)(this.FindName("LstTwelveMonth")));
            this.LstTopTracks = ((System.Windows.Controls.ListBox)(this.FindName("LstTopTracks")));
        }
    }
}

