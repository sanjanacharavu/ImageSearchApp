using FlickrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSearchApp
{
    public class FlickrManager
    {
        private const string ApiKey = "6a93a4f31d50ff70991335c9b3988826";
        private const string SharedSecret = "d66359fcd4104df8";

        private FlickrManager() { }
        private static Flickr instance = null;
        public static Flickr Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Flickr(ApiKey, SharedSecret);
                }
                return instance;
            }
        }
    }
}
