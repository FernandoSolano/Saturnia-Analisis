<%@ Page Title="" Language="C#" MasterPageFile="~/SiteCollaborator.Master" AutoEventWireup="true" CodeBehind="CrearTarea.aspx.cs" Inherits="Webapp.WebForms.CrearTarea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class=" col-xs-20 col-sm-16 col-md-11 col-lg-6  col-centered">
                <!-- Nav tabs -->
                <div class="card">
                    <ul class="nav nav-tabs" role="tablist">

                        <li role="presentation" class="active"><a href="#singleTask" aria-controls="singleTask" role="tab" data-toggle="tab">Nueva tarea</a></li>
                        <li role="presentation"><a href="#setOfTasks" aria-controls="setOfTasks" role="tab" data-toggle="tab">Nuevo ingreso por lote</a></li>

                    </ul>

                    <!-- Tab panes -->

                    <div class="tab-content">
                        <div role="tabpanel" class="tab-pane active" id="singleTask">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <fieldset>
                                        <h1>Nuevo Ingreso</h1>
                                        <div>
                                            <label>Proyecto</label>
                                            <asp:DropDownList ID="DdlProject" runat="server" class="btn btn-secundary dropdown-toggle" Style="background-color:  #e6e6e6; margin-left: 65px; margin-bottom: 20px;" Width="200px">
                                            </asp:DropDownList>
                                        </div>
                                        <div>
                                            <label>Categoría</label>
                                            <asp:DropDownList ID="DdlCategory" runat="server" class="btn btn-secundary dropdown-toggle" Style="background-color:  #e6e6e6; margin-left: 60px; margin-bottom: 20px" Width="200px">
                                            </asp:DropDownList>
                                        </div>
                                        <div>
                                            <label>Fecha de ingreso</label>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="DdlMonth" runat="Server" class="btn btn-secundary dropdown-toggle" Style="background-color:  #e6e6e6; margin-bottom: 5px" OnSelectedIndexChanged="SetCalendar" AutoPostBack="true"></asp:DropDownList>
                                                        <asp:DropDownList ID="DdlYear" runat="Server" class="btn btn-secundary dropdown-toggle" Style="background-color:  #e6e6e6; margin-bottom: 5px" OnSelectedIndexChanged="SetCalendar" AutoPostBack="true"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="AddDateToList" BackColor="White" BorderColor="Maroon" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="400px" OnDayRender="DisableDays">
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

                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Style="margin: 20px 0px 20px 80px; list-style: none" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True">
                                                <asp:ListItem Value="0" style="margin-right: 20px;" Selected="True">Horas regulares</asp:ListItem>
                                                <asp:ListItem Value="1">Horas extra</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <div>
                                            <label>Tiempo dedicado:</label>
                                            <br />
                                            <asp:UpdatePanel ID="UpTime" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <fieldset>
                                                        <label style="margin-left: 80px">Horas</label>
                                                        <asp:DropDownList ID="DdlHours" runat="server" class="btn btn-secundary dropdown-toggle" Style="background-color:  #e6e6e6; margin-left: 20px" Width="70px">
                                                        </asp:DropDownList>
                                                        <label style="margin-left: 20px">Minutos</label>
                                                        <asp:DropDownList ID="DdlMinutes" runat="server" class="btn btn-secundary dropdown-toggle" Style="background-color:  #e6e6e6; margin-left: 20px" Width="70px">
                                                            <asp:ListItem>00</asp:ListItem>
                                                            <asp:ListItem>30</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </fieldset>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="RadioButtonList1" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div style="margin-top: 10px">
                                            <label>Descripción</label>
                                            <asp:TextBox ID="TbDescription" runat="server" Height="101px" TextMode="MultiLine" Width="350px" Style="margin-left: 30px; margin-bottom: 20px;"></asp:TextBox>

                                        </div>
                                    </fieldset>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="BtnAdd" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="BtnCancel" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="BtnSetData" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <div style="text-align: center">
                                <asp:Button ID="BtnCancel" runat="server" class="btn btn-danger" OnClick="BtnCancel_Click" Text="Cancelar" Style="margin-left: 5px" Height="30px" Width="115px" />
                                <asp:Button ID="BtnAdd" runat="server" class="btn btn-success" OnClick="BtnAdd_Click" Text="Ingresar" Style="margin-left: 5px" Height="30px" Width="115px" />
                                <asp:Button ID="BtnSetData" runat="server" class="btn btn-danger" OnClick="BtnSetData_Click" Text="Limpiar campos" Style="margin-left: 5px" Height="30px" Width="115px" />
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <fieldset>
                                            <asp:Label ID="LblWarning" runat="server" ForeColor="Black" Style="margin-top: 10px"></asp:Label>
                                        </fieldset>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="BtnAdd" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>

                            </div>
                        </div>
                        <div role="tabpanel" class="tab-pane" id="setOfTasks">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <fieldset>
                                        <h1>Nuevo ingreso por lote</h1>

                                        <div>
                                            <label>Ingrese las fechas deseadas</label>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="DdlMonthSoT" runat="Server" class="btn btn-secundary dropdown-toggle" Style="background-color:  #e6e6e6; margin-bottom: 5px" OnSelectedIndexChanged="SetCalendarSoT" AutoPostBack="true"></asp:DropDownList>
                                                        <asp:DropDownList ID="DdlYearSoT" runat="Server" class="btn btn-secundary dropdown-toggle" Style="background-color:  #e6e6e6; margin-bottom: 5px" OnSelectedIndexChanged="SetCalendarSoT" AutoPostBack="true"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="AddDateToList" BackColor="White" BorderColor="Maroon" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="400px" OnDayRender="DisableDays">
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
                                            <asp:UpdatePanel ID="UpDates" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <fieldset>
                                                        <asp:ListBox ID="Lbdates" runat="server" Width="230px" Height="100px" Style="margin-left: 60px; margin-top: 10px; margin-bottom: 10px"></asp:ListBox>
                                                        <asp:Button ID="Btnremove" runat="server" Text="Remover" OnClick="BtnRemove_Click" class="btn btn-warning" Style="margin-left: 10px; margin-top: 10px; margin-bottom: 90px" />
                                                    </fieldset>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="Calendar2" EventName="SelectionChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>

                                        <div>
                                            <label>Proyecto</label>
                                            <asp:DropDownList ID="DdlProjectSoT" runat="server" class="btn btn-secundary dropdown-toggle" Style="background-color:  #e6e6e6; margin-left: 65px; margin-bottom: 20px;" Width="200px">
                                            </asp:DropDownList>
                                        </div>
                                        <div>
                                            <label>Categoría</label>
                                            <asp:DropDownList ID="DdlCategorySoT" runat="server" class="btn btn-secundary dropdown-toggle" Style="background-color:  #e6e6e6; margin-left: 60px; margin-bottom: 20px" Width="200px">
                                            </asp:DropDownList>
                                        </div>
                                        <div>

                                            <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" Style="margin: 20px 0px 20px 80px; list-style: none" AutoPostBack="True">
                                                <asp:ListItem Value="0" style="margin-right: 20px;" Selected="True">Horas regulares</asp:ListItem>
                                                <asp:ListItem Value="1">Horas extra</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <div>
                                            <label>Tiempo dedicado:</label>
                                            <br />
                                            <asp:UpdatePanel ID="UpTimeSoT" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <fieldset>
                                                        <label style="margin-left: 80px">Horas</label>
                                                        <asp:DropDownList ID="DdlHoursSoT" runat="server" class="btn btn-secundary dropdown-toggle" Style="background-color:  #e6e6e6; margin-left: 20px" Width="70px">
                                                        </asp:DropDownList>
                                                        <label style="margin-left: 20px">Minutos</label>
                                                        <asp:DropDownList ID="DdlMinutesSoT" runat="server" class="btn btn-secundary dropdown-toggle" Style="background-color:  #e6e6e6; margin-left: 20px" Width="70px">
                                                            <asp:ListItem>00</asp:ListItem>
                                                            <asp:ListItem>30</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </fieldset>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="RadioButtonList2" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div style="margin-top: 10px">
                                            <label>Descripción</label>&nbsp;
                                            <asp:TextBox ID="TbDescription2" runat="server" Height="101px" TextMode="MultiLine" Width="350px" Style="margin-left: 30px; margin-bottom: 20px;"></asp:TextBox>

                                        </div>
                                    </fieldset>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="BtnAddSoT" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="BtnCancelSoT" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="BtnSetDataSoT" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <div style="text-align: center">
                                <asp:Button ID="BtnCancelSoT" runat="server" class="btn btn-danger" OnClick="BtnCancel_Click" Text="Cancelar" Style="margin-left: 5px" Height="30px" Width="115px" />
                                <asp:Button ID="BtnAddSoT" runat="server" class="btn btn-success" OnClick="BtnAddSoT_Click" Text="Ingresar" Style="margin-left: 5px" Height="30px" Width="115px" />
                                <asp:Button ID="BtnSetDataSoT" runat="server" class="btn btn-danger" OnClick="BtnSetData_Click" Text="Limpiar campos" Style="margin-left: 5px" Height="30px" Width="115px" />
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <fieldset>
                                            <asp:Label ID="LblWarningSoT" runat="server" Style="margin-top: 10px"></asp:Label>
                                        </fieldset>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="BtnAddSoT" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
