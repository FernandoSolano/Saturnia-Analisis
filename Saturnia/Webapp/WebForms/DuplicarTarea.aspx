﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DuplicarTarea.aspx.cs" Inherits="Webapp.WebForms.DuplicarTarea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="lbl_title" runat="server" Font-Bold="True" Font-Size="Large" Text="Duplicar Tarea"></asp:Label>
    <br />
    <asp:Label ID="lbl_project_name" runat="server" Text="Proyecto:"></asp:Label>
    <asp:DropDownList ID="ddl_projects" runat="server">
    </asp:DropDownList>
    <br />
    <asp:Label ID="lbl_category_name" runat="server" Text="Categoría:"></asp:Label>
    <asp:DropDownList ID="ddl_categories" runat="server">
    </asp:DropDownList>
    <br />
    <asp:Label ID="lbl_hours_type" runat="server" Text="Tipo de horas:"></asp:Label>
    <asp:RadioButtonList ID="rbl_hours_type" runat="server" OnSelectedIndexChanged="rbl_hours_type_SelectedIndexChanged" AutoPostBack="True">
        <asp:ListItem Value="0">Horas regulares</asp:ListItem>
        <asp:ListItem Value="1">Horas extra</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Label ID="lbl_warning_hours_type" runat="server" ForeColor="#FF6600" Text="Por favor seleccione el tipo de horas" Visible="False"></asp:Label>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <fieldset>
                <asp:Label ID="lbl_dedicated_time" runat="server" Text="Tiempo dedicado:"></asp:Label>
                <asp:DropDownList ID="ddl_hours" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_hours_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="lbl_hours" runat="server" Text="hora(s)"></asp:Label>
                <asp:DropDownList ID="ddl_minutes" runat="server">
                </asp:DropDownList>
                <asp:Label ID="lbl_minutes" runat="server" Text="minutos"></asp:Label>
                <asp:Label ID="lbl_error_hours" runat="server" ForeColor="Red" Text="No ha seleccionado  horas, el tiempo mínimo permitido es de 30 minutos" Visible="False"></asp:Label>
            </fieldset>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="rbl_hours_type" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    &nbsp;<br />
    <asp:Label ID="lbl_description" runat="server" Text="Descripción:"></asp:Label>
    <asp:TextBox ID="tb_description" runat="server" TextMode="MultiLine" Height="76px" Width="333px"></asp:TextBox>
    <br />
    <asp:Label ID="lbl_date" runat="server" Text="Fecha:"></asp:Label>
    <asp:Calendar ID="cld_selected_date" runat="server" OnSelectionChanged="cld_selected_date_SelectionChanged"  BackColor="White" BorderColor="Maroon" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="400px" OnDayRender="DisableDays">
        <DayHeaderStyle BackColor="#990000" Font-Bold="True" Font-Size="7pt" ForeColor="Silver" Height="10pt" />
        <DayStyle Width="14%" />
        <NextPrevStyle Font-Size="8pt" ForeColor="White" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#CC3333" ForeColor="Maroon" />
        <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
        <TitleStyle BackColor="#252525" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
        <TodayDayStyle BackColor="#CCCC99" />
    </asp:Calendar>
    <asp:Label ID="lbl_warning_reselect" runat="server" ForeColor="#FF6600" Text="Por favor ingrese nuevamente la cantidad de horas" Visible="False"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btn_cancel" runat="server" Text="Cancelar" OnClick="btn_cancel_Click" />
    <asp:Button ID="btn_save" runat="server" Text="Guardar" OnClick="btn_save_Click" UseSubmitBehavior="False" />

</asp:Content>
