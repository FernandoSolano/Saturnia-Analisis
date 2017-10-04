<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActualizarCategoria.aspx.cs" Inherits="Webapp.WebForms.ActualizarCategoria1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>

        <table>
            <h2 style="width: 372px">
                <asp:Label ID="Label1" runat="server" Text="Datos sobre la categoria"></asp:Label>

            </h2>

            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Nombre:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbName" runat="server" Width="180px"></asp:TextBox>
                </td>

            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Descripcion:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbDescription" runat="server" Height="49px" TextMode="MultiLine" Width="182px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnUpdateCategory" runat="server" OnClick="btnUpdateCategory_Click" Text="Actualizar" />
                </td>

            </tr>
        </table>

    </div>

</asp:Content>
