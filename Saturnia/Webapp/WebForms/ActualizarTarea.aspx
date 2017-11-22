<%@ Page Title="" Language="C#" MasterPageFile="~/SiteCollaborator.Master" AutoEventWireup="true" CodeBehind="ActualizarTarea.aspx.cs" Inherits="Webapp.WebForms.ActualizarTarea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class=" col-xs-20 col-sm-16 col-md-11 col-lg-6  col-centered">
                <!-- Nav tabs -->
                <div class="card">
                
                    <!-- Tab panes -->

                    <div class="tab-content">
                        <div role="tabpanel" class="tab-pane active" id="singleTask">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <fieldset style="width: 637px; margin-right: 12px">
                                        <h1 style="height: 51px; margin-top: 4px">Actualizar</h1>
                                       
                                        <div>
                                            <label>Fecha de ingreso</label>
                                            <table>
                                                <tr>
                                                    <td style="width: 369px">
                                                        <asp:Calendar ID="CdDate" runat="server" BackColor="White" BorderColor="Maroon" Width="375px">
                                                            <DayHeaderStyle BackColor="#990000" Font-Bold="True" Font-Size="7pt" ForeColor="Silver" Height="10pt" />
                                                            <DayStyle Width="14%" />
                                                            <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                                                            <OtherMonthDayStyle ForeColor="#999999" />
                                                            <SelectedDayStyle BackColor="#CC3333" ForeColor="Maroon" />
                                                            <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                                                            <TitleStyle BackColor="#252525" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                                                            <TodayDayStyle BackColor="#CCCC99" />
                                                        </asp:Calendar>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>

                                        <div>
                                            <label>Tipo de horas:</label>

                                            <asp:RadioButtonList ID="rblList" runat="server" RepeatDirection="Horizontal" Style="margin: 9px 0px 20px 4px; list-style: none" AutoPostBack="True">
                                                <asp:ListItem Value="0">Horas regulares</asp:ListItem>
                                                <asp:ListItem Value="1">Horas extra</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <div>
                                            <label>Tiempo dedicado:</label>
                                            <br />
                                            <asp:UpdatePanel ID="UpTime" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <fieldset>
                                                        <label style="margin-left: 50px">Horas</label>
                                                        <asp:TextBox ID="tbHours" runat="server" TextMode="Number" Height="20px" Width="59px"></asp:TextBox>
                                                        <label style="margin-left: 20px">Minutos</label>
                                                        <asp:DropDownList ID="ddlMinutes" runat="server" Height="20px" Width="59px" >
                                                            <asp:ListItem>00</asp:ListItem>
                                                            <asp:ListItem>30</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </fieldset>
                                                </ContentTemplate>
                                                                                          
                                            </asp:UpdatePanel>
                                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                             <asp:Label ID="lbHours" runat="server" ForeColor="Black" Style="margin-top: 10px"></asp:Label>
    
                                        </div>
                                        <div style="margin-top: 10px">
                                            <label>Descripción</label>
                                            <asp:TextBox ID="tbDescription" runat="server" Height="101px" TextMode="MultiLine" Width="350px" Style="margin-left: 9px; margin-bottom: 20px;"></asp:TextBox>

                                        </div>
                                    </fieldset>
                                </ContentTemplate>
                            
                            </asp:UpdatePanel>

                            <div style="text-align: center">

                                <div runat="server" id="DefaultMenu">
                                    <asp:Button ID="BtnUpdate" runat="server" class="btn btn-success" OnClick="btnUpdateTask_Click" Text="Actualizar" Style="margin-left: 10px" Height="30px" Width="120px" />
                                    <asp:Button ID="BtnCancel" runat="server" class="btn btn-danger" OnClick="btnCancel_Click" Text="Cancelar" Style="margin-left: 10px" Height="30px" Width="120px" />   
                                </div>

                                <div runat="server" id="ConfirmationMenu">
                                    <h4>¿Está seguro que desea actualizar?</h4>

                                    <asp:Button ID="Button1" runat="server" class="btn btn-success" OnClick="btnUpdateTaskConfirmation_Click" Text="Aceptar" Style="margin-left: 10px" Height="30px" Width="120px" />
                                    <asp:Button ID="Button2" runat="server" class="btn btn-danger" OnClick="btnCancelUpdate_Click" Text="Cancelar" Style="margin-left: 10px" Height="30px" Width="120px" />
                                </div>

                                <asp:Label ID="lbMessage" runat="server" Text="La tarea ha sido actualizada correctamente." ForeColor="Blue" Visible="False"></asp:Label>
                

                                 <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                     
                                </asp:UpdatePanel>
                                

                            </div>
                        </div>
         
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
