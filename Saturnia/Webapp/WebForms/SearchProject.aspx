<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchProject.aspx.cs" Inherits="Webapp.WebForms.SearchProject" %>

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
                    <asp:TextBox ID="txtName" runat="server" onkeyup="myFunction()"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="Buscar" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>

        <asp:Table ID="resultTable" runat="server" Visible="false" BorderWidth="1">
            
        </asp:Table>

</asp:Content>