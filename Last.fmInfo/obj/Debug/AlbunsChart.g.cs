﻿#pragma checksum "C:\Users\victo_000\Last.fmInfo\Last.fmInfo\AlbunsChart.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9ECE5339BBAAEBC4186D2A71883F481C"
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
    
    
    public partial class AlbunsChart : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.ListBox LstWeek;
        
        internal System.Windows.Controls.ListBox Lst3month;
        
        internal System.Windows.Controls.ListBox Lst6month;
        
        internal System.Windows.Controls.ListBox Lst12month;
        
        internal System.Windows.Controls.ListBox LstTopAlbuns;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Last.fmInfo;component/AlbunsChart.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.LstWeek = ((System.Windows.Controls.ListBox)(this.FindName("LstWeek")));
            this.Lst3month = ((System.Windows.Controls.ListBox)(this.FindName("Lst3month")));
            this.Lst6month = ((System.Windows.Controls.ListBox)(this.FindName("Lst6month")));
            this.Lst12month = ((System.Windows.Controls.ListBox)(this.FindName("Lst12month")));
            this.LstTopAlbuns = ((System.Windows.Controls.ListBox)(this.FindName("LstTopAlbuns")));
        }
    }
}
