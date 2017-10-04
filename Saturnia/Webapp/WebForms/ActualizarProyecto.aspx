<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActualizarProyecto.aspx.cs" Inherits="Webapp.WebForms.ActualizarProyecto1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>

        <table>
            <h2 style="width: 372px">
                <asp:Label ID="Label1" runat="server" Text="Datos del proyecto"></asp:Label>

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
                       <asp:Label ID="Label2" runat="server" Text="Horas estimadas:"></asp:Label> 
                </td>
                <td>
                    <asp:TextBox ID="tbEstimatedHours" runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Fecha de inicio(mes/día/año):"></asp:Label> 
                
                </td>

                <td>
             <asp:TextBox ID="tbStartMonth" runat="server" Width="36px" TextMode="Number"></asp:TextBox>
            /<asp:TextBox ID="tbStartDay" runat="server" Width="36px" TextMode="Number"></asp:TextBox>
            /<asp:TextBox ID="tbStartYear" runat="server" Width="36px" TextMode="Number"></asp:TextBox>
                
                </td>

                
            </tr>

            <tr>
                 <td>
                    <asp:Label ID="Label6" runat="server" Text="Fecha de finalización(mes/día/año):"></asp:Label> 
                </td>

                <td>
             <asp:TextBox ID="tbEndMonth" runat="server" Width="36px" TextMode="Number"></asp:TextBox>
            /<asp:TextBox ID="tbEndDay" runat="server" Width="36px" TextMode="Number"></asp:TextBox>
            /<asp:TextBox ID="tbEndYear" runat="server" Width="36px" TextMode="Number"></asp:TextBox>
                    <asp:Label ID="lbTexto" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>

             <tr>
                <td>
                    <asp:Button ID="btnUpdateProject" runat="server" OnClick="btnUpdateProject_Click" Text="Actualizar" />
                </td>

            </tr>

        </table>

    </div>
</asp:Content>
