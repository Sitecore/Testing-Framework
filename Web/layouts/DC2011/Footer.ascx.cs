namespace DC2011.Web.layouts.DC2011
{
    using System;

    public partial class Footer : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here

            // test
            var ren = Sitecore.Context.Item.Visualization.GetRenderings(Sitecore.Context.Device, false);
            int y = 0;
            // end test
        }
    }
}