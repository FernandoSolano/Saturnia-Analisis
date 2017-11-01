<%@ Page Title="" Language="C#" MasterPageFile="~/SiteCollaborator.Master" AutoEventWireup="true" CodeBehind="IndexColaborador.aspx.cs" Inherits="Webapp.WebForms.IndexColaborador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Bienvenido al sistema   Saturnia&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" BackColor="#990000" ForeColor="White" OnClick="Button1_Click" Text="Eliminar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </h1>
    <h3>Usted está registrado como: </h3>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

</asp:Content>
