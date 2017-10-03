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
                <asp:Button ID="btnSearchProject" runat="server" Text="Buscar" OnClick="btnSearchProject_Click" />
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
                <asp:Button ID="btnSearchUser" runat="server" Text="Buscar" OnClick="btnSearchUser_Click" />
            </td>
        </tr>
    </table>

    <asp:Table ID="resultTable" runat="server" Visible="false" BorderWidth="1">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>
                    Nombre
                </asp:TableHeaderCell>
                <asp:TableHeaderCell>
                    Apellidos
                </asp:TableHeaderCell>
                <asp:TableHeaderCell>
                    Acción
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>

</asp:Content>
