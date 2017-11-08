<%@ Page Title="Buscar Tarea" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarTarea.aspx.cs" Inherits="Webapp.WebForms.BuscarTarea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Buscar Tarea</h1>
    ¿O desea <asp:HyperLink ID="HLCreateTask" runat="server">crear</asp:HyperLink> una tarea?
    <div id="filters">
        <h2>Filtrar por:</h2>
        <input type="checkbox" class="custom" id="cbUser" onchange="FadeForm(this,'User')" > <Label for="cbUser" ID="lblUserCB" ><span></span>Colaborador</Label>&nbsp;&nbsp;
        <input type="checkbox" class="custom" id="cbCategory" onchange="FadeForm(this,'Category')" > <Label for="cbCategory" ID="lblCategoryCB" ><span></span>Categor&iacute;a</Label>&nbsp;&nbsp;
        <input type="checkbox" class="custom" id="cbProject" onchange="FadeForm(this,'Project')" > <Label for="cbProject" ID="lblProjectCB" ><span></span>Proyecto</Label>
    </div>
    <div id="areaUser"><!--User area-->
        <h1>
            Colaborador
        </h1>
        <!--Inicio de table-->
        <table>
            <tr>
                <td>
                    <label>Colaborador: </label>
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnSearchUser" OnClick="btnSearchUser_Click" runat="server" Text="Buscar Colaborador" class="btn btn-danger" />
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
                            Filtrar
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
        <label style="color:blue">Est&aacute; filtrando por el colaborador:</label> <label id="labelReselectUser"></label><br />
        <button type="button" id="changeUser" class="btn btn-info" onclick="reselectFilter('User')">Deseo cambiar el usuario filtrado</button>
    </div><!--Fin de reselect user-->
    <div id="areaCategory"><!--Area category-->
        <h1>
            Categor&iacute;a
        </h1>
        <table>
            <tr>
                <td>
                    <label>Categoria: </label>
                </td>
                <td>
                    <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnSearchCategory" runat="server" Text="Buscar Categoría" class="btn btn-danger" OnClick="btnSearchCategory_Click" />
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
                                Filtrar
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
        <label style="color:blue">Est&aacute; filtrando por la categor&iacute;a:</label> <label id="labelReselectCategory"></label><br />
        <button type="button" id="changeCategory" class="btn btn-info" onclick="reselectFilter('Category')">Deseo cambiar la categor&iacute;a filtrada</button>
    </div><!--Fin de reselect category-->
    <div id="areaProject"><!--Area project-->
        <h1>
            Proyecto
        </h1>
        <table>
            <tr>
                <td>
                    <label>Proyecto: </label>
                </td>
                <td>
                    <asp:TextBox ID="txtProjectName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnSearchProject" class="btn btn-danger" runat="server" Text="Buscar proyecto" OnClick="btnSearchProject_Click" />
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
                                Filtrar
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
        <label style="color:blue">Est&aacute; filtrando por el proyecto:</label> <label id="labelReselectProject"></label><br />
        <button type="button" id="changeProject" class="btn btn-info" onclick="reselectFilter('Project')">Deseo cambiar el proyecto filtrado</button>
    </div><!--Fin de reselect project-->
    <br />
    <div id="resultsPlace"> <!--Results place-->
        <!--Inicio de update panel para resultados de tarea-->
        <asp:UpdatePanel ID="UPTaskResults" runat="server">
            <ContentTemplate>
                <fieldset>
                    <!--Inicio de tabla de resultados de tarea-->
                        <asp:Table ID="resultTaskTable" runat="server" Visible="false" CssClass="results">
                            <asp:TableHeaderRow>
                                <asp:TableHeaderCell>
                                    Descripci&oacute;n
                                </asp:TableHeaderCell>
                                <asp:TableHeaderCell>
                                    Fecha
                                </asp:TableHeaderCell>
                                <asp:TableHeaderCell>
                                    Proyecto
                                </asp:TableHeaderCell>
                                <asp:TableHeaderCell>
                                    Horas
                                </asp:TableHeaderCell>
                                <asp:TableHeaderCell>
                                    Horas extra
                                </asp:TableHeaderCell>
                                <asp:TableHeaderCell>
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
    <!--Div para buscar tareas-->
    <div class="fixDate" align="center">
        <h2 class="fixDate">Rango de fechas</h2>
        &nbsp;<label class="fixDate">De:</label>&nbsp;<asp:TextBox ID="txtFrom" TextMode="Date" runat="server"></asp:TextBox>
        &nbsp;<label class="fixDate">A:</label>&nbsp;<asp:TextBox ID="txtTo" TextMode="Date" runat="server"></asp:TextBox>&nbsp;<br /><br />
        <asp:Button ID="btnSearchTask" runat="server" Text="Buscar Tarea" CssClass="btn btn-danger" OnClientClick="ActionsBeforeSearch()" OnClick="btnSearchTask_Click" />&nbsp; <asp:Button ID="btnCancel" class="btn btn-danger" runat="server" Text="Cancelar" /><br />
        &nbsp;
    </div>
    <!--Fin de Div para buscar tareas-->

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
            //Permitimos el "tooltip" para efectos visuales.
            $('[data-toggle="tooltip"]').tooltip();
        });

        /**
         * Esta funcion hace visible o invisible un area en base a un checkbox recibido y al nombre del area. Este método
         * debe ejecutarse al darle click a un checkbox que esté enlazado a este método.
         * @param {checkBox} checkBox es el checkbox que llama al método.
         * @param {string} entity es el nombre de la entidad sobre la que se trabaja.
         */
        function FadeForm(checkBox, entity) {
            //Si el checkbox está seleccionado
            if (checkBox.checked) {
                FadeInElement('#area' + entity); //Mostramos el area de la entidad deseada.
            } else {
                //Si no esta seleccionado
                FadeOutElement('#area' + entity); //Oculta el area de la entidad
                FadeOutElement('#reselect' + entity); //Oculta la opción de cambiar la entidad si esta fuera visible.
                document.getElementById('MainContent_hdn' + entity).value = 0; //Eliminar el valor del hidden.
            }
        }

        /**
         * Método que hace visible un elemento por id, de forma lenta y gradual.
         * @param {element} String es el id del elemento a mostrar.
         */
        function FadeInElement(element) {
            $(element).fadeIn('slow');
        }

        /**
         * Método que oculta un elemento por id, de forma lenta y gradual.
         * @param {element} String es el id del elemento a ocultar.
         */
        function FadeOutElement(element) {
            $(element).fadeOut('slow');
        }

        /**
         * Metodo que oculta todas las areas de filtros de forma agradable visualmente.
         */
        function FadeAllAreas(){
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

        /**
         * Método que desenmarca todos los checkbox.
         */
        function UnmarkAllCheck() {
            $('#cbUser').attr("checked", false);
            $('#cbProject').attr("checked", false);
            $('#cbCategory').attr("checked", false);
        }
        /**
         * Metodo que se ejecuta antes de buscar tareas, hace unas validaciones y oculta areas innecesarias para los
         * resultados.
         */
        function ActionsBeforeSearch() {
            FadeAllAreas(); //Ocultamos todas las areas.
            FadeAllReselect(); //Ocultamos todos los botones de "reseleccionar"

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
        }

        /**
         * Este metodo recibe el nombre de  la entidad y el id de dicha entidad, para guardarlo en el
         * hidden field correspondiente.
         * @param {entity} string
         * @param {id} Integer
         */
        function FillHidden(entity, id, filteredBy) {
            document.getElementById('MainContent_hdn' + entity).value = id;
            FadeOutElement('#area' + entity);
            document.getElementById("labelReselect"+entity).innerHTML = filteredBy;
            FadeInElement('#reselect' + entity);
        }

        /**
         * Metodo que muestra nuevamente el area de un filtro y oculta el botón "cambiar entidad filtrada".
         * @param {filter} String es el nombre de la entidad del filtro a mostrar de nuevo y el nombre del "reselect" a ocultar.
         */
        function reselectFilter(filter) {
            FadeOutElement('#reselect' + filter);
            FadeInElement('#area' + filter);
        }
    </script>
</asp:Content>