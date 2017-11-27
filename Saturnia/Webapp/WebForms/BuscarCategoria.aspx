<%@ Page Title="BuscarCategoria" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarCategoria.aspx.cs" Inherits="Webapp.WebForms.BuscarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>
        <label>Gestión de categoría</label>
    </h1>

    <h2>
        Crear categoría
    </h2>
    <asp:LinkButton ID="lkCategory" CssClass="btn btn-danger" PostBackUrl="./CrearCategoria.aspx" runat="server">Ir a crear</asp:LinkButton>

    <h2>
        Buscar Categoría
    </h2>

    <table>
        <tr>
            <td>
                <label>Nombre: </label>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="Buscar categoría" class="btn btn-danger" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
    <div align="center">
        <asp:Table ID="resultTable" CssClass="results" runat="server" Visible="false">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell CssClass="results">
                    Nombre
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>

</asp:Content>
