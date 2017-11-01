<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DuplicarTarea.aspx.cs" Inherits="Webapp.WebForms.DuplicarTarea" %>

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
    <asp:RadioButtonList ID="rbl_hours_type" runat="server">
        <asp:ListItem Selected="True" Value="0">Horas regulares</asp:ListItem>
        <asp:ListItem Value="1">Horas extra</asp:ListItem>
    </asp:RadioButtonList>
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
    <asp:Calendar ID="cld_selected_date" runat="server" OnSelectionChanged="cld_selected_date_SelectionChanged"></asp:Calendar>
    <br />
    <asp:Button ID="btn_cancel" runat="server" Text="Cancelar" />
    <asp:Button ID="btn_save" runat="server" Text="Guardar" OnClick="btn_save_Click" />

</asp:Content>
