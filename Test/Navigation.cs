using System;
using NUnit.Framework;
using Sitecore.Web.UI.WebControls;
using HtmlAgilityPack;

namespace Test
{
    [TestFixture]
    [Category("Navigation")]
    public class Navigation
    {
        [Test]
        public void IncludeItem()
        {
            var control = new XslFile();
            control.Path = "xsl/dc2011/navigation.xslt";

            Sitecore.Context.Item = Sitecore.Context.Database.GetItem("/sitecore/content/dc2011");
            var output = control.RenderAsText();

            var doc = new HtmlDocument();
            doc.LoadHtml(output);

            var nav = doc.CreateNavigator();
            var link = nav.Select("/nav[@class='primary']/ul/li[a/@href='/en/About Us.aspx']/a");

            Assert.AreEqual(1, link.Count);
        }

        [Test]
        public void ExcludeItem()
        {
            var control = new XslFile();
            control.Path = "xsl/dc2011/navigation.xslt";

            Sitecore.Context.Item = Sitecore.Context.Database.GetItem("/sitecore/content/dc2011");
            var output = control.RenderAsText();
            
            var doc = new HtmlDocument();
            doc.LoadHtml(output);

            var nav = doc.CreateNavigator();
            var link = nav.Select("/nav[@class='primary']/ul/li[a/@href='/en/Services.aspx']/a");

            Assert.AreEqual(0, link.Count);
        }
    }
}