<%@ Page Title="" Language="C#" MasterPageFile="~/SiteCollaborator.Master" AutoEventWireup="true" CodeBehind="BuscarTareaColaborador.aspx.cs" Inherits="Webapp.WebForms.BuscarTareaColaborador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Tareas realizadas:</h1>
        <asp:Label ID="LblCollaboratorName" runat="server" Text="Nombre del colaborador: " Font-Size="Medium"></asp:Label>
        <asp:Button ID="BtnSearch" runat="server" class="btn btn-primary" Text="Ver mis aportes" OnClick="BtnSearch_Click" />
    </div>
    <div style="margin-top:20px;">
        <asp:GridView ID="GridViewTasks" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewTasks_SelectedIndexChanged" OnRowCommand="GridViewTask_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Código de la tarea" />
                <asp:BoundField DataField="Date" HeaderText="Fecha de ingreso" />
                <asp:BoundField DataField="Project.Name" HeaderText="Proyecto" />
                <asp:BoundField DataField="Category.Name" HeaderText="Categoría" />
                <asp:BoundField DataField="Hours" HeaderText="Horas ingresadas" />
                <asp:BoundField DataField="Description" HeaderText="Descripción" />
                <asp:BoundField DataField="ExtraHours" HeaderText="Horas extra" />
                <asp:ButtonField ButtonType="Link" CommandName="Editar" Text="Editar" HeaderText="Acciones" />
                <asp:ButtonField ButtonType="Link" CommandName="Editar" Text="Eliminar" HeaderText="Acciones" />

            </Columns>


        </asp:GridView>
    </div>

</asp:Content>
