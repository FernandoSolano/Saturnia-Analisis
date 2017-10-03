<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsociarUsuario.aspx.cs" Inherits="Webapp.WebForms.AsociarUsuario" %>
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
        <tr>
            <td></td>
            <td>
                <asp:CheckBox ID="cbLeader" runat="server" Text="Líder de proyecto" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnAsign" runat="server" Text="Asignar" OnClick="btnAsign_Click" />
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Cancelar" OnClick="btnCancel_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
