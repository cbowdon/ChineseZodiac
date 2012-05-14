<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<ChineseZodiac.CZAnimal>" MasterPageFile="~/Site.master" %>

<asp:Content id="DetailsTitle" ContentPlaceHolderID="TitleContent" runat="server">
Details: <%= Html.Encode(Model.Name) %>
</asp:Content>

<asp:Content id="HomeSuffix" ContentPlaceHolderID="TitleSuffix" runat="server">
: Details	
</asp:Content>

<asp:Content id="DetailsText" ContentPlaceHolderID="MainContent" runat="server">

<h3> <%= Html.Encode(Model.Name) %> </h3>
	
<ul>
	<li> Position: <%= Html.Encode(Model.Position) %> </li>
	<li> Year: <%= Html.Encode(Model.Year) %> </li>		
	<li> Id: <%= Html.Encode(Model.Id) %> </li>
</ul>

[ <%= Html.ActionLink("See all", "All", "Animals") %>|
	<%= Html.ActionLink("Edit", "Edit", new {id = Model.Id}) %>|
	<%= Html.ActionLink("Delete", "Delete", new {aid = Model.Id}) %> ]		

</asp:Content>
