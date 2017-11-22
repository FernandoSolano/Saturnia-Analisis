<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MostrarCategoria.aspx.cs" Inherits="Webapp.WebForms.MostrarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>
        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
    </h1>
    <table>
        <tr>
            <td style="width: 150px">
                <h3>
                    <asp:Label ID="lblDescription" runat="server" Text="Descripción"></asp:Label>
                </h3>
            </td>
            <td style="width: 150px">
                <asp:Label ID="lblDescriptionContent" runat="server" Text=""></asp:Label>
            </td>
        </tr>

    </table>
    <div>
        <asp:LinkButton ID="LinkButon_Eliminar_Categoria" class="btn btn-danger" runat="server" OnClick="LinkButon_Eliminar_Categoria_Click" OnClientClick="return confirm('¿Esta seguro de eliminar la categoría?');" Style="margin-left:60px">Eliminar</asp:LinkButton>

        <asp:HyperLink ID="LinkUpdateCategory" class="btn btn-danger" runat="server" Style="margin-left:20px">Actualizar</asp:HyperLink>
    </div>

</asp:Content>
