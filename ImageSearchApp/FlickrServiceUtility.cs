using FlickrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSearchApp
{
    public class FlickrServiceUtility
    {
        //private PhotoCollection photos;
        //private int pageNumber = 1;
        private string keyWord = string.Empty;
        public void CallFlickrApi(string keyString, int pageNum, ref List<Photo> imageSourceList)
        {
            try
            {
                ////Flickr flickrObj = new Flickr();
                //flickrObj.ApiKey = apiKey;
                //flickrObj.ApiSecret = apiSecret;
                Flickr flickrObj = FlickrManager.Instance;
                //var options = new PhotoSearchOptions { Tags = keyString, Page = pageNum, PerPage = 20 };
                //photos = flickrObj.PhotosSearch(options);
                PhotoCollection photos = GetPhotos(flickrObj, keyString, pageNum);
                AddPhotosToImageSourceList(photos, ref imageSourceList);
                //imageSourceList = new List<Photo>();
                //foreach (Photo photo in photos)
                //{
                //    imageSourceList.Add(photo);
                //}

            }
            catch (Exception ex)
            {
                //errormessage.Text = ex.Message;
            }

        }
        private PhotoCollection GetPhotos(Flickr flickrObj,string keyString, int pageNum)
        {
            var options = new PhotoSearchOptions { Tags = keyString, Page = pageNum, PerPage = 20 };
            PhotoCollection photos = flickrObj.PhotosSearch(options);
            return photos;
        }
        private void AddPhotosToImageSourceList(PhotoCollection photos, ref List<Photo> imageSourceList)
        {
            foreach (Photo photo in photos)
            {
                imageSourceList.Add(photo);
            }

        }

    }
}
