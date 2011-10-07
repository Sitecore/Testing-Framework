using System;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using System.Collections.Generic;

namespace DC2011.Web.Util
{
    public static class ItemReferences
    {
        public static IEnumerable<Item> GetItemsByTemplate(TemplateItem template, Item root)
        {
            var usages = template.GetUsageIDs();
            foreach (var usage in usages)
            {
                var item = template.Database.GetItem(usage);
                if (item != null && (root == null || root.Axes.IsAncestorOf(item)))
                    yield return item;
            }
        }
    }
}