using System;
using DC2011.Web.Extensions;

namespace DC2011.Web.layouts.DC2011
{
    public partial class Header : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            Logo.Item = Sitecore.Context.Site.GetHomeItem();
        }
    }
}