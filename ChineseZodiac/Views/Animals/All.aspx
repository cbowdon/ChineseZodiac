<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<ChineseZodiac.ChiZodiacDb>" MasterPageFile="~/Site.master" %>

<asp:Content id="AllTitle" ContentPlaceHolderID="TitleContent" runat="server">
All
</asp:Content>

<asp:Content id="AllText" ContentPlaceHolderID="MainContent" runat="server">
<p>		
	This is all of them:
</p>
<ul>
	<% foreach (var n in Model.Names) { %>
	<li><%= Html.Encode (n) %> [<%= Html.ActionLink("Details", "Details", new {name = n}) %>] </li>
	<% } %>
</ul>

There <%= Model.Names.Count == 1? "is only 1 animal" : "are only "+Model.Names.Count+" animals" %>. 
	
</asp:Content>