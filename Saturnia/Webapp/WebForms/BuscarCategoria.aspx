<%@ Page Title="BuscarCategoria" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarCategoria.aspx.cs" Inherits="Webapp.WebForms.BuscarCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>
            <label>Buscar Categoría</label>
        </h1>

        <table width="100%">
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
                <td>
                    ¿O desea crear una categoría?
                </td>
                <td>
                    <asp:HyperLink ID="lkCategory" NavigateUrl="./CrearCategoria.aspx" runat="server">Crear</asp:HyperLink>
                </td>
            </tr>
        </table>

        <asp:Table ID="resultTable" runat="server" Visible="false" BorderWidth="1">
            
        </asp:Table>

</asp:Content>
