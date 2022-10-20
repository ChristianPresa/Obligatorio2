<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UsuarioMP.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style1 {
        text-align: center;
    }
    .auto-style4 {
        text-align: center;
    }
    .auto-style5 {
        width: 596px;
        height: 28px;
    }
    .auto-style6 {
        text-align: center;
        height: 28px;
    }
    .auto-style7 {
        height: 28px;
    }
    .auto-style8 {
        width: 596px;
        height: 28px;
        text-align: center;
    }
    .auto-style9 {
        text-align: left;
    }
    .auto-style10 {
        font-size: larger;
    }
    .auto-style11 {
        color: #FF0000;
    }
    .auto-style12 {
        font-weight: bold;
    }
        .auto-style13 {
            width: 190px;
        }
        .auto-style14 {
            text-align: center;
            font-weight: bold;
            width: 190px;
        }
        .auto-style15 {
            height: 28px;
            width: 190px;
        }
        .auto-style16 {
            width: 190px;
            height: 28px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;">
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style4">
                    <strong>
                    <asp:Label ID="lblTitulo" runat="server" Text="Modificar Usuario" CssClass="auto-style10"></asp:Label>
                    </strong>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style14"></td>
                <td class="auto-style6"></td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">
                    <strong>
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
                    </strong>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtUsuario" runat="server" Width="470px"></asp:TextBox>
                </td>
                <td>
                    <strong>
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="186px" CssClass="auto-style12" OnClick="btnLimpiar_Click" />
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="auto-style13">
                    <strong>
                    <asp:Label ID="lblPassword" runat="server" Text="Contraseña:"></asp:Label>
                    </strong>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtPassword" runat="server" Width="470px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15">
                    <strong>
                    <asp:Label ID="lblMail" runat="server" Text="Mail:"></asp:Label>
                    </strong>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtMail" runat="server" Width="470px"></asp:TextBox>
                </td>
                <td class="auto-style9"></td>
            </tr>
            <tr>
                <td class="auto-style13">
                    <strong>
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre Completo:"></asp:Label>
                    </strong>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtNomCompleto" runat="server" Width="470px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style16"></td>
                <td class="auto-style6">
                    <strong>
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" Width="210px" CssClass="auto-style12" OnClick="btnModificar_Click" />
                    </strong>
                </td>
                <td class="auto-style7"></td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style4">
                    <strong>
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" Width="210px" CssClass="auto-style12" OnClick="btnEliminar_Click" style="height: 26px" />
                    </strong>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style4">
                    <asp:LinkButton ID="lnkVolver" runat="server" PostBackUrl="~/PaginaPrincipal.aspx">Volver...</asp:LinkButton>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style4">
                    <strong>
                    <asp:Label ID="lblError" runat="server" CssClass="auto-style11"></asp:Label>
                    </strong>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

