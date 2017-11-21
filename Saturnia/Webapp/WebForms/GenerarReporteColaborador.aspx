<%@ Page Title="" Language="C#" MasterPageFile="~/SiteCollaborator.Master" AutoEventWireup="true" CodeBehind="GenerarReporteColaborador.aspx.cs" Inherits="Webapp.WebForms.GenerarReporteColaborador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div id="formGenerateReport">
        <h1>Generar mi reporte</h1>

        <!--Div para generar reporte-->
        <div class="fixDate">
            <h2 class="fixDate">Filtrar por:</h2>
            <input type="checkbox" class="results" id="cbCategory"> <Label for="cbCategory" ID="lblCategoryCB" class="fixDate" data-toggle="tooltip" title="Ordenar reporte por categoría." ><span></span>Categor&iacute;a</Label>&nbsp;&nbsp;
            <input type="checkbox" class="results" id="cbProject"> <Label for="cbProject" ID="lblProjectCB" class="fixDate" data-toggle="tooltip" title="Ordenar reporte por proyecto." ><span></span>Proyecto</Label>
            <h2 class="fixDate">Rango de fechas</h2>
            &nbsp;<label class="fixDate">De:</label>&nbsp;<asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
            &nbsp;<label class="fixDate">A:</label>&nbsp;<asp:TextBox ID="txtTo" runat="server"></asp:TextBox><br /><br />
            <asp:Button ID="btnGenerateReport" runat="server" Text="Generar" CssClass="btn btn-danger" data-toggle="tooltip" title="Generar un reporte" OnClientClick="ActionsBeforeSearch()" OnClick="btnGenerateReport_Click"/>&nbsp; <asp:Button ID="btnCancel" class="btn btn-danger" runat="server" Text="Cancelar" data-toggle="tooltip" title="Volver a inicio." OnClick="btnCancel_Click" /><br />
            &nbsp;
        </div>
        <!--Fin de Div para generar reporte-->
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
            <font color="wheat">Reporte de mis horas laboradas por <label id="lblFilter"></label><br />
                    De la fecha: <label ID="lblReportDateFrom"></label> hasta el <label ID="lblReportDateTo"></label>
            </font> 
        </div>
         
        <br />
        <div id="reportTableDiv" align="center">
            <!--Inicio de update panel para resultados de tarea-->
            <asp:UpdatePanel ID="UPReport" runat="server">
                <ContentTemplate>
                    <fieldset>
                        <!--Inicio de tabla reporte-->
                            <asp:Table ID="reportTable" runat="server" CssClass="results">
                            </asp:Table>
                        <!--Fin de tabla reporte-->
                        <!--Inicio de mensaje de fechas-->
                            <asp:Label ID="lblDateMessage" runat="server" ForeColor="#D9534F" Text="Por favor, seleccione un rango de fechas válido."></asp:Label>
                        <!--Fin de mensaje de fechas-->
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
    <script src="../Content/printThis.js"></script> <!--Inclusión de "printThis()"-->
    <script src="../Scripts/GenerateReport.js"></script> <!--Metodos en común-->
    <script>
        /**
         * Metodo que se ejecuta antes de buscar tareas, hace unas validaciones y oculta areas innecesarias para los
         * resultados.
         */
        function ActionsBeforeSearch() {
            FadeOutElement('#formGenerateReport');
            var message = "";

            //Si el checkbox de user está marcado: Ponemos 1 en el hidden, sino lo "borramos" al poner 0,
            //esto porque si ya se había realizado una búsqueda en el pasado, el hidden queda "sucio" con el valor anterior.
            //Esto se hace para los 3 checkbox de filtro.
            
            document.getElementById('MainContent_hdnCategory').value = ($('#cbCategory').is(":checked") ? (1) : (0) );
            
            document.getElementById('MainContent_hdnProject').value = ($('#cbProject').is(":checked") ? (1) : (0));

            //Si los 3 filtros fueron seleccionados, o si ninguno de los 3 fuerojn seleccionados, se coloca un mensaje indicando que
            //se filtró por los 3, caso contrario preguntamos por cuales sí para mostrar cuales fueron usados en un mensaje.
            if (($('#cbCategory').is(":checked")) && ($('#cbProject').is(":checked"))) {
                document.getElementById('lblFilter').innerHTML = 'proyecto y categoría';
            } else if (!($('#cbCategory').is(":checked")) && !($('#cbProject').is(":checked"))) {
                document.getElementById('lblFilter').innerHTML = 'proyecto y categoría';
            } else {
                
                message += ($('#cbCategory').is(":checked") ? ('categoría y ') : (''));

                message += ($('#cbProject').is(":checked") ? ('proyecto y ') : (''));

                document.getElementById('lblFilter').innerHTML = message.slice(0, -3); //Con esta linea nos deshacemos del ' y '
                //sobrante (Incluídos los espacios).
            }

            //IMPORTANTE Esta sentencia debe estar depués de los if, sino se des enmarcarán todos los chekbox y los if
            //anterioes hacen 0 todos los hidden.
            UnmarkAllCheck();
            document.getElementById('lblReportDateFrom').innerHTML = document.getElementById('MainContent_txtFrom').value;
            document.getElementById('lblReportDateTo').innerHTML = document.getElementById('MainContent_txtTo').value;
            FadeInReportAndReportActions();
        }

        /**
         * Método que desenmarca todos los checkbox.
         */
        function UnmarkAllCheck() {
            $('#cbProject').attr("checked", false);
            $('#cbCategory').attr("checked", false);
        }

    </script>
</asp:Content>
