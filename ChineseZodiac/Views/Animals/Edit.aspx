<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<ChineseZodiac.CZAnimal>" MasterPageFile="~/Site.master" %>

<asp:Content ContentPlaceHolderID="TitleContent" ID="EditTitle" runat="server">
Edit an animal	
</asp:Content>

<asp:Content id="HomeSuffix" ContentPlaceHolderID="TitleSuffix" runat="server">
: Edit	
</asp:Content>


<asp:Content ContentPlaceHolderID="MainContent" ID="EditMain" runat="server">
<h3>Edit an animal</h3>

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
	<input type="submit" value="Edit" />
<% } %>	
</asp:Content>


