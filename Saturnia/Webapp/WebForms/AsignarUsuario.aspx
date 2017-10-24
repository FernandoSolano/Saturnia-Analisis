<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignarUsuario.aspx.cs" Inherits="Webapp.WebForms.AsignarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>
        <label>Asignar Colaborador a Proyecto</label>
    </h1>

    <table>
        <tr>
            <td>
                <label>Proyecto: </label>
            </td>
            <td>
                <asp:TextBox ID="txtProjectName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnSearchProject" runat="server" class="btn btn-danger" Text="Buscar proyecto" OnClick="btnSearchProject_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <label>Colaborador: </label>
            </td>
            <td>
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnSearchUser" class="btn btn-danger" runat="server" Text="Buscar usuario" OnClick="btnSearchUser_Click" />
            </td>
        </tr>
    </table>

    <asp:Table ID="resultTable" CssClass="results" runat="server" Visible="false" BorderWidth="1">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell CssClass="results">
                    Nombre
                </asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="results">
                    Apellidos
                </asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="results">
                    Acción
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>

</asp:Content>
