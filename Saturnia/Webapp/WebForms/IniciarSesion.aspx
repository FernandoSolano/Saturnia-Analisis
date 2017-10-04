<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IniciarSesion.aspx.cs" Inherits="Webapp.WebForms.IniciarSesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="pannel">
    <br />
    <asp:Label ID="Label1" runat="server" Text="Iniciar sesión:"></asp:Label>
    <br />
    <br />
    <asp:Label ID="LblNickname" runat="server" Text="Nombre de usuario: "></asp:Label>

    <asp:TextBox ID="TxtNickname" runat="server" style="margin-left: 100px" Width="230px"></asp:TextBox>
    <br />
    <asp:Label ID="LblPassword" runat="server" Text="Contraseña:"></asp:Label>

    <asp:TextBox ID="TxtPassword" runat="server"  style="margin-left: 151px" Width="230px"></asp:TextBox>
    <br />
   
    <asp:Button ID="BtnLogin" runat="server"  Text="Inciar sesion" Width="111px" OnClick="BtnLogin_Click" />
    <br />
    </div>
</asp:Content>
