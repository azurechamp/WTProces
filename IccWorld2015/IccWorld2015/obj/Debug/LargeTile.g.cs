﻿#pragma checksum "C:\Users\Saad-Mehmood1\Documents\GitHub\WTProces\IccWorld2015\IccWorld2015\LargeTile.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4DC3165567DE273F98D12A6BEB8CBA42"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace IccWorld2015 {
    
    
    public partial class LargeTile : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.UserControl userControl;
        
        internal System.Windows.Media.Animation.Storyboard MAIANIMATION;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Image FrontImage;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/IccWorld2015;component/LargeTile.xaml", System.UriKind.Relative));
            this.userControl = ((System.Windows.Controls.UserControl)(this.FindName("userControl")));
            this.MAIANIMATION = ((System.Windows.Media.Animation.Storyboard)(this.FindName("MAIANIMATION")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.FrontImage = ((System.Windows.Controls.Image)(this.FindName("FrontImage")));
        }
    }
}

