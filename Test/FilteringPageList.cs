using System;
using NUnit.Framework;
using WatiN.Core;

namespace Test
{
    [TestFixture]
    [Category("FilteringPageList")]
    public class FilteringPageList
    {
        [Test]
        [STAThread]
        public void FilterByCategory()
        {
            using (var ie = new IE("http://dc2011.localhost/Project List.aspx"))
            {
                var articles = ie.List(list => list.Parent.ClassName == "list");
                var count = articles.Children().Count;

                ie.SelectList(list => list.Parent.ClassName == "filter").Select("Date Code");
                ie.Button(button => button.Parent.ClassName == "buttons").Click();

                articles.Refresh();
                var filterCount = articles.Children().Count;

                Assert.Less(filterCount, count);
            }
        }
    }
}