<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<ChineseZodiac.CZAnimal>" MasterPageFile="~/Site.master" %>

<asp:Content id="AddTitle" ContentPlaceHolderID="TitleContent" runat="server">
Add an animal
</asp:Content>

<asp:Content id="AddText" ContentPlaceHolderID="MainContent" runat="server">

<h3>Add an animal</h3>

<%= Html.ValidationSummary ("There are some errors in your input! Please correct them and try again.") %>
<br/>	
	
<% using (Html.BeginForm()) { %>
	<label for="Name">Name:</label>
	<br/>
	<%= Html.TextBox ("Name") %>
	<%= Html.ValidationMessage("Name", "*") %>
	<br/><br/>
	<label for="Position">Position:</label>
	<br/>
	<%= Html.TextBox ("Position") %>
	<%= Html.ValidationMessage("Position", "*") %>
	<br/><br/>	
	<label for="Year">Year:</label>
	<br/>
	<%= Html.TextBox ("Year") %>
	<%= Html.ValidationMessage("Year", "*") %>
	<br/><br/>	
	<input type="submit" value="Add" />
<% } %>	

</asp:Content>
