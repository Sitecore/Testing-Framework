using System;
using Sitecore.Data.Items;
using Sitecore.Sites;

namespace DC2011.Web.Extensions
{
    public static class SiteExtensions
    {
        public static Item GetHomeItem(this SiteContext site)
        {
            return site.Database.GetItem(site.StartPath);
        }
    }
}