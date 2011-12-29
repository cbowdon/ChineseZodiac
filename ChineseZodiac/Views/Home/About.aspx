<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" MasterPageFile="~/Site.master" %>

<asp:Content id="AboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
About	
</asp:Content>

<asp:Content id="AboutText" ContentPlaceHolderID="MainContent" runat="server">
<p>		
	This project is intended to demonstrate/experiment with good practice for building ASP.NET MVC 2 applications.
</p>

<p>
<b>Model:</b><br/>	
	There will be a SQLite (3) database of all the animals in the Chinese Zodiac, containing the animal's name, race position and a description.
	It would be nice to also have an image for each animal included in the database.	
	There will also be a method for calculating which year is which animal.
</p>

<p>
<b>Views:</b><br/>
	The user will be able to add, edit and delete animals from this zodiac. They will be able to see a list view and a detail view.	
</p>	
</asp:Content>