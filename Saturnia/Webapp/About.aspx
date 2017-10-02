<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Webapp.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.<asp:Button ID="BT_Eliminar" runat="server" OnClick="BT_Eliminar_Click" OnClientClick="return confirm('Esta seguro de eliminar el proyecto?');" Text="Eliminar" />
    </h2>
    <p>&nbsp;</p>
    </asp:Content>
