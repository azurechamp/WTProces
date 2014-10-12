using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace IccWorld2015
{
    public partial class LargeTile : UserControl
    {
        public LargeTile()
        {
            InitializeComponent();
        }




        public string TileTitle
        {
            get { return (string)GetValue(TileTitleProperty); }
            set { SetValue(TileTitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TileTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TileTitleProperty =
            DependencyProperty.Register("TileTitle", typeof(string), typeof(LargeTile), null);

        

        public Brush BackGround
        {
            get { return (Brush)GetValue(BackGroundProperty); }
            set { SetValue(BackGroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackGround.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackGroundProperty =
            DependencyProperty.Register("BackGround", typeof(Brush), typeof(LargeTile),null);

        

        public ImageSource  ImageSrc1
        {
            get { return (ImageSource)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("Front Image", typeof(ImageSource), typeof(LargeTile), null);




      

        
        
    }
}
