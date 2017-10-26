<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearTarea.aspx.cs" Inherits="Webapp.WebForms.CrearTarea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <!-- Nav tabs -->
                <div class="card">
                    <ul class="nav nav-tabs" role="tablist">

                        <li role="presentation" class="active"><a href="#singleTask" aria-controls="singleTask" role="tab" data-toggle="tab">Nueva tarea</a></li>
                        <li role="presentation"><a href="#setOfTasks" aria-controls="setOfTasks" role="tab" data-toggle="tab">Nuevo ingreso por lote</a></li>

                    </ul>

                    <!-- Tab panes -->
                    <div class="tab-content">
                        <div role="tabpanel" class="tab-pane active" id="singleTask">
                            <h1>Nuevo Ingreso</h1>
                            <div>
                                Proyecto<asp:DropDownList ID="DdlProject" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div>
                                Categoría<asp:DropDownList ID="DdlCategory" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div>
                                Fecha de ingreso
                            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" SelectedDate="10/26/2017 10:00:30" TitleFormat="Month" Width="400px">
                                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                                <DayStyle Width="14%" />
                                <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#CC3333" ForeColor="Maroon" />
                                <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                                <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                                <TodayDayStyle BackColor="#CCCC99" />
                                </asp:Calendar>
                            </div>
                            <div>
                                <asp:RadioButton ID="RbRegularHours" runat="server" OnCheckedChanged="RadioButton1_CheckedChanged" Text="Horas regulares" />
                                <asp:RadioButton ID="RbExtraHours" runat="server" OnCheckedChanged="RadioButton2_CheckedChanged" Text="Horas extra" />
                            </div>
                            <div>
                                Tiempo dedicado:
                                Horas
                                <asp:DropDownList ID="DdlHours" runat="server">
                                  
                                </asp:DropDownList>
                                Minutos
                                <asp:DropDownList ID="DdlMinutes" runat="server">
                                    
                                </asp:DropDownList>
                            </div>
                            <div>
                                Descripción<textarea id="TaDescription" name="S1" style="width: 323px; height: 101px"></textarea>

                            </div>
                            <div style="text-align: center">
                                <asp:Button ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" Text="Cancelar"  />
                                <asp:Button ID="BtnAdd" runat="server" OnClick="BtnAdd_Click" Text="Ingresar" />
                                <asp:Button ID="BtnSetData" runat="server" OnClick="BtnSetData_Click" Text="Limpiar campos" />
                            </div>
                        </div>
                        <div role="tabpanel" class="tab-pane" id="setOfTasks">

                             <h1>Nuevo ingreso por lote</h1>

                             <div>
                                Ingrese las fechas deseadas
                            <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" SelectedDate="10/26/2017 10:00:30" TitleFormat="Month" Width="400px">
                                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                                <DayStyle Width="14%" />
                                <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#CC3333" ForeColor="Maroon" />
                                <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                                <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                                <TodayDayStyle BackColor="#CCCC99" />
                                </asp:Calendar>
                                 <asp:Button ID="BtnAdddate" runat="server" Text=">>" />
                                 <asp:ListBox ID="Lbdates" runat="server"></asp:ListBox>
                            </div>

                            <div>
                                Proyecto<asp:DropDownList ID="DdlProjectSoT" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div>
                                Categoría<asp:DropDownList ID="DdlCategorySoT" runat="server">
                                </asp:DropDownList>
                            </div>
                           
                            <div>
                                <asp:RadioButton ID="RbregularHoursSoT" runat="server" OnCheckedChanged="RadioButton1_CheckedChanged" Text="Horas regulares" />
                                <asp:RadioButton ID="RbextraHoursSoT" runat="server" OnCheckedChanged="RadioButton2_CheckedChanged" Text="Horas extra" />
                            </div>
                            <div>
                                Tiempo dedicado:
                                Horas
                                <asp:DropDownList ID="DddlHoursSoT" runat="server">
                                </asp:DropDownList>
                                Minutos
                                <asp:DropDownList ID="DdlMinutesSoT" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div>
                                Descripción<textarea id="TaDescriptionSoT" name="S1" style="width: 323px; height: 101px"></textarea>

                            </div>
                            <div>
                                <asp:Button ID="BtnCancelSoT" runat="server" OnClick="BtnCancel_Click" Text="Cancelar" />
                                <asp:Button ID="BtnAddSoT" runat="server" OnClick="BtnAdd_Click" Text="Ingresar" />
                                <asp:Button ID="BtnSetdataSoT" runat="server" OnClick="BtnSetData_Click" Text="Limpiar campos" />
                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
