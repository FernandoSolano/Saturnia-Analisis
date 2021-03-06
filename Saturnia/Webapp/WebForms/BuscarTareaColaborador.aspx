﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteCollaborator.Master" AutoEventWireup="true" CodeBehind="BuscarTareaColaborador.aspx.cs" Inherits="Webapp.WebForms.BuscarTareaColaborador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Gestión de tareas</h1>
    <div align="center">
        <h2>
            <label>Crear tarea</label>
        </h2>
        <asp:LinkButton ID="HLCreateTask" runat="server" CssClass="btn btn-danger">Ir a crear</asp:LinkButton>   
    </div>
    <br />
    <!--Div para buscar tareas-->
    <div class="fixDate">
        <h2 class="fixDate"><label>Buscar entre mis tareas</label></h2>
        <p>
            <label class="fixDate">
                Para editar, duplicar o eliminar una de sus tareas, primero debe buscarla.
            </label>
        </p>
        <input type="checkbox" class="results" id="cbCategory" onchange="FadeForm(this,'Category')" > <Label for="cbCategory" class="fixDate" ID="lblCategoryCB" data-toggle="tooltip" title="Limitar los resultados a una categoría" ><span></span>Categor&iacute;a</Label>&nbsp;&nbsp;
        <input type="checkbox" class="results" id="cbProject" onchange="FadeForm(this,'Project')" > <Label for="cbProject" class="fixDate" ID="lblProjectCB" data-toggle="tooltip" title="Limitar los resultados a uno de mis proyectos" ><span></span>Mis proyectos</Label> <br />
        <h2 class="fixDate">Rango de fechas</h2>
        &nbsp;<label class="fixDate">De:</label>&nbsp;<asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
        &nbsp;<label class="fixDate">A:</label>&nbsp;<asp:TextBox ID="txtTo" runat="server"></asp:TextBox>&nbsp;<br /><br />
        <asp:Button ID="btnSearchTask" runat="server" Text="Buscar" CssClass="btn btn-danger" OnClientClick="ActionsBeforeSearch()" OnClick="btnSearchTask_Click" />&nbsp; <asp:Button ID="btnCancel" class="btn btn-danger" runat="server" Text="Cancelar" OnClick="btnCancel_Click" /><br />
        &nbsp;
    </div>
    <!--Fin de Div para buscar tareas-->
    <div id="areaCategory"><!--Area category-->
        <div id="beforeCategory"><br /><br /></div>
        <h1>
            Categor&iacute;a
        </h1>
        <p>Ingrese un nombre de una categoría, si lo desea puede ser solo parte del nombre, si no ingresa texto se mostrarán <b>todas</b> las categorías.</p>
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
                                Filtrar por la categor&iacute;a
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
        <p>Ingrese un nombre de un proyecto, si lo desea puede ser solo parte del nombre, si no ingresa texto se mostrarán <b>todos</b> los proyectos en los que <b>usted</b> está laborando.</p>
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
    <div id="filters"><br /><br /></div>
    <div id="resultsPlace"> <!--Results place-->
        <!--Inicio de update panel para resultados de tarea-->
        <asp:UpdatePanel ID="UPTaskResults" runat="server">
            <ContentTemplate>
                <fieldset>
                    <!--Inicio de tabla de resultados de tarea-->
                        <asp:Table ID="resultTaskTable" runat="server" Visible="false" CssClass="results">
                            <asp:TableHeaderRow>
                                <asp:TableHeaderCell CssClass="results">
                                    Descripci&oacute;n
                                </asp:TableHeaderCell>
                                <asp:TableHeaderCell CssClass="results">
                                    Fecha
                                </asp:TableHeaderCell>
                                <asp:TableHeaderCell CssClass="results">
                                    Proyecto
                                </asp:TableHeaderCell>
                                <asp:TableHeaderCell CssClass="results">
                                    Horas
                                </asp:TableHeaderCell>
                                <asp:TableHeaderCell CssClass="results">
                                    Horas extra
                                </asp:TableHeaderCell>
                                <asp:TableHeaderCell CssClass="results">
                                    Acciones    
                                </asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                    <!--Fin de tabla de resultados de tarea-->
                </fieldset>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSearchTask" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <!--Fin de update panel para resultados de tarea-->
    </div> <!--Fin de results place-->

    <script src="../Content/jquerry-ui-1.11.0.js"></script>
    <script>
        /**
        * Funcion "Document ready"
        */
        $(document).ready(function () {
            //Ocultamos las áreas de las entidades a filtrar.
            $('#areaProject').hide();
            $('#areaCategory').hide();
            //Ocultamos los botones de reseleccionar filtro.
            $('#reselectProject').hide();
            $('#reselectCategory').hide();
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

            //Si el checkbox de user no está marcado: Borramos el hidden, esto porque si ya se había realizado una
            //búsqueda en el pasado, el hidden queda "sucio" con el valor anterior. Esto se hace para los 3 checkbox de filtro.
            if ($('#cbCategory').is(":checked") == false) {
                document.getElementById('MainContent_hdnCategory').value = 0;
            }
            if ($('#cbProject').is(":checked") == false) {
                document.getElementById('MainContent_hdnProject').value = 0;
            }

            //IMPORTANTE Esta sentencia debe estar depués de los if, sino se des enmarcarán todos los chekbox y los if
            //anterioes hacen 0 todos los hidden.
            UnmarkAllCheck();
            FadeInElement('#resultsPlace');
            goTo('filters', 750); //Al final desplazamos al lugar de los resultados con un retardo de 1.25 segundos
        }

        /**
         * Metodo que oculta todas las areas de filtros de forma agradable visualmente.
         */
        function FadeAllAreas() {
            FadeOutElement('#areaCategory');
            FadeOutElement('#areaProject');
            FadeOutElement('#resultsPlace');
        }

        /**
         * Método que oculta todos los "Cambiar entidad filtrada".
         */
        function FadeAllReselect() {
            FadeOutElement('#reselectCategory');
            FadeOutElement('#reselectProject');
        }

        /**
         * Método que desenmarca todos los checkbox.
         */
        function UnmarkAllCheck() {
            $('#cbProject').attr("checked", false);
            $('#cbCategory').attr("checked", false);
        }
    </script>
    <script src="../Scripts/SearchTask.js">
    </script>

</asp:Content>
