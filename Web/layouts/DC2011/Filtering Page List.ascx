<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Filtering_Page_List.ascx.cs" Inherits="DC2011.Web.layouts.DC2011.Filtering_Page_List" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Import Namespace="Sitecore.Data.Items" %>
<%@ Import Namespace="DC2011.Web.Extensions" %>
<div class="form">
    <div class="title">Filter by</div>
    <div class="filter">
        <asp:Label runat="server" AssociatedControlID="drpCategories" Text="Category:" />
        <asp:DropDownList runat="server" ID="drpCategories" />
    </div>
    <div class="buttons">
        <asp:Button runat="server" Text="Filter" OnClick="FilterClicked" />
    </div>
</div>
<div class="list">
    <asp:Repeater runat="server" ID="repPages" OnItemDataBound="ListItemBound">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <div class="thumbnail">
                    <sc:Image runat="server" Field="Thumbnail" MaxWidth="70" Item="<%# (Container.DataItem as Item) %>" />
                </div>
                <div class="title">
                    <a href="<%# (Container.DataItem as Item).GetUrl() %>"><%# (Container.DataItem as Item).GetTitle() %></a>
                </div>
                <div class="sub">
                    category: <asp:Literal runat="server" ID="Category" />
                </div>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</div>