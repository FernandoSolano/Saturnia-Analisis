<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenerarReporte.aspx.cs" Inherits="Webapp.WebForms.GenerarReporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="formGenerateReport">
        <h1>Generar reporte</h1>
        Para editar, duplicar o eliminar una tarea, primero debe buscarla.
        La b&uacute;squeda puede ser filtrada seg&uacute;n lo necesite.<br />

        <!--Div para generar reporte-->
        <div class="fixDate">
            <h2 class="fixDate">Filtrar por:</h2>
            <input type="checkbox" class="results" id="cbUser" onchange="ActivateFilter(this,'User')" > <Label for="cbUser" ID="lblUserCB" class="fixDate" ><span></span>Colaborador</Label>&nbsp;&nbsp;
            <input type="checkbox" class="results" id="cbCategory" onchange="ActivateFilter(this,'Category')" > <Label for="cbCategory" ID="lblCategoryCB" class="fixDate" ><span></span>Categor&iacute;a</Label>&nbsp;&nbsp;
            <input type="checkbox" class="results" id="cbProject" onchange="ActivateFilter(this,'Project')" > <Label for="cbProject" ID="lblProjectCB" class="fixDate" ><span></span>Proyecto</Label>
            <h2 class="fixDate">Rango de fechas</h2>
            &nbsp;<label class="fixDate">De:</label>&nbsp;<asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
            &nbsp;<label class="fixDate">A:</label>&nbsp;<asp:TextBox ID="txtTo" runat="server"></asp:TextBox><br /><br />
            <asp:Button ID="btnGenerateReport" runat="server" Text="Buscar" CssClass="btn btn-danger" data-toggle="tooltip" title="Generar reporte" OnClientClick="ActionsBeforeSearch()" OnClick="btnGenerateReport_Click"/>&nbsp; <asp:Button ID="btnCancel" class="btn btn-danger" runat="server" Text="Cancelar" data-toggle="tooltip" title="Volver a inicio." OnClick="btnCancel_Click" /><br />
            &nbsp;
        </div>
        <!--Fin de Div para generar reporte-->
        <asp:HiddenField ID="hdnUser" runat="server" Value="0" /> <!-- Hidden field de usuario -->
        <asp:HiddenField ID="hdnCategory" runat="server" Value="0" /> <!-- Hidden field de categoria -->
        <asp:HiddenField ID="hdnProject" runat="server" Value="0" /> <!-- Hidden field de proyecto -->
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
                                    <asp:TableCell CssClass="results">
                                        Curso universitario
                                    </asp:TableCell>
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
                                    <asp:TableCell CssClass="results">
                                        Trabajo.
                                    </asp:TableCell>
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
                    <asp:AsyncPostBackTrigger ControlID="btnGenerateReport" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            <!--Fin de update panel para resultados de tarea-->
        </div>
    </div> <!--Fin de report place-->
    <div id="reportActions" align="center">
        <br />
        <input id="btnExport" type="button" value="Exportar" class="btn btn-danger" onclick="FadeInExportFormat();" />&nbsp;&nbsp;<input id="btnNewReport" data-toggle="tooltip" title="Generar otro reporte." type="button" value="Nuevo" class="btn btn-danger" onclick="NewReport();" />&nbsp;&nbsp;<asp:Button ID="btnBackToTheFuture" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancel_Click" data-toggle="tooltip" title="Volver a inicio." />
        <br /><br /><input id="btnPdf" type="button" value="PDF" data-toggle="tooltip" title="Exportar en pdf" class="btn btn-default" style="color:red" />&nbsp;<input id="btnExcel" type="button" value="Excel" data-toggle="tooltip" title="Exportar en hoja de calculo" class="btn btn-success" />
    </div>

    <script src="../Content/jquerry-ui-1.11.0.js"></script> <!--Include ui jquery-->
    <script src="../Scripts/GenerateReport.js"></script> <!--Metodos en común-->
    <script>
        /**
         * Metodo que se ejecuta antes de buscar tareas, hace unas validaciones y oculta areas innecesarias para los
         * resultados.
         */
        function ActionsBeforeSearch() {
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
         * Método que desenmarca todos los checkbox.
         */
        function UnmarkAllCheck() {
            $('#cbProject').attr("checked", false);
            $('#cbCategory').attr("checked", false);
            $('#cbUser').attr("checked", false);
        }

    </script>
    <script src="../Content/printThis.js"></script><!--Inclusión de "printThis()"-->
    <script>
        $('#btnPdf').click(function () {
            $('#reportPlace').printThis();
        });
    </script>
</asp:Content>
