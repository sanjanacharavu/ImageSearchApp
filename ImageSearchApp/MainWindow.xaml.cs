using FlickrNet;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ImageSearchApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private const string ApiKey = "507f934477929499ba1dc73b7b592505";
        //private const string ApiSecret = "507f934477929499ba1dc73b7b592505";
        //private PhotoCollection photos;
        //public List<Photo> imageSourceList;
        private int pageNumber = 1;
        private string keyWord = string.Empty;
        public List<Photo> photoList;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Search button click method for validating user input and call FlickerApi to fetch and load images 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                errormessage.Text = "";
                if (textBoxImageTag.Text.Length == 0)
                {
                    errormessage.Text = "Enter valid keyword to search";
                    ImageDisplay.ItemsSource = null;
                    DetailsImg.Source = null;
                    DetailsText.Text = "";
                    loadMoreText.Visibility = Visibility.Hidden;
                }
                else
                {
                    keyWord = textBoxImageTag.Text;
                    pageNumber = 1;
                    //imageSourceList = new List<Photo>();
                    photoList = new List<Photo>();
                    FlickrServiceUtility flickrService = new FlickrServiceUtility();
                    flickrService.CallFlickrApi(keyWord, pageNumber,ref photoList);
                    // CallFlickrApi(ApiKey, ApiSecret, keyWord, pageNumber);
                    ImageDisplay.ItemsSource = null;
                    ImageDisplay.ItemsSource = photoList;

                    if (photoList.Count > 1)
                        loadMoreText.Visibility = Visibility.Visible;
                    else
                    {
                        errormessage.Text = "No image found for this keyword !!";
                        loadMoreText.Visibility = Visibility.Hidden;
                        DetailsImg.Source = null;
                        DetailsText.Text = "";
                    }

                }
            }
            catch (Exception ex)
            {
                errormessage.Text = ex.Message;
            }
        }

        /// <summary>
        /// Display a larger image with title on clicking any grid images 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Detail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                errormessage.Text = "";
                //DetailsGrid.ItemsSource = ((Button)sender).Tag.ToString();
                Photo photo = (Photo)((Button)sender).Tag;
                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri(photo.LargeUrl);
                logo.EndInit();
                DetailsImg.Source = logo;
                DetailsText.Text = photo.Title;
            }
            catch (Exception ex)
            {

                errormessage.Text = ex.Message;
            }

        }

        /// <summary>
        /// On clicking Load more hyperlink next page images will be fetched and displayed 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LoadMoreImages_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pageNumber++;
                FlickrServiceUtility flickrService = new FlickrServiceUtility();
                flickrService.CallFlickrApi(keyWord, pageNumber, ref photoList);
                // CallFlickrApi(ApiKey, ApiSecret, keyWord, pageNumber);
                ImageDisplay.ItemsSource = null;
                ImageDisplay.ItemsSource = photoList;
            }
            catch (Exception ex)
            {
                errormessage.Text = ex.Message;
            }

        }

        /// <summary>
        /// Method to call Flickr api with valid ApiKey, ApiSecret and search parameters like keyword, pagenumber etc.
        /// </summary>
        //public void CallFlickrApi(string apiKey, string apiSecret, string keyString, int pageNum)
        //{
        //    try
        //    {
        //        //Flickr flickrObj = new Flickr();
        //        //flickrObj.ApiKey = apiKey;
        //        //flickrObj.ApiSecret = apiSecret;
        //        //var options = new PhotoSearchOptions { Tags = keyString, Page = pageNum, PerPage=20 };
        //        //photos = flickrObj.PhotosSearch(options);

        //        ////imageSourceList = new List<Photo>();

        //        //foreach (Photo photo in photos)
        //        //{
        //        //    imageSourceList.Add(photo);
        //        //}

        //        ImageDisplay.ItemsSource = null;
        //        ImageDisplay.ItemsSource = imageSourceList;
        //    }
        //    catch (Exception ex)
        //    {
        //        errormessage.Text = ex.Message;
        //    }

        //}
    }
}
