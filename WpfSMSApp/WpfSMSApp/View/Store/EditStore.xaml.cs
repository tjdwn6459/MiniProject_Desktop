using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MahApps.Metro.Controls.Dialogs;

namespace WpfSMSApp.View.Store
{
    /// <summary>
    /// MyAccount.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EditStore : Page
    {
        private int StoreID { get; set; }
        private Model.Store CurrentStore { get; set; }
        public EditStore()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 추가생성자.storeList 에서 storeId를 받아옴
        /// </summary>
        /// <param name="storeId"></param>
        public EditStore(int storeId) :this()
        {
            StoreID = storeId;
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
                LblStoreName.Visibility = LblStoreLocation.Visibility =
                    Visibility.Hidden;
                TxtStoreID.Text = LblStoreName.Text = "";

            try
            {
                //store테이블에서 내용 읽음
                var store = Logic.DataAccess.GetStores().Where(s => s.StoreID.Equals(StoreID)).First();
                TxtStoreID.Text = store.StoreID.ToString();
                TxtStoreName.Text = store.StoreName;
                TxtStoreLocation.Text = store.StoreLocation;
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"EditStore.xaml.cs  Page_Loaded예외발생 : {ex}");
                Commons.ShowMessageAsync("예외", $"예외발생 : {ex}");
            }
        }

        private void BtnEditMyAccount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }


        bool IsValid = true; //지역변수 --> 전역변수

        public bool IsValidInput()
        {
          

            if (string.IsNullOrEmpty(TxtStoreName.Text))
            {
                LblStoreName.Visibility = Visibility.Visible;
                LblStoreName.Text = "창고명을 입력하세요.";
                IsValid = false;
            }
            else
            {
                var cnt = Logic.DataAccess.GetStores().Where(u => u.StoreName.Equals(TxtStoreName.Text)).Count();
                if (cnt > 0)
                {
                    LblStoreName.Visibility = Visibility.Visible;
                    LblStoreName.Text = "중복된 사번이 존재합니다.";
                    IsValid = false;
                }
            }

            if (string.IsNullOrEmpty(TxtStoreLocation.Text))
            {
                LblStoreLocation.Visibility = Visibility.Visible;
                LblStoreLocation.Text = "창고위치를 입력하세요.";
                IsValid = false;
            }


            return IsValid;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true; //입력한 갑이 모두 만족하는지 판별하는 플래그

            LblStoreName.Visibility = LblStoreLocation.Visibility =
                 Visibility.Hidden;
            var store = new Model.Store();
            isValid = IsValidInput(); //유효성 체크(필수)


                if (isValid)
                {
                // MessageBox.Show("DB 입력처리");
                CurrentStore.StoreName = TxtStoreName.Text;
                CurrentStore.StoreLocation = TxtStoreLocation.Text;

                    
                    try
                    {

                        var result = Logic.DataAccess.SetStore(CurrentStore);
                        if (result == 0)
                        {

                            //수정안댐
                            Commons.LOGGER.Error($"AddStore.xaml.cs 창고정보 저장오류 발생");
                            Commons.ShowMessageAsync("오류", "저장시 오류가 발생했습니다.");
                            return;
                        }
                        else
                        {
                        NavigationService.Navigate(new StoreList());
                        }
                    }
                    catch (Exception ex)
                    {
                        Commons.LOGGER.Error($"예외발생 : {ex}");
                    }

                }
            
        }

        private void TxtStoreName_LostFocus(object sender, RoutedEventArgs e)
        {
            IsValidInput();
        }

        private void TxtStoreLocation_LostFocus(object sender, RoutedEventArgs e)
        {
            IsValidInput();
        }
    }
}
