<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<ChineseZodiac.ChiZodiacDb>" MasterPageFile="~/Site.master" %>

<asp:Content id="AllTitle" ContentPlaceHolderID="TitleContent" runat="server">
All
</asp:Content>

<asp:Content id="AllText" ContentPlaceHolderID="MainContent" runat="server">
<p>		
	This is all of them:
</p>
<ul>
	<% foreach (var n in Model.Animals) { %>
	<li><%= Html.Encode (n.Name) %> 
		[<%= Html.ActionLink("Details", "Details", new {name = n.Name, position = n.Position, year = n.Year}) %>] 
		[<%= Html.ActionLink("Delete", "Delete", new {name = n.Name}) %>]</li>
	<% } %>
</ul>

There <%= Model.Names.Count == 1? "is only 1 animal" : "are only "+Model.Animals.Count+" animals" %>. 
	
</asp:Content>