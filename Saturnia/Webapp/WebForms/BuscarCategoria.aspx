<%@ Page Title="BuscarCategoria" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarCategoria.aspx.cs" Inherits="Webapp.WebForms.BuscarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>
        <label>Buscar Categoría</label>
    </h1>

    <table>
        <tr>
            <td>
                <label>Nombre: </label>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" onkeyup="myFunction()"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="Buscar" OnClick="btnSearch_Click" />
            </td>
        </tr>
        <tr>
            <td>¿O desea crear una categoría?
            </td>
            <td>
                <asp:HyperLink ID="lkCategory" NavigateUrl="./CrearCategoria.aspx" runat="server">Crear</asp:HyperLink>
            </td>
        </tr>
    </table>

    <asp:Table ID="resultTable" CssClass="results" runat="server" Visible="false">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell CssClass="results">
                Nombre
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>

</asp:Content>
