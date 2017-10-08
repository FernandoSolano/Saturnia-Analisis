<%@ Page Title="BuscarProyecto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarProyecto.aspx.cs" Inherits="Webapp.WebForms.BuscarProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h1>
            <label>Buscar Proyecto</label>
        </h1>

        <table>
            <tr>
                <td>
                    <label>Nombre: </label>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="Buscar" OnClick="btnSearch_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    ¿O desea crear un proyecto?
                </td>
                <td>
                    <asp:HyperLink ID="lkProject" NavigateUrl="./CrearProyecto.aspx" runat="server">Crear</asp:HyperLink>
                </td>
            </tr>
        </table>

        <asp:Table ID="resultTable" runat="server" Visible="false" CssClass="results">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell CssClass="results">
                    Proyecto
                </asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="results">
                    Acción
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>

</asp:Content>