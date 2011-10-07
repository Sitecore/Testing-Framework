using System.Xml;
using System.Xml.XPath;
using DC2011.Web.Extensions;
using Sitecore.Configuration;

namespace DC2011.Web.Util
{
    public class XslHelper
    {
        public XPathNodeIterator GetHomeItem()
        {
            var item = Sitecore.Context.Site.GetHomeItem();
            if (item != null)
                return Factory.CreateItemNavigator(item).Select(".");

            return new XmlDocument().CreateNavigator().Select("*");
        }
    }
}