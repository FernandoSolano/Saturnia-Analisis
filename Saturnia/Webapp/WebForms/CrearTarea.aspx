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
                                <label>Proyecto</label>
                                <asp:DropDownList ID="DdlProject" runat="server" Style="margin-left: 65px; margin-bottom: 20px;" Width="200px">
                                </asp:DropDownList>
                            </div>
                            <div>
                                <label>Categoría</label>
                                <asp:DropDownList ID="DdlCategory" runat="server" Style="margin-left: 60px; margin-bottom: 20px" Width="200px">
                                </asp:DropDownList>
                            </div>
                            <div>
                                <label>Fecha de ingreso</label>
                                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="AddDateToList" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="400px">
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

                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Style="margin: 20px 0px 20px 80px; list-style: none">
                                    <asp:ListItem Value="0" style="margin-right: 20px;">Horas regulares</asp:ListItem>
                                    <asp:ListItem Value="1">Horas extra</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div>
                                <label>Tiempo dedicado:</label>
                                <br />
                                <label style="margin-left: 80px">Horas</label>
                                <asp:DropDownList ID="DdlHours" runat="server" Style="margin-left: 30px" Width="60px">
                                </asp:DropDownList>
                                <label style="margin-left: 20px">Minutos</label>
                                <asp:DropDownList ID="DdlMinutes" runat="server" Style="margin-left: 30px" Width="60px">
                                </asp:DropDownList>
                            </div>
                            <div>
                                <label>Descripción</label>
                                <textarea id="TaDescription" name="S1" style="width: 350px; height: 101px; margin-left: 30px; margin-bottom: 20px;"></textarea>

                            </div>
                            <div style="text-align: center">
                                <asp:Button ID="BtnCancel" runat="server" class="btn btn-danger" OnClick="BtnCancel_Click" Text="Cancelar" Style="margin-left: 10px" Height="30px" Width="120px" />
                                <asp:Button ID="BtnAdd" runat="server" class="btn btn-success" OnClick="BtnAdd_Click" Text="Ingresar" Style="margin-left: 10px" Height="30px" Width="120px" />
                                <asp:Button ID="BtnSetData" runat="server" class="btn btn-danger" OnClick="BtnSetData_Click" Text="Limpiar campos" Style="margin-left: 10px" Height="30px" Width="120px" />
                            </div>
                        </div>
                        <div role="tabpanel" class="tab-pane" id="setOfTasks">

                            <h1>Nuevo ingreso por lote</h1>

                            <div>
                                <label>Ingrese las fechas deseadas</label>
                                <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="AddDateToList" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="400px">
                                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                                    <DayStyle Width="14%" />
                                    <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <SelectedDayStyle BackColor="#CC3333" ForeColor="Maroon" />
                                    <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                                    <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                                    <TodayDayStyle BackColor="#CCCC99" />
                                </asp:Calendar>

                                <asp:Button ID="BtnAddDate" runat="server" class="btn btn-basic" Text=">>" />
                                <asp:ListBox ID="Lbdates" runat="server"></asp:ListBox>
                            </div>

                            <div>
                                <label>Proyecto</label>
                                <asp:DropDownList ID="DdlProjectSoT" runat="server" Style="margin-left: 65px; margin-bottom: 20px;" Width="200px">
                                </asp:DropDownList>
                            </div>
                            <div>
                                <label>Categoría</label>
                                <asp:DropDownList ID="DdlCategorySoT" runat="server" Style="margin-left: 60px; margin-bottom: 20px" Width="200px">
                                </asp:DropDownList>
                            </div>
                            <div>

                                <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" Style="margin: 20px 0px 20px 80px; list-style: none">
                                    <asp:ListItem Value="0" style="margin-right: 20px;">Horas regulares</asp:ListItem>
                                    <asp:ListItem Value="1">Horas extra</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div>
                                <label>Tiempo dedicado:</label>
                                <br />
                                <label style="margin-left: 80px">Horas</label>
                                <asp:DropDownList ID="DdlHoursSoT" runat="server" Style="margin-left: 30px" Width="60px">
                                </asp:DropDownList>
                                <label style="margin-left: 20px">Minutos</label>
                                <asp:DropDownList ID="DdlMinutesSoT" runat="server" Style="margin-left: 30px" Width="60px">
                                </asp:DropDownList>
                            </div>
                            <div>
                                <label>Descripción</label>
                                <textarea id="TaDescription2" name="S1" style="width: 350px; height: 101px; margin-left: 30px; margin-bottom: 20px;"></textarea>

                            </div>
                            <div style="text-align: center">
                                <asp:Button ID="BtnCancelSoT" runat="server" class="btn btn-danger" OnClick="BtnCancel_Click" Text="Cancelar" Style="margin-left: 10px" Height="30px" Width="120px" />
                                <asp:Button ID="BtnAddSoT" runat="server" class="btn btn-success" OnClick="BtnAdd_Click" Text="Ingresar" Style="margin-left: 10px" Height="30px" Width="120px" />
                                <asp:Button ID="BtnSetDataSoT" runat="server" class="btn btn-danger" OnClick="BtnSetData_Click" Text="Limpiar campos" Style="margin-left: 10px" Height="30px" Width="120px" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
