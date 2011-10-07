using System;
using System.Linq;
using DC2011.Web.Extensions;
using DC2011.Web.Util;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Events;
using System.Collections.Generic;
using Sitecore.Data;

namespace DC2011.Web.Events
{
    public class AutoPopulateArticles
    {
        protected static ID m_processing = ID.Null;
        protected List<string> m_templateNames = null;

        public string RootPath
        {
            get;
            set;
        }

        public AutoPopulateArticles()
        {
            m_templateNames = new List<string>();
        }

        public void ItemSaved(object sender, EventArgs args)
        {
            var item = Event.ExtractParameter(args, 0) as Item;
            if (item != null && m_templateNames.Contains(item.TemplateName.ToLower()))
            {
                if (item.ID != m_processing && item.Paths.FullPath.ToLower().StartsWith(RootPath.ToLower()))
                {
                    if (string.IsNullOrEmpty(item["related pages"]))
                    {
                        var home = item.GetHomeByTraversal();
                        var relatedByTemplate = ItemReferences.GetItemsByTemplate(item.Template, home);
                        var relatedCount = relatedByTemplate.Count();

                        if (relatedCount > 0)
                        {
                            var random = new Random();
                            var select = new int[] { random.Next(0, relatedCount - 1), random.Next(0, relatedCount - 1), random.Next(0, relatedCount - 1) };

                            item.Editing.BeginEdit();

                            ((MultilistField)item.Fields["related pages"]).Add(relatedByTemplate.ElementAt(select[0]).ID.ToString());
                            ((MultilistField)item.Fields["related pages"]).Add(relatedByTemplate.ElementAt(select[1]).ID.ToString());
                            ((MultilistField)item.Fields["related pages"]).Add(relatedByTemplate.ElementAt(select[2]).ID.ToString());

                            m_processing = item.ID;
                            item.Editing.EndEdit();
                            m_processing = ID.Null;
                        }
                    }
                }
            }
        }

        public void AddTemplateName(string name)
        {
            m_templateNames.Add(name.ToLower());
        }
    }
}