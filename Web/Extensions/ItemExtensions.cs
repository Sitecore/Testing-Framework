using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.StringExtensions;

namespace DC2011.Web.Extensions
{
    public static class ItemExtensions
    {
        public static string GetTitle(this Item item)
        {
            var title = item["title"];
            if (string.IsNullOrEmpty(title))
                title = item.Name;

            return title;
        }

        public static string GetUrl(this Item item)
        {
            return LinkManager.GetItemUrl(item);
        }

        public static Item GetHomeByTraversal(this Item item)
        {
            return item.Axes.SelectSingleItem("ancestor-or-self::*[@@templateid='{0}']".FormatWith(Constants.Templates.HomeId));
        }

        public static IEnumerable<Item> GetChildrenInCategory(this Item item, string category)
        {
            var children = item.GetChildren();
            return from Item child in children
                where string.IsNullOrEmpty(category) || child["category"].Contains(category)
                select child;
        }
    }
}