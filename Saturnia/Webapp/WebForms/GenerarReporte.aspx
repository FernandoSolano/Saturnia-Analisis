﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenerarReporte.aspx.cs" Inherits="Webapp.WebForms.GenerarReporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="formGenerateReport">
        <h1>Generar reporte</h1>
        Para editar, duplicar o eliminar una tarea, primero debe buscarla.
        La b&uacute;squeda puede ser filtrada seg&uacute;n lo necesite.<br />

        <!--Div para buscar tareas-->
        <div class="fixDate">
            <h2 class="fixDate">Rango de fechas</h2>
            &nbsp;<label class="fixDate">De:</label>&nbsp;<asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
            &nbsp;<label class="fixDate">A:</label>&nbsp;<asp:TextBox ID="txtTo" runat="server"></asp:TextBox>&nbsp;<br /><br />
            <asp:Button ID="btnSearchTask" runat="server" Text="Buscar" CssClass="btn btn-danger" OnClientClick="ActionsBeforeSearch()" OnClick="btnSearchTask_Click"/>&nbsp; <asp:Button ID="btnCancel" class="btn btn-danger" runat="server" Text="Cancelar" OnClick="btnCancel_Click" /><br />
            &nbsp;
        </div>
        <!--Fin de Div para buscar tareas-->

        <div id="filters">
            <h2>Filtrar por:</h2>
            <input type="checkbox" class="custom" id="cbUser" onchange="FadeForm(this,'User')" > <Label for="cbUser" ID="lblUserCB" ><span></span>Colaborador</Label>&nbsp;&nbsp;
            <input type="checkbox" class="custom" id="cbCategory" onchange="FadeForm(this,'Category')" > <Label for="cbCategory" ID="lblCategoryCB" ><span></span>Categor&iacute;a</Label>&nbsp;&nbsp;
            <input type="checkbox" class="custom" id="cbProject" onchange="FadeForm(this,'Project')" > <Label for="cbProject" ID="lblProjectCB" ><span></span>Proyecto</Label>
        </div>
    
        <div id="areaUser"><!--User area-->
            <div id="beforeUser"><br /><br /></div>
            <h1>
                Colaborador
            </h1>
            <!--Inicio de table-->
            <table>
                <tr>
                    <td>
                        <label>Nombre: </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnSearchUser" OnClick="btnSearchUser_Click" runat="server" Text="Buscar" class="btn btn-danger" />
                    </td>
                </tr>
            </table>
            <!--Fin de table-->
            <asp:HiddenField ID="hdnUser" runat="server" Value="0" /> <!-- Hidden field de usuario -->
            <br />
            <!--Inicio de asp:UpdatePanel-->
            <asp:UpdatePanel ID="UPUser" runat="server">
                <ContentTemplate>
                    <fieldset>
                        <!-- Inicio de tabla de resultados para usuario -->
                        <asp:Table ID="resultUserTable" runat="server" CssClass="results" Visible="false">
                            <asp:TableHeaderRow>
                                <asp:TableHeaderCell CssClass="results">
                                Nombre
                            </asp:TableHeaderCell>
                                <asp:TableHeaderCell CssClass="results">
                                Apellidos
                            </asp:TableHeaderCell>
                                <asp:TableHeaderCell CssClass="results">
                                Filtrar por el colaborador
                            </asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                        <!-- Fin de tabla de resultados para usuario -->
                    </fieldset>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSearchUser" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            <!--Fin de asp:UpdatePanel-->
        </div> <!--Fin de User area-->
        <div id="reselectUser"><!--Reselect user-->
            <br />
            <label>Est&aacute; filtrando por el colaborador:</label> <label style="color:#D9534F" id="labelReselectUser"></label><br />
            <button type="button" id="changeUser" class="btn btn-danger" onclick="reselectFilter('User')">Deseo cambiar el usuario filtrado</button>
        </div><!--Fin de reselect user-->
        <div id="areaCategory"><!--Area category-->
            <div id="beforeCategory"><br /><br /></div>
            <h1>
                Categor&iacute;a
            </h1>
            <table>
                <tr>
                    <td>
                        <label>Nombre: </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnSearchCategory" runat="server" Text="Buscar" class="btn btn-danger" OnClick="btnSearchCategory_Click" />
                    </td>
                </tr>
            </table>
            <!--Fin de table-->
            <asp:HiddenField ID="hdnCategory" runat="server" Value="0" /> <!-- Hidden field de categoria -->
            <br />
            <!--Inicio de asp:UpdatePanel-->
            <asp:UpdatePanel ID="UPCategory" runat="server">
                <ContentTemplate>
                    <fieldset>
                        <!-- Tabla de resultados para categoria -->
                        <asp:Table ID="resultCategoryTable" runat="server" Visible="false" CssClass="results">
                            <asp:TableHeaderRow>
                                <asp:TableHeaderCell CssClass="results">
                                    Nombre
                                </asp:TableHeaderCell>
                                <asp:TableHeaderCell CssClass="results">
                                    Filtrar por la categoría
                                </asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                        <!-- Fin de tabla de resultados para categoria -->
                    </fieldset>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSearchCategory" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            <!--Fin de asp:UpdatePanel-->
        </div><!--Fin de area category-->
        <div id="reselectCategory"><!--Reselect category-->
            <br />
            <label>Est&aacute; filtrando por la categor&iacute;a:</label> <label style="color:#D9534F" id="labelReselectCategory"></label><br />
            <button type="button" id="changeCategory" class="btn btn-danger" onclick="reselectFilter('Category')">Deseo cambiar la categor&iacute;a filtrada</button>
        </div><!--Fin de reselect category-->
        <div id="areaProject"><!--Area project-->
            <div id="beforeProject"><br /><br /></div>
            <h1>
                Proyecto
            </h1>
            <table>
                <tr>
                    <td>
                        <label>Nombre: </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtProjectName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnSearchProject" class="btn btn-danger" runat="server" Text="Buscar" OnClick="btnSearchProject_Click" />
                    </td>
                </tr>
            </table>
            <!--Fin de table-->
            <asp:HiddenField ID="hdnProject" runat="server" Value="0" /> <!-- Hidden field de proyecto -->
            <br />
            <!--Inicio de asp:UpdatePanel-->
            <asp:UpdatePanel ID="UPProject" runat="server">
                <ContentTemplate>
                    <fieldset>
                        <!-- Tabla de resultados para proyecto -->
                        <asp:Table ID="resultProjectTable" runat="server" Visible="false" CssClass="results">
                            <asp:TableHeaderRow>
                                <asp:TableHeaderCell CssClass="results">
                                    Proyecto
                                </asp:TableHeaderCell>
                                <asp:TableHeaderCell CssClass="results">
                                    Filtrar por el proyecto
                                </asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                        <!-- Fin de tabla de resultados para proyecto -->
                    </fieldset>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSearchProject" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            <!--Fin de asp:UpdatePanel-->
        </div><!--Fin de area project-->
        <div id="reselectProject"><!--Reselect project-->
            <br />
            <label>Est&aacute; filtrando por el proyecto:</label> <label style="color:#D9534F" id="labelReselectProject"></label><br />
            <button type="button" id="changeProject" class="btn btn-danger" onclick="reselectFilter('Project')">Deseo cambiar el proyecto filtrado</button>
        </div><!--Fin de reselect project-->
    </div>
    <div id="reportPlace"> <!--Report place-->
        <table id="report">
            <tr>
                <td id="reportTd">
                    <img id="logo" src="../Images/image.png" alt="XXX_Logo" align="Left" />
                </td>
                <td>
                    <div id="userName" class="fixDate">
                        <asp:Label ID="lblUserName" ForeColor="Wheat" runat="server"></asp:Label>
                    </div>
                </td>
            </tr>
        </table>
        <div id="rerportRange" class="fixDate">
            <font color="wheat">Reporte de horas laboradas por proyecto, colaborador y categoría</font><br />
            <font color="wheat">De la fecha: 08/08/1995 hasta el 08/08/2017</font>
        </div>
         
        <br />
        <div id="reportTableDiv" align="center">
            <!--Inicio de update panel para resultados de tarea-->
            <asp:UpdatePanel ID="UPReport" runat="server">
                <ContentTemplate>
                    <fieldset>
                        <!--Inicio de tabla de resultados de tarea-->
                            <asp:Table ID="reportTable" runat="server" CssClass="results">
                                <asp:TableHeaderRow>
                                    <asp:TableHeaderCell CssClass="results">
                                        Proyecto
                                    </asp:TableHeaderCell>
                                    <asp:TableHeaderCell CssClass="results">
                                        Colaborador
                                    </asp:TableHeaderCell>
                                    <asp:TableHeaderCell CssClass="results">
                                        Categoría
                                    </asp:TableHeaderCell>
                                    <asp:TableHeaderCell CssClass="results" ColumnSpan="2">
                                        Horas
                                    </asp:TableHeaderCell>
                                    <asp:TableHeaderCell CssClass="results">
                                        Total
                                    </asp:TableHeaderCell>
                                </asp:TableHeaderRow>
                                <asp:TableRow>
                                    <asp:TableCell CssClass="results">
                                        Análisis y diseño de softare
                                    </asp:TableCell>
                                    <asp:TableCell CssClass="results">
                                        Esteban Sanabria.
                                    </asp:TableCell>
                                    <asp:TableCell></asp:TableCell>
                                    <asp:TableCell CssClass="results">
                                        120 regulares
                                    </asp:TableCell>
                                    <asp:TableCell CssClass="results">
                                        60 extra
                                    </asp:TableCell>
                                    <asp:TableCell CssClass="results">
                                        180
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell CssClass="results">
                                        Aresep
                                    </asp:TableCell>
                                    <asp:TableCell CssClass="results">
                                        Esteban Sanabria.
                                    </asp:TableCell>
                                    <asp:TableCell></asp:TableCell>
                                    <asp:TableCell CssClass="results">
                                        40 regulares
                                    </asp:TableCell>
                                    <asp:TableCell CssClass="results">
                                        10 extra
                                    </asp:TableCell>
                                    <asp:TableCell CssClass="results">
                                        50
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        <!--Fin de tabla de resultados de tarea-->
                    </fieldset>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSearchTask" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            <!--Fin de update panel para resultados de tarea-->
        </div>
    </div> <!--Fin de report place-->
    <div id="reportActions" align="center">
        <br />
        <input id="btnExport" type="button" value="Exportar" class="btn btn-danger" onclick="FadeInExportFormat();" />&nbsp;&nbsp;<input id="btnNewReport" type="button" value="Nuevo" class="btn btn-danger" onclick="NewReport();" />&nbsp;&nbsp;<asp:Button ID="btnBackToTheFuture" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
        <br /><br /><input id="btnPdf" type="button" value="PDF" class="btn btn-default" style="color:red" />&nbsp;<input id="btnExcel" type="button" value="Excel" class="btn btn-success" />
    </div>

    <script src="../Content/jquerry-ui-1.11.0.js"></script> <!--Include ui jquery-->
    <script src="../Scripts/SearchTask.js"></script> <!--Metodos en común-->
    <script>
        /**
         * Funcion "Document ready"
         */
        $(document).ready(function () {
            //Ocultamos las áreas de las entidades a filtrar.
            $('#areaUser').hide();
            $('#areaProject').hide();
            $('#areaCategory').hide();
            //Ocultamos los botones de reseleccionar filtro.
            $('#reselectUser').hide();
            $('#reselectProject').hide();
            $('#reselectCategory').hide();
            //Ocultamos el area de reporte
            $('#reportPlace').hide();
            //Ocultamos el area de los botones de acciones con reporte
            $('#reportActions').hide();
            $('#btnPdf').hide();
            $('#btnExcel').hide();
            //Permitimos el "tooltip" para efectos visuales.
            $('[data-toggle="tooltip"]').tooltip();
        });

        /**
         * Metodo que se ejecuta antes de buscar tareas, hace unas validaciones y oculta areas innecesarias para los
         * resultados.
         */
        function ActionsBeforeSearch() {
            FadeAllAreas(); //Ocultamos todas las areas.
            FadeAllReselect(); //Ocultamos todos los botones de "reseleccionar"
            FadeOutElement('#formGenerateReport');

            //Si el checkbox de user no está marcado: Borramos el hidden, esto porque si ya se había realizado una
            //búsqueda en el pasado, el hidden queda "sucio" con el valor anterior. Esto se hace para los 3 checkbox de filtro.
            if ($('#cbUser').is(":checked") == false) {
                document.getElementById('MainContent_hdnUser').value = 0;
            }
            if ($('#cbCategory').is(":checked") == false) {
                document.getElementById('MainContent_hdnCategory').value = 0;
            }
            if ($('#cbProject').is(":checked") == false) {
                document.getElementById('MainContent_hdnProject').value = 0;
            }

            //IMPORTANTE Esta sentencia debe estar depués de los if, sino se des enmarcarán todos los chekbox y los if
            //anterioes hacen 0 todos los hidden.
            UnmarkAllCheck();
            FadeInReportAndReportActions();
        }

        /**
         * Metodo que oculta todas las areas de filtros de forma agradable visualmente.
         */
        function FadeAllAreas() {
            FadeOutElement('#areaUser');
            FadeOutElement('#areaCategory');
            FadeOutElement('#areaProject');
        }

        /**
         * Método que oculta todos los "Cambiar entidad filtrada".
         */
        function FadeAllReselect() {
            FadeOutElement('#reselectUser');
            FadeOutElement('#reselectCategory');
            FadeOutElement('#reselectProject');
        }

        function FadeInExportFormat() {
            FadeInElement('#btnPdf');
            FadeInElement('#btnExcel');
        }

        function FadeInReportAndReportActions() {
            FadeInElement('#reportPlace');
            FadeInElement('#reportActions');
        }

        function FadeOutReportAndReportActions() {
            FadeOutElement('#reportPlace');
            FadeOutElement('#reportActions');
        }

        function FadeOutExportFormat() {
            FadeOutElement('#btnPdf');
            FadeOutElement('#btnExcel');
        }

        function NewReport() {
            FadeOutExportFormat();
            FadeOutReportAndReportActions();
            FadeInElement('#formGenerateReport');
        }

        /**
         * Método que desenmarca todos los checkbox.
         */
        function UnmarkAllCheck() {
            $('#cbProject').attr("checked", false);
            $('#cbCategory').attr("checked", false);
            $('#cbUser').attr("checked", false);
        }

    </script>
</asp:Content>
