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
using System.Diagnostics;
using GoogleAds;
using System.Windows.Threading;

namespace IccWorld2015
{
    public partial class MainPage : PhoneApplicationPage
    {
        //Collections Initialized
        ObservableCollection<LatestNew> obs_news = new ObservableCollection<LatestNew>();
        ObservableCollection<Photo> obs_photo = new ObservableCollection<Photo>();
        ObservableCollection<Movie> obs_videos = new ObservableCollection<Movie>();
        ObservableCollection<Fixture> obs_fixtures = new ObservableCollection<Fixture>();

        //Ad Obects Initialized
        public static InterstitialAd interstitialAd;
        public static AdView BannerAds;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            refreshAllClients();
            //RequestAd();

            //DispatcherTimer newTimer = new DispatcherTimer();
            //newTimer.Interval = TimeSpan.FromSeconds(11);
            //newTimer.Tick += OnTimerTick;
            //// starting the timer for loading Ad
            //newTimer.Start();

           

            lbx_News.SelectionChanged += lbx_News_SelectionChanged;
            lbx_videos.SelectionChanged += lbx_videos_SelectionChanged;
        }

        //DispacherTimer Event which Calls Ad after every 11 Sec
        private void OnTimerTick(object sender, EventArgs e)
        {
            try
            {
                interstitialAd = new InterstitialAd("ca-app-pub-6412899587206454/2368857725");
                // NOTE: You can edit the event handler to do something custom here. Once the
                // interstitial is received it can be shown whenever you want.
                interstitialAd.ReceivedAd += OnAdReceived;
                interstitialAd.FailedToReceiveAd += OnFailedToReceiveAd;
                interstitialAd.DismissingOverlay += OnDismissingOverlay;
                AdRequest adRequest = new AdRequest();
                adRequest.ForceTesting = false;
                interstitialAd.LoadAd(adRequest);
            }
            catch(Exception exc)
            {
            //Sometimes you need to catch Exceptions :p lol
            }
        }

      
       


        //GoogleAdMob
        public static void RequestAd()
        {
            interstitialAd = new InterstitialAd("ca-app-pub-6412899587206454/2368857725");
            // NOTE: You can edit the event handler to do something custom here. Once the
            // interstitial is received it can be shown whenever you want.
            interstitialAd.ReceivedAd += OnAdReceived;
            interstitialAd.FailedToReceiveAd += OnFailedToReceiveAd;
            interstitialAd.DismissingOverlay += OnDismissingOverlay;
            AdRequest adRequest = new AdRequest();
            adRequest.ForceTesting = false;
            interstitialAd.LoadAd(adRequest);
        }
      
        
        public static void OnAdReceived(object sender, AdEventArgs e)
        {
            Debug.WriteLine("Received interstitial successfully. Click 'Show Interstitial'.");

            interstitialAd.ShowAd();
        }

        public static void OnDismissingOverlay(object sender, AdEventArgs e)
        {
            Debug.WriteLine("Dismissing interstitial.");
        }

        public static void OnFailedToReceiveAd(object sender, AdErrorEventArgs errorCode)
        {
            Debug.WriteLine("Failed to receive interstitial with error " + errorCode.ErrorCode);
        }




        void lbx_videos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WebBrowserTask webBrowseTask = new WebBrowserTask();

            webBrowseTask.URL = (lbx_videos.SelectedItem as Movie).Video_url;
            webBrowseTask.Show();
           
        }


       
        public void refreshAllClients() 
        {
            progBar.IsIndeterminate = true;
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

            WebClient mainPage_webClient = new WebClient();
            mainPage_webClient.DownloadStringCompleted += mainPage_webClient_DownloadStringCompleted;
            mainPage_webClient.DownloadStringAsync(new Uri("http://hello987.azurewebsites.net/main.html"));
            progBar.IsIndeterminate = false;
        }

        void mainPage_webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var rootObject = JsonConvert.DeserializeObject<RootMain>(e.Result);
            tbl_Team1.Text = rootObject.Team1;
            tbl_Team2.Text = rootObject.Team2;
            tbl_Bats1Scr.Text = rootObject.Batsman1Scr;
            tbl_Bats2Scr.Text = rootObject.Batsman2Scr;
            tbl_Btsmn1.Text = rootObject.Batsman1;
            tbl_Btsmn2.Text = rootObject.Batsman2;
            tbl_Batting.Text = rootObject.Batting;
            tbl_Bowler1.Text = rootObject.Bowler1;
            tbl_Bowler2.Text = rootObject.Bowler2;
            tbl_Blwr1Scr.Text = rootObject.Bowler1Scr;
            tbl_Blwr2Scr.Text = rootObject.Bowler1Scr;
            tbl_Venue.Text = rootObject.Venue;
            tbl_Overs.Text = rootObject.Overs.ToString() + " ovrs";
            tbl_PlayersToWatch.Text = rootObject.PlayersToWatch;

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

        void bannerAd_FailedToReceiveAd(object sender, AdErrorEventArgs e)
        {
            throw new NotImplementedException();
        }
        //iconButton Refresh
        private void refresh_appbarIcon_Clicked(object sender, EventArgs e)
        {
            refreshAllClients();
           
        }

        private void VenueTileTapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.URL = "http://www.icc-cricket.com/cricket-world-cup/venues";
            webBrowserTask.Show();
        }

        private void PoolsTileTapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.URL = "http://www.icc-cricket.com/cricket-world-cup/teams";
            webBrowserTask.Show();
        }


        //CotextMenu Events for Fixtures
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (sender as MenuItem).DataContext as Fixture;
            ShareStatusTask shareStatusTask = new ShareStatusTask();
            shareStatusTask.Status = "" + selectedItem.Match_t1 + " vs " + selectedItem.Match_t2 +"\n"+selectedItem.Match_venue +"   on   "+selectedItem.Match_date+"\n\n"+"#IccWorldCup2015 @saadmeh";
            shareStatusTask.Show();
        }

        private void smsContextMenu(object sender, RoutedEventArgs e)
        {
            var selectedItem = (sender as MenuItem).DataContext as Fixture;
            SmsComposeTask smsComposeTask = new SmsComposeTask();
            smsComposeTask.Body = "" + selectedItem.Match_t1 + " vs " + selectedItem.Match_t2 + "\n" + selectedItem.Match_venue + "   on   " + selectedItem.Match_date + "\n\n" + "#IccWorldCup2015 @saadmeh";
            smsComposeTask.Show();
        }

        private void Context_Social_News(object sender, RoutedEventArgs e)
        {
            var selectedItem = (sender as MenuItem).DataContext as LatestNew;
            ShareStatusTask shareStatusTask = new ShareStatusTask();
            shareStatusTask.Status = "" + selectedItem.News_title + " \n" +selectedItem.News_link + "\n#IccWorldCup2015 @saadmeh";
            shareStatusTask.Show();
        }

        private void Context_Sms_News(object sender, RoutedEventArgs e)
        {
            var selectedItem = (sender as MenuItem).DataContext as LatestNew;
            SmsComposeTask smsComposeTask = new SmsComposeTask();
            smsComposeTask.Body = "" + selectedItem.News_title + " \n" + selectedItem.News_link + "\n#IccWorldCup2015 @saadmeh"; 
            smsComposeTask.Show();
        }

        private void Video_Social_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (sender as MenuItem).DataContext as Movie;
            ShareStatusTask shareStatusTask = new ShareStatusTask();
            shareStatusTask.Status = "" + selectedItem.Video_text + " \n" + selectedItem.Video_url + "\n#IccWorldCup2015 @saadmeh";
            shareStatusTask.Show();
        }

        private void Sms_Video_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (sender as MenuItem).DataContext as Movie;
            SmsComposeTask smsComposeTask = new SmsComposeTask();
            smsComposeTask.Body = "" + selectedItem.Video_text + " \n" + selectedItem.Video_url + "\n#IccWorldCup2015 @saadmeh";
            smsComposeTask.Show();
        }

        private void BuyTicketsTapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.URL = "http://tickets.cricketworldcup.com/tickets/tickets.aspx";
            webBrowserTask.Show();
        }

        private void ReviewtaskTapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MarketplaceReviewTask marketPlaceReviewTask = new MarketplaceReviewTask();
            marketPlaceReviewTask.Show();
        }

        private void MarketPlaceSearchTaskTapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MarketplaceSearchTask marketPlaceSearchTask = new MarketplaceSearchTask();
            marketPlaceSearchTask.SearchTerms = "Procesium ,LLC";
            marketPlaceSearchTask.Show();
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            MarketplaceReviewTask marketPlaceReviewTask = new MarketplaceReviewTask();
            marketPlaceReviewTask.Show();
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            emailComposeTask.To = "saad-mehmood@outlook.com";
            emailComposeTask.Subject = "ICC WorldCup |Suggestions";
            emailComposeTask.Show();
        }

  
    }
}