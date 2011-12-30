<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<ChineseZodiac.CZAnimal>" MasterPageFile="~/Site.master" %>

<asp:Content id="DetailsTitle" ContentPlaceHolderID="TitleContent" runat="server">
Details: <%= Html.Encode(Model.Name) %>
</asp:Content>

<asp:Content id="DetailsText" ContentPlaceHolderID="MainContent" runat="server">


<h3> <%= Html.Encode(Model.Name) %> </h3>
	
<ul>
	<li> Position: <%= Html.Encode(Model.Position) %> </li>
	<li> Year: <%= Html.Encode(Model.Year) %> </li>		
</ul>	


</asp:Content>
