<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="DC2011.Web.layouts.DC2011.Header" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<header>
    <div class="logo">
        <sc:Image runat="server" Field="Site Logo" ID="Logo" MaxWidth="200" />
    </div>
    <sc:xslfile runat="server" renderingid="{FA3011EB-0578-4B6E-81C0-C42071A3B2C6}" path="/xsl/DC2011/Navigation.xslt" />
</header>