<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 24px;
        }
        .auto-style2 {
            height: 23px;
            text-align: center;
        }
        .auto-style3 {
            height: 24px;
            text-align: left;
        }
        .auto-style4 {
            text-align: center;
        }
        .auto-style5 {
            font-weight: bold;
        }
        .auto-style6 {
            height: 24px;
            width: 381px;
        }
        .auto-style7 {
            height: 24px;
            text-align: left;
            width: 381px;
        }
        .auto-style8 {
            width: 381px;
        }
        .auto-style9 {
            text-align: center;
            width: 381px;
        }
        .auto-style10 {
            height: 23px;
            text-align: center;
            width: 381px;
        }
        .auto-style11 {
            height: 24px;
            width: 414px;
            text-align: center;
        }
        .auto-style12 {
            height: 24px;
            text-align: left;
            width: 414px;
        }
        .auto-style13 {
            width: 414px;
        }
        .auto-style14 {
            text-align: center;
            width: 414px;
        }
        .auto-style15 {
            height: 23px;
            text-align: center;
            width: 414px;
        }
        .auto-style16 {
            margin-left: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style6">
                <strong>
                <asp:Label ID="lblCantUsu" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp; </strong>
            </td>
            <td class="auto-style11">
                <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="Large" 
                    Text="Bienvenido a su mensajeria"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:GridView ID="GVResultado" runat="server" Height="16px" Width="305px">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">
                <strong><asp:Label ID="lblCantMensajesPriv" runat="server"></asp:Label>
                </strong>
            </td>
            <td class="auto-style12">
                &nbsp;</td>
            <td class="auto-style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">
                <strong><asp:Label ID="lblCantMensajesCom" runat="server"></asp:Label>
                </strong>
            </td>
            <td class="auto-style13">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">
                &nbsp;</td>
            <td class="auto-style14">
                <strong>
                <asp:Label ID="lblUsuairo" runat="server" Text="Usuario:"></asp:Label>
                </strong>
            </td>
            <td class="auto-style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">
                &nbsp;</td>
            <td class="auto-style14">
                <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">
                &nbsp;</td>
            <td class="auto-style14">
                <strong>
                <asp:Label ID="lblContraseña" runat="server" Text="Contraseña:"></asp:Label>
                </strong>
            </td>
            <td class="auto-style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">
                &nbsp;</td>
            <td class="auto-style14">
                <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" CssClass="auto-style16" Width="115px"></asp:TextBox>
            </td>
            <td class="auto-style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">
                &nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            <td class="auto-style14">
                <strong>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="auto-style5" />
                </strong>
            </td>
            <td class="auto-style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">
                &nbsp;</td>
            <td class="auto-style14">
                &nbsp;</td>
            <td class="auto-style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">
                &nbsp;</td>
            <td class="auto-style14">
                <strong>
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" 
                    onclick="btnLimpiar_Click" CssClass="auto-style5" />
                </strong>
            </td>
            <td class="auto-style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10">
                &nbsp;</td>
            <td class="auto-style15">
                &nbsp;</td>
            <td class="auto-style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">
                &nbsp;</td>
            <td class="auto-style14">
                <asp:LinkButton ID="lnkRegistrarse" runat="server" PostBackUrl="~/AltaUsuario.aspx" OnClick="lnkRegistrarse_Click">Registrarse</asp:LinkButton>
            </td>
            <td class="auto-style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">
                &nbsp;</td>
            <td class="auto-style14">
                    <strong>
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                    </strong>
            </td>
            <td class="auto-style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">
                &nbsp;</td>
            <td class="auto-style13">
                &nbsp;</td>
            <td class="auto-style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">
                &nbsp;</td>
            <td class="auto-style13">
                &nbsp;</td>
            <td class="auto-style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">
                &nbsp;</td>
            <td class="auto-style14">
                &nbsp;</td>
            <td class="auto-style4">
                &nbsp;</td>
        </tr>
        </table>
    </form>
</body>
</html>
