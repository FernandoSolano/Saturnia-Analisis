<%@ Page Title="Buscar Tarea" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarTarea.aspx.cs" Inherits="Webapp.WebForms.BuscarTarea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Buscar Tarea</h1>
    <div id="filters">
        <input type="checkbox" id="cbUser" onchange="FadeForm(this,'User')" > <Label class="cb" ID="lblUserCB" >Colaborador</Label>
        <input type="checkbox" id="cbCategory" onchange="FadeForm(this,'Category')" > <Label class="cb" ID="lblCategoryCB" >Categor&iacute;a</Label>
        <input type="checkbox" id="cbProject" onchange="FadeForm(this,'Project')" > <Label class="cb" ID="lblProjectCB" >Proyecto</Label>
        
    </div>
    <div id="areaUser">
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
                    <asp:Button ID="btnSearchUser" OnClick="btnSearchUser_Click" runat="server" Text="Buscar colaborador" class="btn btn-danger" />
                </td>
            </tr>
        </table>
        <!--Fin de table-->
        <asp:HiddenField ID="hdnUser" runat="server" Value="0" /> <!-- Hidden field de usuario -->
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
    </div>
    <div id="areaCategory">
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
        <!--Inicio de asp:Table-->
        <asp:Table ID="resultCategoryTable" runat="server" Visible="false" CssClass="results">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell CssClass="results">
                    Nombre
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>
    <div id="areaProject">
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
        <!--Inicio de asp:Table-->
        <asp:Table ID="resultProjectTable" runat="server" Visible="false" CssClass="results">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell CssClass="results">
                    Proyecto
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>
    <div id="resultsPlace">
        <!--Inicio de update panel para resultados de tarea-->
        <asp:UpdatePanel ID="UPTaskResults" runat="server">
            <ContentTemplate>
                <fieldset>
                    <!--Label de mensaje mostrado mientras se buscan tareas-->
                    <asp:Label ID="TaskSearchingMessage" runat="server" Visible="false" Text="Buscando tareas, un momento por favor" ForeColor="Blue"></asp:Label>
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
                                    Acci&oacute;n
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
    </div>
    <!--Div para buscar tareas-->
    <div class="fixDate" align="center">
        <h2 class="fixDate">Rango de fechas</h2>
        &nbsp;<label class="fixDate">De:</label>&nbsp;<asp:TextBox ID="txtFrom" TextMode="Date" runat="server"></asp:TextBox>
        &nbsp;<label class="fixDate">A:</label>&nbsp;<asp:TextBox ID="txtTo" TextMode="Date" runat="server"></asp:TextBox>&nbsp;<br /><br />
        <asp:Button ID="btnSearchTask" runat="server" Text="Buscar Tarea" CssClass="btn btn-danger" OnClientClick="FadeAllAreas();" OnClick="btnSearchTask_Click" />&nbsp; <asp:Button ID="btnCancel" class="btn btn-danger" runat="server" Text="Cancelar" /><br />
        &nbsp;
    </div>
    <!--Fin de Div para buscar tareas-->

    <script>

        /**
         * Funcion "Document ready"
         * En las primeras 3 instrucciones, oculta los div con id 'searchUserForm' , 'searchProjectForm' & 'searchCategoryForm'
         */
        $(document).ready(function () {
            $('#areaUser').hide();
            $('#areaProject').hide();
            $('#areaCategory').hide();
            $('[data-toggle="tooltip"]').tooltip();
        });

        /**
         * Esta funcion hace visible o invisible un area en base a un checkbox recibido y al nombre del area.
         * @param {checkBox} checkBox
         * @param {string} form
         */
        function FadeForm(checkBox, entity) {
            if (checkBox.checked) {
                $('#area' + entity).fadeIn('slow');
            } else {
                $('#area' + entity).fadeOut('slow');
                document.getElementById('MainContent_hdn' + entity).value = 0; //Eliminar el valor del hidden.
            }
        }
        /**
         * Metodo que oculta todas las areas de filtros de forma agradable visualmente.
         */
        function FadeAllAreas(){
            $('#areaUser').fadeOut('slow');
            $('#areaCategory').fadeOut('slow');
            $('#areaProject').fadeOut('slow');
        }

        /**
         * Este metodo recibe el nombre de  la entidad y el id de dicha entidad, para guardarlo en el
         * hidden field correspondiente.
         * @param {entity} string
         * @param {id} Integer
         */
        function FillHidden(entity, id) {
            document.getElementById('MainContent_hdn' + entity).value = id;
        }
    </script>
</asp:Content>