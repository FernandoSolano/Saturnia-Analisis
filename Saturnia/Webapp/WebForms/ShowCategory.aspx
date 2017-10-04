<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowCategory.aspx.cs" Inherits="Webapp.WebForms.ShowCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>
        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
    </h1>
    <table>
        <tr>
            <td>
                <h2>
                    <asp:Label ID="lblDescription" runat="server" Text="Descripcion"></asp:Label>
                </h2>
            </td>
            <td>
                <asp:Label ID="lblDescriptionContent" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink ID="linkDelete" runat="server">Eliminar categoria</asp:HyperLink>
            </td>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server">Actualizar categoria</asp:HyperLink>
            </td>
        </tr>
    </table>

</asp:Content>
