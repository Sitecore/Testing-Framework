using System;
using Sitecore.Data.Items;
using System.Linq;
using System.Web.UI.WebControls;
using Sitecore.Web.UI.WebControls;
using DC2011.Web.Extensions;
using Sitecore.Data.Fields;
using System.Text;

namespace DC2011.Web.layouts.DC2011
{
    public partial class Filtering_Page_List : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var categoryRoot = Sitecore.Context.Database.GetItem("/sitecore/content/references/categories");
                if (categoryRoot != null)
                {
                    var categories = categoryRoot.GetChildren();
                    drpCategories.DataSource = categories;
                    drpCategories.DataValueField = "ID";
                    drpCategories.DataTextField = "Name";

                    // TODO: title for above, fallback to name
                }

                drpCategories.DataBind();

                // Insert blank category filter
                drpCategories.Items.Insert(0, new ListItem("[all categories]", string.Empty));
                foreach (ListItem item in drpCategories.Items)
                    item.Selected = false;

                PopulateList();
            }
        }

        protected void FilterClicked(object sender, EventArgs args)
        {
            PopulateList();
        }

        protected void PopulateList()
        {
            repPages.DataSource = Sitecore.Context.Item.GetChildrenInCategory(drpCategories.SelectedValue);
            repPages.DataBind();
        }

        protected void ListItemBound(object sender, RepeaterItemEventArgs args)
        {
            if (args.Item.ItemType == ListItemType.Item || args.Item.ItemType == ListItemType.AlternatingItem)
            {
                var control = args.Item.FindControl("Category");
                if (control != null)
                {
                    var categoriesText = new StringBuilder();
                    var item = args.Item.DataItem as Item;

                    foreach (var category in ((MultilistField)item.Fields["Category"]).GetItems())
                    {
                        if (categoriesText.Length > 0)
                            categoriesText.Append(", ");

                        categoriesText.Append(category.GetTitle());
                    }

                    (control as Literal).Text = categoriesText.ToString();
                }
            }
        }
    }
}