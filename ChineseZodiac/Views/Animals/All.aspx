<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<ChineseZodiac.ChiZodiacDb>" MasterPageFile="~/Site.master" %>

<asp:Content id="AllTitle" ContentPlaceHolderID="TitleContent" runat="server">
All
</asp:Content>

<asp:Content id="HomeSuffix" ContentPlaceHolderID="TitleSuffix" runat="server">
: All	
</asp:Content>

<asp:Content id="AllText" ContentPlaceHolderID="MainContent" runat="server">
<p>		
	This is all of them:
</p>

<table border="1" cellpadding="5" bgcolor="#DDDDDD">
	<% foreach (var n in Model.Animals) { %>
	<tr>	
		<td><%= Html.Encode (n.Name) %></td>
		<td><%= Html.ActionLink("Details", "Details", new {name = n.Name, position = n.Position, year = n.Year}) %></td>
		<td><%= Html.ActionLink("Edit", "Edit", new {id = n.Id}) %></td>
		<td><%= Html.ActionLink("Delete", "Delete", new {aid = n.Id}) %></td>
	</tr>
	<% } %>			
</table>
	

<br>
There <%= Model.Names.Count == 1? "is 1 animal" : "are  "+Model.Animals.Count+" animals" %>. 
	
</asp:Content>