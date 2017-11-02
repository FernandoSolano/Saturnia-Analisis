<%@ Page Title="" Language="C#" MasterPageFile="~/SiteCollaborator.Master" AutoEventWireup="true" CodeBehind="BuscarTareaColaborador.aspx.cs" Inherits="Webapp.WebForms.BuscarTareaColaborador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Tareas realizadas</h1>
    </div>
    <div style="margin-top: 20px;">
        <asp:GridView ID="GridViewTasks" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="gridView_PageIndexChanging" AllowPaging="True" PageSize="5">
            <Columns>
                <asp:BoundField DataField="Date" DataFormatString="{0:d/MM/yyyy}" HeaderText="Fecha" />
                <asp:BoundField DataField="Project.Name" HeaderText="Proyecto" />
                <asp:BoundField DataField="Category.Name" HeaderText="Categoría" />
                <asp:BoundField DataField="Hours" HeaderText="Cantidad de horas" />
                <asp:BoundField DataField="Description" HeaderText="Descripción" />
                <asp:TemplateField HeaderText="Horas extra">
                    <ItemTemplate>
                        <%# (Boolean.Parse(Eval("ExtraHours").ToString())) ? "Sí" : "No" %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <a href="ActualizarTarea.aspx?id=<%#Eval("Id")%>">Editar</a><br />
                        <a href="DuplicarTarea.aspx?id=<%#Eval("Id")%>">Duplicar</a><br />
                        <a href="EliminarTarea.aspx?id=<%#Eval("Id")%>">Eliminar</a><br />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerSettings Mode="NumericFirstLast" FirstPageText="Inicio" LastPageText="Fin" NextPageText="Siguiente" PageButtonCount="5" PreviousPageText="Anterior" />
            <PagerStyle Font-Underline="True" HorizontalAlign="Center" />
        </asp:GridView>
    </div>

    <br />

    <asp:Button ID="BtnCreate" runat="server" CausesValidation="False" class="btn btn-primary" Text="Crear nuevo registro" OnClick="BtnCreate_Click" />

</asp:Content>
