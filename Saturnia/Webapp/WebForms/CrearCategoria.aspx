﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearCategoria.aspx.cs" Inherits="Webapp.WebForms.ActualizarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lbl_title" runat="server" Font-Bold="True" Font-Size="Large" Text="Crear una nueva categoría"></asp:Label>

    <asp:Label ID="lbl_name" runat="server" Text="Nombre:"></asp:Label>

    <asp:TextBox ID="tb_name" runat="server" Width="214px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="validator_tb_name" runat="server" ControlToValidate="tb_name" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Este campo es necesario</asp:RequiredFieldValidator>

    <asp:Label ID="lbl_description" runat="server" Text="Descripción:"></asp:Label>

    <asp:TextBox ID="tb_description" runat="server" Height="71px" Width="216px" TextMode="MultiLine"></asp:TextBox>
    <asp:RequiredFieldValidator ID="validator_tb_description" runat="server" ControlToValidate="tb_description" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Este campo es necesario</asp:RequiredFieldValidator>

    <asp:Button ID="btn_cancel" runat="server" CausesValidation="False" OnClick="btnCancelOnClick" Text="Cancelar" />
    <asp:Button ID="btn_create" runat="server" Text="Crear" OnClick="btnCreateOnClick" />
</asp:Content>
