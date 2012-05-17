<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" MasterPageFile="~/Site.master" %>

<asp:Content id="CreateTitle" ContentPlaceHolderID="TitleContent" runat="server">
Upload a picture
</asp:Content>

<asp:Content id="HomeSuffix" ContentPlaceHolderID="TitleSuffix" runat="server">
: Picture	
</asp:Content>


<asp:Content id="CreateText" ContentPlaceHolderID="MainContent" runat="server">

Note: The upload page is a work in progress.
	<br/><br/>
<%using (Html.BeginForm("Upload","Home", FormMethod.Post, new {enctype = "multipart/form-data"})){%>    
   	<label for="ImageName">Image Name:</label><br/>
	<input type="text" name="ImageName" id="ImageName" /><br/>
	<label for="Upload">Choose a file:</label><br/>
   	<input type="file" name="upload" id="ImageUpload" value="Upload Image"/>
	<br/><br/>
   	<input type="submit" value="Upload" />
<%} %>

</asp:Content>	
					
