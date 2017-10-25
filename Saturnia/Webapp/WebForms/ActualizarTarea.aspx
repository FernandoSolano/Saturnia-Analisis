<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActualizarTarea.aspx.cs" Inherits="Webapp.WebForms.ActualizarTarea" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>

        <table>
            <h2 style="width: 372px">
                <asp:Label ID="Label1" runat="server" Text="Actualizar"></asp:Label>
            </h2>

            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Colaborador:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbColaborator" runat="server" Width="180px"></asp:TextBox>
                </td>

            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Proyecto:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbProject" runat="server" Width="182px"></asp:TextBox>
                </td>
            </tr>
           
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Categoria:"></asp:Label> 
                </td>
                <td>
                    <asp:TextBox ID="tbCategory" runat="server" Width="182px"></asp:TextBox>
                </td>
            </tr>

             <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Descripción:"></asp:Label> 
                </td>
                <td>
                    <asp:TextBox ID="tbDescription" runat="server" TextMode="MultiLine" Width="182px"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Horas invertidas:"></asp:Label> 
                </td>
                <td>
                    <asp:TextBox ID="tbHours" runat="server" Width="182px"></asp:TextBox>
                </td>
            </tr>

             <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Horas extras:"></asp:Label> 
                </td>
                <td>  
                    <asp:TextBox ID="tbExtraHours" runat="server" Width="182px"></asp:TextBox>
                </td>
            </tr>

            <tr>
                 <td>
                    <asp:Label ID="Label6" runat="server" Text="Fecha de realización:"></asp:Label> 
                    
                </td>

                <td>
                    <asp:TextBox ID="tbDate" TextMode="Date" runat="server"></asp:TextBox>
                </td>

            </tr>

             <tr>
                 <td>
                     <asp:Button ID="Button1" runat="server" OnClick="btnUpdateTask_Click" Text="Actualizar" />
                 </td>

                <td>
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancelar" />
                    
                </td>

            </tr>

        </table>

    </div>


</asp:Content>
