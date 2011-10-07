<%@ Page Language="c#" CodePage="65001" AutoEventWireup="true" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ OutputCache Location="None" VaryByParam="none" %>
<%@ Import Namespace="DC2011.Web.Extensions" %>
<!doctype html>
<html>
    <head>
        <title>
            <%= Sitecore.Context.Item.GetTitle() %></title>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        <meta name="CODE_LANGUAGE" content="C#" />
        <meta name="vs_defaultClientScript" content="JavaScript" />
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
        <link href="/theme/standard/css/screen.css" rel="stylesheet" media="all" />
        <sc:VisitorIdentification runat="server" />
    </head>
    <body>
        <form method="post" runat="server" id="mainform">
            <div id="page">
                <sc:sublayout runat="server" renderingid="{58E4AE27-6CE2-4F17-8549-300E67031F31}" path="/layouts/DC2011/Header.ascx" />
                <div class="content">
                    <sc:Placeholder runat="server" Key="page" />
                </div>
                <sc:sublayout runat="server" renderingid="{332C860A-9688-47AB-ADB7-D540B8A062CD}" path="/layouts/DC2011/Footer.ascx" />
            </div>
        </form>
    </body>
</html>
