<%@ Page Title="" Language="C#" MasterPageFile="~/SiteCollaborator.Master" AutoEventWireup="true" CodeBehind="BuscarTareaColaborador.aspx.cs" Inherits="Webapp.WebForms.BuscarTareaColaborador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Tareas realizadas:</h1>
        <asp:Label ID="LblCollaboratorName" runat="server" Text="Nombre del colaborador: " Font-Size="Medium"></asp:Label>
        <asp:Button ID="BtnSearch" runat="server" class="btn btn-primary" Text="Ver mis aportes" OnClick="BtnSearch_Click" />
    </div>
    <div style="margin-top:20px;">
        <asp:GridView ID="GridViewTasks" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Código de la tarea" />
                <asp:BoundField DataField="Date" HeaderText="Fecha de ingreso" />
                <asp:BoundField DataField="Project.Name" HeaderText="Proyecto" />
                <asp:BoundField DataField="Category.Name" HeaderText="Categoría" />
                <asp:BoundField DataField="Hours" HeaderText="Horas ingresadas" />
                <asp:BoundField DataField="Description" HeaderText="Descripción" />
                <asp:BoundField DataField="ExtraHours" HeaderText="Horas extra" />

                <asp:TemplateField HeaderText="Acciones" >
                    <ItemTemplate>
                        <asp:Button ID="BtnEditar" runat="server" class="btn btn-danger" Text="Editar"  />
                        <asp:Button ID="BtnEliminar" runat="server" class="btn btn-danger" Text="Eliminar"/>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>


        </asp:GridView>
    </div>

</asp:Content>
