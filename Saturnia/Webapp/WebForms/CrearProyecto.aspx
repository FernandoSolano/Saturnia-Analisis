<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearProyecto.aspx.cs" Inherits="Webapp.WebForms.ActualizarProyecto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lbl_title" runat="server" Font-Bold="True" Font-Size="Large" Text="Crear un nuevo proyecto"></asp:Label>
    <br />
    <asp:Label ID="lbl_name" runat="server" Text="Nombre:"></asp:Label>
    <br />
    <asp:TextBox ID="tb_name" runat="server" Width="406px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="validator_tb_name" runat="server" ControlToValidate="tb_name" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Este campo es necesario</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lbl_description" runat="server" Text="Descripción:"></asp:Label>
    <br />
    <asp:TextBox ID="tb_description" runat="server" Height="56px" Width="403px" TextMode="MultiLine"></asp:TextBox>
    <asp:RequiredFieldValidator ID="validator_tb_description" runat="server" ControlToValidate="tb_description" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Este campo es necesario</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lbl_estimated_hours" runat="server" Text="Cantidad de horas estimadas:"></asp:Label>
    <asp:TextBox ID="tb_estimated_hours" runat="server" TextMode="Number"></asp:TextBox>
    <asp:RequiredFieldValidator ID="validator_tb_estimated_hours" runat="server" ControlToValidate="tb_estimated_hours" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Este campo es necesario</asp:RequiredFieldValidator>
    <br />
    <asp:Button ID="btn_cancel" runat="server" CausesValidation="False" OnClick="btnCancelOnClick" Text="Cancelar" />
    <asp:Button ID="btn_create" runat="server" OnClick="btnCreateOnClick" Text="Crear" />
</asp:Content>
