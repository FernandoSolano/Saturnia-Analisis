<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActualizarProyecto.aspx.cs" Inherits="Webapp.WebForms.ActualizarProyecto1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>

        <table>
            <h2 style="width: 372px">
                <asp:Label ID="Label1" runat="server" Text="Datos del proyecto"></asp:Label>

            </h2>

            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Nombre:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbName" runat="server" Width="180px"></asp:TextBox>
                </td>

            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Descripcion:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbDescription" runat="server" Height="49px" TextMode="MultiLine" Width="182px"></asp:TextBox>
                </td>
            </tr>
           
            <tr>
                <td>
                       <asp:Label ID="Label2" runat="server" Text="Horas estimadas:"></asp:Label> 
                </td>
                <td>
                    <asp:TextBox ID="tbEstimatedHours" runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Fecha de inicio(mes/día/año):"></asp:Label> 
                
                </td>

                <td>
             <asp:Calendar ID="CdStartDate" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px" >
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
                    <asp:Label ID="Label6" runat="server" Text="Fecha de finalización(mes/día/año):"></asp:Label> 
                </td>

                <td>
                <asp:Calendar ID="CdEndDate" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px" >
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                    </asp:Calendar>
                    </td>
                <td>

                    <asp:Label ID="lbEndDateError" runat="server" ForeColor="#0099FF" Text="Label" Visible="False"></asp:Label>

                </td>

            </tr>

             <tr>
                <td>
                    <asp:Button ID="btnUpdateProject" runat="server" OnClick="btnUpdateProject_Click" Text="Actualizar" />
                    
                    <asp:Label ID="lb" runat="server" Text="Label"></asp:Label>
                </td>

            </tr>

        </table>

    </div>
</asp:Content>
