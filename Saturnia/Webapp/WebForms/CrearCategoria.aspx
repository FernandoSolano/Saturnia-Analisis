<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearCategoria.aspx.cs" Inherits="Webapp.WebForms.ActualizarCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lbl_title" runat="server" Font-Bold="True" Font-Size="Large" Text="Crear nueva categoría"></asp:Label>
    <br />
    <asp:Label ID="lbl_name" runat="server" Text="Nombre:"></asp:Label>
    <br />
    <asp:TextBox ID="tb_name" runat="server" Width="214px"></asp:TextBox>
    <br />
    <asp:Label ID="lbl_description" runat="server" Text="Descripción:"></asp:Label>
    <br />
    <asp:TextBox ID="tb_description" runat="server" Height="71px" Width="216px"></asp:TextBox>
    <br />
    <asp:Button ID="btn_create" runat="server" Text="Crear" OnClick="btnCreateOnClick" />
</asp:Content>
