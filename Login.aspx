<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Arrendamientos.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Login </title>
    <meta charset="UTF-8">
    <link rel="icon" type="image/png" href="/LoginC/Imagenes/home.ico" />
    <link rel="stylesheet" type="text/css" href="/LoginC/Estilo/util.css">
    <link rel="stylesheet" type="text/css" href="/LoginC/Estilo/principal.css">
</head>
<body>
    <div>
        <div class="container-loginteam">
            <div class="wrap-loginteam">
                <div class="loginteam-pic js-tilt" data-tilt>
                    <img src="/assets/img/logo-small.png">
                    <img src="/LoginC/Imagenes/usuario1.png" alt="IMG">
                </div>
                <form class="loginteam-form validate-form" runat="server">
                <span class="loginteam-form-title">Iniciar sesión </span>
                <div class="wrap-input100 validate-input">
                    <input class="input100" type="text" name="email" placeholder="Usuario" runat="server" id="txtUsuario" required>
                    <span class="focus-input100"></span><span class="symbol-input100"><i class="fa fa-envelope" aria-hidden="true"></i></span>
                </div>
                <div class="wrap-input100 validate-input">
                    <input class="input100" type="password" name="pass" runat="server" id="txtPass" placeholder="Contraseña" required>
                    <span class="focus-input100"></span><span class="symbol-input100"><i class="fa fa-lock" aria-hidden="true"></i></span>
                </div>
                <div class="container-loginteam-form-btn">
                    <asp:Button runat="server" ID="BtnAgregar" CssClass="loginteam-form-btn" Text="Ingresar" OnClick="btnAceptar_Click" />
                </div>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                </form>
            </div>
        </div>
    </div>
</body>
</html>
