<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" MasterPageFile="~/Site.master" %>

<asp:Content id="HomeTitle" ContentPlaceHolderID="TitleContent" runat="server">
Home	
</asp:Content>

<asp:Content id="HomeSuffix" ContentPlaceHolderID="TitleSuffix" runat="server">
: Home	
</asp:Content>

<asp:Content id="HomeText" ContentPlaceHolderID="MainContent" runat="server">
<p>		
	The Chinese Zodiac has 12 animals! 
</p>				
<p>
	This site has a database where you can add, edit and delete them.
</p>		
</asp:Content>