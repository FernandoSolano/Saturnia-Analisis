<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActualizarTarea.aspx.cs" Inherits="Webapp.WebForms.ActualizarTarea" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>

        <table>
            <h2 style="width: 372px">
                <asp:Label ID="Label1" runat="server" Text="Actualizar"></asp:Label>
            </h2>

             <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Descripción:"></asp:Label> 
                </td>
                <td>
                    <asp:TextBox ID="tbDescription" runat="server" TextMode="MultiLine" Width="184px"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Tipo de horas:"></asp:Label> 
                </td>
                <td>
                    <asp:RadioButton ID="rdExtrasHours" runat="server" Text="Extras" />
                    &nbsp;
                    <asp:RadioButton ID="rdHours" runat="server" Text="Ordinarias" />
                    
                </td>
            </tr>

             <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Horas invertidas:"></asp:Label> 
                </td>
                <td>  
                    <asp:TextBox ID="tbHours" runat="server" Width="182px" TextMode="Number"></asp:TextBox>
                </td>
            </tr>

            <tr>
                 <td>
                    <asp:Label ID="Label6" runat="server" Text="Fecha de registro:"></asp:Label> 
                    
                </td>

                <td>
                    <asp:TextBox ID="tbDate" TextMode="Date" runat="server" Width="180px"></asp:TextBox>
                </td>

            </tr>

             <tr>
                 <td>
                    <asp:Button ID="BtnUpdate" runat="server" class="btn btn-success" OnClick="btnUpdateTask_Click" Text="Actualizar" Style="margin-left: 10px" Height="30px" Width="120px" />
                    <asp:Button ID="BtnCancel" runat="server" class="btn btn-danger" OnClick="btnCancel_Click" Text="Cancelar" Style="margin-left: 10px" Height="30px" Width="120px" />              
                </td>

            </tr>

        </table>

    </div>

</asp:Content>
