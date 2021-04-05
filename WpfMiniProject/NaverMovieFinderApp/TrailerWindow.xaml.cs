using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using MahApps.Metro.Controls;
using NaverMovieFinderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NaverMovieFinderApp
{
    /// <summary>
    /// TrailerWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TrailerWindow : MetroWindow
    {
        List<YoutubeItem> youtubes; //유투브 Api 검색 결과 담을 리스트
        public TrailerWindow()
        {
            InitializeComponent();
        }

        public TrailerWindow(string movieName) : this()
        {
            LblMovieName.Content = $"{movieName} 예고편";
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //유투브 Api로 검색
            //MessageBox.Show("유투브 검색!");
            ProSearchYoutubeApi();
        }

        private async void ProSearchYoutubeApi()
        {
            await LoadDataCollection();
        }

        private async Task LoadDataCollection()
        {
            var youtubeService = new YouTubeService(
            new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyCW_u-5D9iOtXD2YYw5d2j9zaHPhFBjGCY",
                ApplicationName = this.GetType().ToString()
            });

            //TODO : 
        }
    }
}
