﻿<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" MasterPageFile="~/Site.master" %>

<asp:Content id="AnimalsTitle" ContentPlaceHolderID="TitleContent" runat="server">
Animals	
</asp:Content>

<asp:Content id="AnimalsText" ContentPlaceHolderID="MainContent" runat="server">
<p>		
	Here we deal with the animals database.
</p>		

<ul>
	<li> <%= Html.ActionLink("See all the animals", "All", "Animals") %> </li>		
	<li> <%= Html.ActionLink("Add an animal", "Add", "Animals") %> </li>		
</ul>	
</asp:Content>