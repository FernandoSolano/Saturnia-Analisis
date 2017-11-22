<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MostrarProyecto.aspx.cs" Inherits="Webapp.WebForms.MostrarProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>
        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
    </h2>
    <table>
        <tr>
            <td style="width: 300px">
                <h3>
                    <asp:Label ID="lblState" runat="server" Text="Estado"></asp:Label>
                </h3>
            </td>
            <td>
                <asp:Label ID="lblStateDescription" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 300px">
                <h3>
                    <asp:Label ID="lblDescription" runat="server" Text="Descripción"></asp:Label>
                </h3>
            </td>
            <td>
                <asp:Label ID="lblDescriptionContent" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 300px">
                <h3>
                    <asp:Label ID="lblEstimatedHours" runat="server" Text="Horas estimadas"></asp:Label>
                </h3>
            </td>
            <td>
                <asp:Label ID="lblEstimatedHoursContent" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 300px">
                <h3>
                    <asp:Label ID="lblStartDate" runat="server" Text="Fecha de inicio"></asp:Label>
                </h3>
            </td>
            <td>
                <asp:Label ID="lblStartDateContent" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 300px">
                <h3>
                    <asp:Label ID="lblEndDate" runat="server" Text="Fecha de finalización"></asp:Label>
                </h3>
            </td>
            <td>
                <asp:Label ID="lblEndDateContent" runat="server" Text=""></asp:Label>
            </td>
        </tr>

    </table>
    <div>
        <asp:LinkButton ID="LinkButon_eliminar" runat="server" class="btn btn-danger" OnClick="LinkButon_eliminar_Click" OnClientClick="return confirm('¿Esta seguro de eliminar el proyecto?');" Width="130px">Eliminar</asp:LinkButton>
        <asp:HyperLink ID="LinkUpdateProject" runat="server" class="btn btn-danger">Actualizar</asp:HyperLink>
        <asp:LinkButton ID="linkButtonChangeStatus" runat="server" class="btn btn-danger" OnClick="LinkButonChangeStatus" Width="127px"></asp:LinkButton>
    </div>

</asp:Content>
