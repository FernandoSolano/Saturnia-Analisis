<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearProyecto.aspx.cs" Inherits="Webapp.WebForms.ActualizarProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="lbl_title" runat="server" Font-Bold="True" Font-Size="Large" Text="Crear un nuevo proyecto"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lbl_name" runat="server" Text="Nombre:"></asp:Label>

        <asp:TextBox ID="tb_name" runat="server" Width="400 px" Style="margin:5px 0px 0px 65px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validator_tb_name" runat="server" ControlToValidate="tb_name" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Este campo es necesario</asp:RequiredFieldValidator>
    </div>
    <div>
        <asp:Label ID="lbl_description" runat="server" Text="Descripción:"></asp:Label>

        <asp:TextBox ID="tb_description" runat="server" Height="56px" Width="400px" TextMode="MultiLine" Style="margin:5px 0px 0px 40px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validator_tb_description" runat="server" ControlToValidate="tb_description" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Este campo es necesario</asp:RequiredFieldValidator>
    </div>
    <div>
        <asp:Label ID="lbl_estimated_hours" runat="server" Text="Horas estimadas:"></asp:Label>
        <asp:TextBox ID="tb_estimated_hours" runat="server"  Width="400px" TextMode="Number" Style="margin:5px 0px 20px 10px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validator_tb_estimated_hours" runat="server" ControlToValidate="tb_estimated_hours" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Este campo es necesario</asp:RequiredFieldValidator>
    </div>
    <div>
        <asp:Button ID="btn_create" class="btn btn-danger" runat="server" Width="90px" OnClick="btnCreateOnClick" Text="Crear" Style="margin-left: 120px" />
        <asp:Button ID="btn_cancel" class="btn btn-danger" runat="server" Width="90px" CausesValidation="False" OnClick="btnCancelOnClick" Text="Cancelar"  style="margin-left:40px"/>
        
    </div>
</asp:Content>
