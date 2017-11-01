<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarTarea.aspx.cs" Inherits="Webapp.WebForms.BuscarTarea" %>

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
        <!--Inicio de asp:Table-->
        <asp:Table ID="resultUserTable" runat="server" Visible="false" CssClass="results">
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
        <!--Fin de asp:Table-->
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
        <!--Inicio de asp:Table-->
        <asp:Table ID="resultProjectTable" runat="server" Visible="false" CssClass="results">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell CssClass="results">
                    Proyecto
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BTEliminar" runat="server" BackColor="#990000" ForeColor="White" Height="38px" OnClick="BTEliminar_Click" Text="Eliminar" Width="137px" />
    </div>
    <div class="fixDate" align="center">
        <h2 class="fixDate">Rango de fechas</h2>
        &nbsp;<label class="fixDate">De:</label>&nbsp;<asp:TextBox ID="txtFrom" TextMode="Date" runat="server"></asp:TextBox>
        &nbsp;<label class="fixDate">A:</label>&nbsp;<asp:TextBox ID="txtTo" TextMode="Date" runat="server"></asp:TextBox>&nbsp;<br /><br />
        <asp:Button ID="btnSearchTask" runat="server" Text="Buscar Tarea" class="btn btn-danger" />&nbsp; <asp:Button ID="btnCancel" class="btn btn-danger" runat="server" Text="Cancelar" /><br />
        &nbsp;
    </div>

    <script>

        /**
         * Funcion "Document ready"
         * En las primeras 3 instrucciones, oculta los div con id 'searchUserForm' , 'searchProjectForm' & 'searchCategoryForm'
         */
        $(document).ready(function () {
            $('#areaUser').hide();
            $('#areaProject').hide();
            $('#areaCategory').hide();
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
            }
        }
    </script>
</asp:Content>