using System;
using System.Linq;
using NUnit.Framework;
using DC2011.Web.Extensions;
using Sitecore.Data.Items;
using Sitecore.SecurityModel;
using System.IO;

namespace Test
{
    [TestFixture]
    [Category("Item Extensions")]
    public class ItemExtensionsTests
    {
        private Item m_testRoot = null;
        private Item m_pageWithTitle = null;
        private Item m_pageNoTitle = null;

        private Item m_categoryItems = null;        

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            var db = Sitecore.Configuration.Factory.GetDatabase("web");
            var folder = db.GetTemplate("Common/Folder");
            var page = db.GetTemplate("dc2011/page");
            var home = db.GetItem("/sitecore/content/dc2011");

            using (new SecurityDisabler())
            {
                m_testRoot = home.Add("test", folder);

                m_pageWithTitle = m_testRoot.Add("withtitle", page);
                m_pageWithTitle.Editing.BeginEdit();
                m_pageWithTitle["title"] = "Different Title";
                m_pageWithTitle.Editing.EndEdit();

                m_pageNoTitle = m_testRoot.Add("notitle", page);

                m_testRoot.Paste(File.ReadAllText(@"test data\Category Items.xml"), true, PasteMode.Overwrite);
                m_categoryItems = m_testRoot.Axes.GetChild("Project List");
            }
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            if (m_testRoot != null)
            {
                using (new SecurityDisabler())
                {
                    m_testRoot.Delete();
                }
            }
        }
        
        [Test]
        public void ItemWithTitle()
        {
            Assert.AreEqual("Different Title", m_pageWithTitle.GetTitle());
        }

        [Test]
        public void ItemWithoutTitle()
        {
            Assert.AreEqual("notitle", m_pageNoTitle.GetTitle());
        }

        [Test]
        public void ItemsInRebrandingCategoryUpdated()
        {
            var db = Sitecore.Configuration.Factory.GetDatabase("web");
            var cat = db.GetItem("/sitecore/content/references/categories/Rebranding");

            var catItems = m_categoryItems.GetChildrenInCategory(cat.ID.ToString());
            Assert.AreEqual(2, catItems.Count());

            var names = from catItem in catItems
                        select catItem.Name;

            Assert.IsTrue(names.Contains("Latest News Section"));
            Assert.IsTrue(names.Contains("Website Rebranding"));
        }
    }
}