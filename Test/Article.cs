using System;
using NUnit.Framework;
using System.Net;
using System.IO;
using HtmlAgilityPack;

namespace Test
{
    [TestFixture]
    [Category("Article")]
    public class Article
    {
        [Test]
        public void ThumbnailPresent()
        {
            var htmlDoc = GetPage("http://dc2011.localhost/About Us.aspx");

            var nav = htmlDoc.CreateNavigator();
            var iter = nav.Select("//*[@class='page-content']/img/@src");

            Assert.AreEqual(1, iter.Count);
        }

        [Test]
        public void ThumbnailNotAssigned()
        {
            var htmlDoc = GetPage("http://dc2011.localhost/Services.aspx");

            var nav = htmlDoc.CreateNavigator();
            var iter = nav.Select("//*[@class='page-content']/img/@src");

            Assert.AreEqual(0, iter.Count);
        }

        protected HtmlDocument GetPage(string url)
        {
            var request = HttpWebRequest.Create(url);
            var response = request.GetResponse();

            var stream = response.GetResponseStream();
            var reader = new StreamReader(stream);
            var responseBody = reader.ReadToEnd();
            response.Close();

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(responseBody);

            return htmlDoc;
        }
    }
}