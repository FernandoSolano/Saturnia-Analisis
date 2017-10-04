<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IniciarSesion.aspx.cs" Inherits="Webapp.WebForms.IniciarSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Iniciar sesión</title>
    <webopt:BundleReference runat="server" Path="~/Content/css" />
</head>
<body class="body_login">
    <form id="form1" runat="server">
        <div class="form panel panel-default col-md-4 col-md-offset-4">
            <asp:Label ID="LblTitle" runat="server" Text="Iniciar sesión" Font-Size="X-Large" CssClass="col-md-6 col-md-offset-3"></asp:Label>
            <div class="form-group">
                <asp:Label ID="LblNickname" runat="server" Text="Nombre de usuario: " CssClass="col-md-6"></asp:Label>
                <asp:TextBox ID="TxtNickname" runat="server" CssClass="col-md-6"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="LblPassword" runat="server" Text="Contraseña:" CssClass="col-md-6"></asp:Label>
                <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" CssClass="col-md-6"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="BtnLogin" runat="server" Text="Iniciar sesión" OnClick="BtnLogin_Click" CssClass="btn-success col-md-6 col-md-offset-6" />
            </div>
        </div>
    </form>
</body>
</html>
