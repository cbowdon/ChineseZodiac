<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<ChineseZodiac.CZAnimal>" MasterPageFile="~/Site.master" %>

<asp:Content id="CreateTitle" ContentPlaceHolderID="TitleContent" runat="server">
Create an animal
</asp:Content>

<asp:Content id="HomeSuffix" ContentPlaceHolderID="TitleSuffix" runat="server">
: Create	
</asp:Content>


<asp:Content id="CreateText" ContentPlaceHolderID="MainContent" runat="server">

<h3>Create an animal</h3>

<%= Html.ValidationSummary ("There are some errors in your input! Please correct them and try again.") %>
<br/>	
	
<% using (Html.BeginForm()) { %>

	<%= Html.Hidden ("Id", 0) %>	
	
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
	<input type="submit" value="Create" />
	
<% } %>	

</asp:Content>
