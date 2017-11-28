<%@ Page Title="BuscarProyecto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarProyecto.aspx.cs" Inherits="Webapp.WebForms.BuscarProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        <label>Gestión de proyectos</label>
    </h1>
    <h2>
        Crear proyecto.
    </h2>
    <asp:LinkButton ID="lkProject" CssClass="btn btn-danger" PostBackUrl="./CrearProyecto.aspx" runat="server">Ir a crear</asp:LinkButton>
    <h2>
        Buscar Proyecto
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
                <asp:Button ID="btnSearch" class="btn btn-danger" runat="server" Text="Buscar proyecto" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
    <br />
    <div align="center">
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
    </div>
</asp:Content>