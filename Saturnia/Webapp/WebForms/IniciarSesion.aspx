<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IniciarSesion.aspx.cs" Inherits="Webapp.WebForms.IniciarSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Iniciar sesión</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.css" rel="stylesheet" />

    <webopt:BundleReference runat="server" Path="~/Content/css" />

</head>
<body class="background">
    <form id="form1" runat="server">
        <div class="panel panel-transparent col-md-4 col-md-offset-4">
            <div class="panel-heading">
                <img src="../Images/image.png" id="logo" />
                <asp:Label ID="LblTitle" runat="server" Text="Iniciar sesión" Font-Size="X-Large" ForeColor="White"></asp:Label>
            </div>
            <div class="panel-body">
                <div class="form-group" style="text-align: center">
                    <asp:Label ID="LblNickname" runat="server" Text="Nombre de usuario: " Font-Bold="True"></asp:Label>
                    <asp:TextBox ID="TxtNickname" runat="server"></asp:TextBox>
                </div>
                <div class="form-group" style="text-align: center">
                    <asp:Label ID="LblPassword" runat="server" Text="Contraseña:" Font-Bold="True"></asp:Label>
                    <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" Style="margin-left: 48px"></asp:TextBox>
                </div>
                <div class="form-group" style="text-align: center">
                    <asp:Button ID="BtnLogin" runat="server" Text="Iniciar sesión" OnClick="BtnLogin_Click" class="btn btn-basic" Style="background-color: #333333; margin-right: 10px; width: 200px;" ForeColor="White" />
                    <asp:Button ID="BtnCancel" runat="server" Text="Cancelar" class="btn btn-danger" OnClick="BtnCancel_Click" />
                </div>
                <div class="form-group" style="text-align: center">
                    <asp:Label ID="LblMessage" runat="server" ForeColor="#990000"></asp:Label>
                </div>
            </div>
        </div>
    </form>
    <div class="container body-content col-md-6 col-md-offset-3">

        <footer style="position: absolute; bottom: 0; background-color:#333333">
            <p>&copy; <%: DateTime.Now.Year %> - Saturnia</p>
        </footer>
    </div>
</body>
</html>
