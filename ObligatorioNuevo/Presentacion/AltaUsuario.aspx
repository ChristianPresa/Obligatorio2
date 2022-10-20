<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AltaUsuario.aspx.cs" Inherits="AltaUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            width: 474px;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            width: 141px;
        }
        .auto-style4 {
            height: 23px;
            width: 141px;
        }
        .auto-style5 {
            width: 474px;
        }
        .auto-style6 {
            height: 23px;
            width: 474px;
        }
        .auto-style7 {
            width: 141px;
            height: 26px;
        }
        .auto-style8 {
            width: 474px;
            height: 26px;
        }
        .auto-style9 {
            height: 26px;
        }
        .auto-style10 {
            font-size: larger;
        }
        .auto-style11 {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <table style="width:100%;">
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style1">
                    <strong>
                    <asp:Label ID="lblTitulo" runat="server" Text="Creacion de Usuario" CssClass="auto-style10"></asp:Label>
                    </strong>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style6"></td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <strong>
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
                    </strong>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtUsuario" runat="server" Width="470px"></asp:TextBox>
                </td>
                <td>
                    <strong>
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="186px" OnClick="btnLimpiar_Click" CssClass="auto-style11" />
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <strong>
                    <asp:Label ID="lblPassword" runat="server" Text="Contraseña:"></asp:Label>
                    </strong>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtPassword" runat="server" Width="470px" TextMode="Password"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <strong>
                    <asp:Label ID="lblMail" runat="server" Text="Mail:"></asp:Label>
                    </strong>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtMail" runat="server" Width="470px"></asp:TextBox>
                </td>
                <td class="auto-style9"></td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <strong>
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre Completo:"></asp:Label>
                    </strong>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtNomCompleto" runat="server" Width="470px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style1">
                    <strong>
                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" Width="210px" OnClick="btnRegistrar_Click" />
                    </strong>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style1">
                    <strong>
                    <asp:LinkButton ID="lnkVolver" runat="server" PostBackUrl="~/Default.aspx">Volver...</asp:LinkButton>
                    </strong>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style1">
                    <strong>
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                    </strong>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
