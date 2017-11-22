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
                <asp:Button ID="btnSearchProject" class="btn btn-danger" runat="server" Text="Buscar" OnClick="btnSearchProject_Click" Width="90px" />
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
                <asp:Button ID="btnSearchUser" class="btn btn-danger" runat="server" Text="Buscar" OnClick="btnSearchUser_Click" Width="90px" />
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
                <asp:Button ID="btnAsign" runat="server" class="btn btn-danger" Text="Asignar" OnClick="btnAsign_Click" Width="90px" Style="margin-left: 10px; margin-top:20px"/>
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" class="btn btn-danger" Text="Cancelar" OnClick="btnCancel_Click" Width="90px" Style="margin-top: 20px"/>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblResponse" runat="server" Visible="false" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblMessage" runat="server" Visible="false" Text="Pulse aceptar para volver al inicio, o presione volver para agregar otro colaborador."></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnAceptar" runat="server" Visible="false" Text="Aceptar" OnClick="btnAceptar_Click" />
            </td>
            <td></td>
            <td>
                <asp:Button ID="btnReturn" runat="server" Visible="false" Text="Volver" OnClick="btnReturn_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
