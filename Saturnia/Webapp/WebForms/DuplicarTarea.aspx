<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DuplicarTarea.aspx.cs" Inherits="Webapp.WebForms.DuplicarTarea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="lbl_title" runat="server" Font-Bold="True" Font-Size="Large" Text="Duplicar Tarea"></asp:Label>
    <div>
        <asp:Label ID="lbl_project_name" runat="server" Text="Proyecto:"></asp:Label>
        <asp:DropDownList ID="ddl_projects" runat="server" class="btn btn-secundary dropdown-toggle" Style="background-color: #e6e6e6; margin-left: 65px; margin-bottom: 20px;" Width="220px">
        </asp:DropDownList>
    </div>
    <div>
        <asp:Label ID="lbl_category_name" runat="server" Text="Categoría:"></asp:Label>
        <asp:DropDownList ID="ddl_categories" runat="server" class="btn btn-secundary dropdown-toggle" Style="background-color: #e6e6e6; margin-left: 60px; margin-bottom: 20px;" Width="220px">
        </asp:DropDownList>
    </div>
    <div>
        <asp:Label ID="lbl_hours_type" runat="server" Text="Tipo de horas:"></asp:Label>
        <asp:RadioButtonList ID="rbl_hours_type" runat="server" RepeatDirection="Horizontal" Style="margin: 20px 0px 20px 80px; list-style: none" OnSelectedIndexChanged="rbl_hours_type_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem Value="0" style="margin-right: 20px;">Horas regulares</asp:ListItem>
            <asp:ListItem Value="1">Horas extra</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Label ID="lbl_warning_hours_type" runat="server" ForeColor="#FF6600" Text="Por favor seleccione el tipo de horas" Visible="False"></asp:Label>
    </div>
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <fieldset>
                    <asp:Label ID="lbl_dedicated_time" runat="server" Text="Tiempo dedicado:"></asp:Label>
                    <asp:DropDownList ID="ddl_hours" runat="server" class="btn btn-secundary dropdown-toggle" Style="background-color: #e6e6e6; margin-left: 20px" Width="70px" AutoPostBack="True" OnSelectedIndexChanged="ddl_hours_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Label ID="lbl_hours" runat="server" Text="hora(s)"></asp:Label>
                    <asp:DropDownList ID="ddl_minutes" runat="server" class="btn btn-secundary dropdown-toggle" Style="background-color: #e6e6e6; margin-left: 20px" Width="70px">
                    </asp:DropDownList>
                    <asp:Label ID="lbl_minutes" runat="server" Text="minutos"></asp:Label>
                    <asp:Label ID="lbl_error_hours" runat="server" ForeColor="Red" Text="No ha seleccionado  horas, el tiempo mínimo permitido es de 30 minutos" Visible="False"></asp:Label>
                </fieldset>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="rbl_hours_type" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div style="margin-top: 10px">
        <asp:Label ID="lbl_description" runat="server" Text="Descripción:"></asp:Label>
        <asp:TextBox ID="tb_description" runat="server" TextMode="MultiLine" Height="101px" Width="350px" Style="margin-left: 30px; margin-bottom: 20px;"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lbl_date" runat="server" Text="Fecha:"></asp:Label>
        <table>
            <tr>
                <td>
                    <asp:DropDownList ID="DdlMonth" runat="Server" class="btn btn-secundary dropdown-toggle" Style="background-color: #e6e6e6; margin-bottom: 5px" OnSelectedIndexChanged="SetCalendar" AutoPostBack="true"></asp:DropDownList>
                    <asp:DropDownList ID="DdlYear" runat="Server" class="btn btn-secundary dropdown-toggle" Style="background-color: #e6e6e6; margin-bottom: 5px" OnSelectedIndexChanged="SetCalendar" AutoPostBack="true"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Calendar ID="cld_selected_date" runat="server" OnSelectionChanged="cld_selected_date_SelectionChanged" BackColor="White" BorderColor="Maroon" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="400px" OnDayRender="DisableDays">
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
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        <asp:Button ID="btn_save" class="btn btn-success" runat="server" Text="Guardar" OnClick="btn_save_Click" UseSubmitBehavior="False" Style="margin-left: 110px" />
        <asp:Button ID="btn_cancel" class="btn btn-danger" runat="server" Text="Cancelar" OnClick="btn_cancel_Click" Style="margin-left: 10px" />

    </div>
</asp:Content>
