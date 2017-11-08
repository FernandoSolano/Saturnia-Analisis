<%@ Page Title="" Language="C#" MasterPageFile="~/SiteCollaborator.Master" AutoEventWireup="true" CodeBehind="ActualizarTarea.aspx.cs" Inherits="Webapp.WebForms.ActualizarTarea" %>

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
                    <asp:TextBox ID="tbDescription" runat="server" TextMode="MultiLine" Width="293px" Height="55px"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Tipo de horas:"></asp:Label>
                </td>
                <td>

                    <div>
                        <asp:Label ID="lbTipoDeHora" runat="server" Text="Label"></asp:Label>
                    </div>
                </td>
            </tr>

            <tr>
                <td>

                    <label>Horas:</label>
                    <asp:TextBox ID="tbHours" runat="server" TextMode="Number"></asp:TextBox>
                    <br />
                    <asp:Label ID="lbHours" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td>
                    <label style="margin-left: 20px">Minutos:</label>
                                <asp:DropDownList ID="ddlMinutes" runat="server" Style="margin-left: 30px" Width="60px">
                                    <asp:ListItem>00</asp:ListItem>
                                    <asp:ListItem>30</asp:ListItem>
                                </asp:DropDownList>
                </td>

            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Fecha de registro:"></asp:Label>

                </td>

                <td>
                    <asp:Calendar ID="CdDate" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                        <TodayDayStyle BackColor="#CCCCCC" />
                    </asp:Calendar>
                </td>

            </tr>

            <tr>
                <td>
                    <div runat="server" id="DefaultMenu">
                        <asp:Button ID="BtnUpdate" runat="server" class="btn btn-success" OnClick="btnUpdateTask_Click" Text="Actualizar" Style="margin-left: 10px" Height="30px" Width="120px" />
                        <asp:Button ID="BtnCancel" runat="server" class="btn btn-danger" OnClick="btnCancel_Click" Text="Cancelar" Style="margin-left: 10px" Height="30px" Width="120px" />
                    </div>

                    <div runat="server" id="ConfirmationMenu">
                        <h4>¿Está seguro que desea actualizar?</h4>

                        <asp:Button ID="Button1" runat="server" class="btn btn-success" OnClick="btnUpdateTaskConfirmation_Click" Text="Aceptar" Style="margin-left: 10px" Height="30px" Width="120px" />
                        <asp:Button ID="Button2" runat="server" class="btn btn-danger" OnClick="btnCancelUpdate_Click" Text="Cancelar" Style="margin-left: 10px" Height="30px" Width="120px" />
                    </div>

                </td>

                <td>
                    <asp:Label ID="lbMessage" runat="server" Text="La tarea ha sido actualizada correctamente." ForeColor="Blue" Visible="False"></asp:Label>
                </td>

            </tr>

        </table>

    </div>

</asp:Content>
