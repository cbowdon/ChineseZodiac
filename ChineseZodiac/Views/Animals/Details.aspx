<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<ChineseZodiac.CZAnimal>" MasterPageFile="~/Site.master" %>

<asp:Content id="DetailsTitle" ContentPlaceHolderID="TitleContent" runat="server">
Details: <%= Model.Name %>
</asp:Content>

<asp:Content id="DetailsText" ContentPlaceHolderID="MainContent" runat="server">


<h3> <%= Model.Name %> </h3>
	
<ul>
	<li> Position: <%= Model.Position %> </li>
	<li> Year: <%= Model.Year %> </li>		
</ul>	


</asp:Content>
