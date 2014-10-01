using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using IccWorld2015.Resources;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Microsoft.Phone.Tasks;

namespace IccWorld2015
{
    public partial class MainPage : PhoneApplicationPage
    {

        ObservableCollection<LatestNew> obs_news = new ObservableCollection<LatestNew>();
        ObservableCollection<Photo> obs_photo = new ObservableCollection<Photo>();
        ObservableCollection<Movie> obs_videos = new ObservableCollection<Movie>();
        ObservableCollection<Fixture> obs_fixtures = new ObservableCollection<Fixture>();


        // Constructor
        public MainPage()
        {
            InitializeComponent();
            refreshAllClients();
       

            lbx_News.SelectionChanged += lbx_News_SelectionChanged;
            lbx_videos.SelectionChanged += lbx_videos_SelectionChanged;
        }

        void lbx_videos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WebBrowserTask webBrowseTask = new WebBrowserTask();

            webBrowseTask.URL = (lbx_videos.SelectedItem as Movie).Video_url;
            webBrowseTask.Show();
           
        }


        public void refreshAllClients() 
        {
            WebClient webclient = new WebClient();
            webclient.DownloadStringCompleted += webclient_DownloadStringCompleted;
            webclient.DownloadStringAsync(new Uri("http://hello987.azurewebsites.net/News.html"));


            WebClient pic_WebClient = new WebClient();
            pic_WebClient.DownloadStringCompleted += pic_WebClient_DownloadStringCompleted;
            pic_WebClient.DownloadStringAsync(new Uri("http://hello987.azurewebsites.net/Images.html"));


            WebClient video_webClient = new WebClient();
            video_webClient.DownloadStringCompleted += video_webClient_DownloadStringCompleted;
            video_webClient.DownloadStringAsync(new Uri("http://hello987.azurewebsites.net/Videos.html"));
            
            WebClient fix_webClient = new WebClient();
            fix_webClient.DownloadStringCompleted += fix_webClient_DownloadStringCompleted;
            fix_webClient.DownloadStringAsync(new Uri("http://hello987.azurewebsites.net/Fixture.html"));

        }

        void fix_webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var rootObject = JsonConvert.DeserializeObject<RootFixtures>(e.Result);

            foreach (Fixture fixt in rootObject.Fixtures) 
            {
                obs_fixtures.Add(fixt);
            }

            lbx_fixtures.ItemsSource = obs_fixtures;
        }



        void video_webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var rootObject = JsonConvert.DeserializeObject<RootVideos>(e.Result);
            foreach (Movie mov in rootObject.Movie) 
            {
                obs_videos.Add(mov);

            }

            lbx_videos.ItemsSource = obs_videos;

        }

        void pic_WebClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var rootObject = JsonConvert.DeserializeObject<RootImages>(e.Result);

            foreach (Photo pht in rootObject.Photos) 
            {
                obs_photo.Add(pht);
            }

            lbx_photos.ItemsSource = obs_photo;

        }


       


        void lbx_News_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.URL = (lbx_News.SelectedItem as LatestNew).News_link;
            webBrowserTask.Show();
        }

        void webclient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var rootObject = JsonConvert.DeserializeObject<RootObject>(e.Result);

            foreach (LatestNew news_lat in rootObject.LatestNews) 
            {

                obs_news.Add(news_lat);
            }

            lbx_News.ItemsSource = obs_news;
        }

  
    }
}