using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ImageSearchApp.Tests
{
    [TestClass]
    public class MainWindowTest
    {
        //[TestMethod]
        //public void CallFlickrApiTest()
        //{
        //    try
        //    {
        //        MainWindow mainWindowObj = new MainWindow();
        //        mainWindowObj.CallFlickrApi(null, null, null, 0);
        //        return;
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.Fail(ex.Message);
        //    }

        //}

        [TestMethod]
        public void Detail_ClickTest()
        {
            try
            {
                MainWindow mainWindowObj = new MainWindow();
                mainWindowObj.Detail_Click(null, null);
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        public void LoadMoreImages_ClickTest()
        {
            try
            {
                MainWindow mainWindowObj = new MainWindow();
                mainWindowObj.LoadMoreImages_Click(null, null);
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        public void Submit_ClickTest()
        {
            try
            {
                MainWindow mainWindowObj = new MainWindow();
                mainWindowObj.Submit_Click(null, null);
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        //[TestMethod]
        //public void CallFlickrApiTest_ValidCall()
        //{
        //    MainWindow mainWindowObj = new MainWindow();
        //    mainWindowObj.CallFlickrApi("507f934477929499ba1dc73b7b592505", "507f934477929499ba1dc73b7b592505", "tree", 1);
        //    Assert.IsNotNull(mainWindowObj.imageSourceList);

        //}

        //[TestMethod]
        //public void CallFlickrApiTest_InvalidCall()
        //{

        //    MainWindow mainWindowObj = new MainWindow();
        //    mainWindowObj.CallFlickrApi("", "", "tree", 1);
        //    Assert.IsNull(mainWindowObj.imageSourceList);


        //}

    }
}
