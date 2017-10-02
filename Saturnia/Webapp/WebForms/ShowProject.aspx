﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowProject.aspx.cs" Inherits="Webapp.WebForms.ShowProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
    </h1>
    <table>
        <tr>
            <td>
                <h2>
                    <asp:Label ID="lblState" runat="server" Text="Estado"></asp:Label>
                </h2>
            </td>
            <td>
                <asp:Label ID="lblStateDescription" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <h2>
                    <asp:Label ID="lblDescription" runat="server" Text="Descripcion"></asp:Label>
                </h2>
            </td>
            <td>
                <asp:Label ID="lblDescriptionContent" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <h2>
                    <asp:Label ID="lblEstimatedHours" runat="server" Text="Horas estimadas"></asp:Label>
                </h2>
            </td>
            <td>
                <asp:Label ID="lblEstimatedHoursContent" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <h2>
                    <asp:Label ID="lblStartDate" runat="server" Text="Fecha de inicio"></asp:Label>
                </h2>
            </td>
            <td>
                <asp:Label ID="lblStartDateContent" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <h2>
                    <asp:Label ID="lblEndDate" runat="server" Text="Fecha de finalizacion"></asp:Label>
                </h2>
            </td>
            <td>
                <asp:Label ID="lblEndDateContent" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="btnDelete" runat="server">Eliminar</asp:LinkButton>
            </td>
            <td>
                <asp:HyperLink ID="linkUpdate" runat="server">Actualizar proyecto</asp:HyperLink>
            </td>
        </tr>
    </table>
    
</asp:Content>