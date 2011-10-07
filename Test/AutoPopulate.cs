using System;
using NUnit.Framework;
using Sitecore.SecurityModel;
using Sitecore.Data.Items;

namespace Test
{
    [TestFixture]
    [Category("AutoPopulate")]
    public class AutoPopulate
    {
        [Test]
        public void AutoFill()
        {
            var template = Sitecore.Context.Database.GetTemplate("dc2011/page");
            var home = Sitecore.Context.Database.GetItem("/sitecore/content/dc2011");
            Item testItem = null;

            using (new SecurityDisabler())
            {
                testItem = home.Add("test", template);
            }

            var field = testItem["related pages"];
            Assert.IsNotEmpty(field);
        }

        [Test]
        public void AutoFillNotEmpty()
        {
            var template = Sitecore.Context.Database.GetTemplate("dc2011/page");
            var home = Sitecore.Context.Database.GetItem("/sitecore/content/dc2011");
            Item testItem = null;

            using (new SecurityDisabler())
            {
                testItem = home.Add("test", template);
                testItem.Editing.BeginEdit();
                testItem["related pages"] = home.ID.ToString();
                testItem.Editing.EndEdit();
            }

            var field = testItem["related pages"];
            Assert.AreEqual(home.ID.ToString(), field);
        }
    }
}