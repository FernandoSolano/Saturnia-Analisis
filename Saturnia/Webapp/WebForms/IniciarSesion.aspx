<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IniciarSesion.aspx.cs" Inherits="Webapp.WebForms.IniciarSesion2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Iniciar sesión</title>
</head>
<body class="body_login">
    <form id="form1" runat="server">
        <div class="pannel">
            <br />
            <asp:Label ID="LblTitle" runat="server" Text="Iniciar sesión" Font-Size="X-Large"></asp:Label>
            <br />
            <br />
            <asp:Label ID="LblNickname" runat="server" Text="Nombre de usuario: "></asp:Label>

            <asp:TextBox ID="TxtNickname" runat="server" Style="margin-left: 100px" Width="230px"></asp:TextBox>
            <br />
            <asp:Label ID="LblPassword" runat="server" Text="Contraseña:"></asp:Label>

            <asp:TextBox ID="TxtPassword" runat="server" Style="margin-left: 151px" Width="230px" TextMode="Password"></asp:TextBox>
            <br />

            <asp:Button ID="BtnLogin" runat="server" Text="Inciar sesion" Width="111px" OnClick="BtnLogin_Click" />
            <br />
        </div>
    </form>
</body>
</html>
