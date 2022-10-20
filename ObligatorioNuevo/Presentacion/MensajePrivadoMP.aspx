<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MensajePrivadoMP.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 618px;
        }
        .auto-style2 {
            width: 617px;
        }
        .auto-style3 {
            width: 616px;
        }
        .auto-style4 {
            width: 615px;
            text-align: center;
        }
        .auto-style5 {
            width: 394px;
        }
        .auto-style6 {
            width: 618px;
            text-align: center;
        }
        .auto-style7 {
            width: 616px;
            text-align: center;
        }
        .auto-style8 {
            width: 596px;
            text-align: center;
        }
        .auto-style9 {
            font-weight: bold;
        }
        .auto-style15 {
            width: 524px;
        }
        .auto-style16 {
            width: 176px;
            text-align: right;
        }
        .auto-style18 {
            width: 112px;
        }
        .auto-style21 {
            text-align: left;
        }
        .auto-style22 {
            margin-left: 0px;
        }
        .auto-style23 {
            text-align: center;
        }
        .auto-style24 {
            width: 176px;
            text-align: right;
            height: 26px;
        }
        .auto-style25 {
            text-align: left;
            height: 26px;
        }
        .auto-style26 {
            width: 112px;
            height: 26px;
        }
        .auto-style27 {
            width: 635px;
            text-align: center;
            height: 30px;
        }
        .auto-style28 {
            width: 615px;
            text-align: center;
            font-weight: bold;
            height: 30px;
        }
        .auto-style29 {
            width: 635px;
            text-align: center;
        }
        .auto-style34 {
            font-size: x-large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="auto-style29">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style23" colspan="3">
                <strong>
                <asp:Label ID="lblTitulo" runat="server" Text="Mensajes Privados" CssClass="auto-style34"></asp:Label>
                </strong>
            </td>
        </tr>
        <tr>
            <td class="auto-style29">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style29">&nbsp;</td>
            <td class="auto-style8">
                <strong>
                <asp:Label ID="lblAsunto" runat="server" Text="Asunto:"></asp:Label>
                </strong>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style27">
            </td>
            <td class="auto-style28">
                <asp:TextBox ID="txtAsunto" runat="server" Width="463px"></asp:TextBox>
            </td>
            <td class="auto-style2" rowspan="9">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style29">
                &nbsp;</td>
            <td class="auto-style7">
                <strong>
                <asp:Label ID="lblTexto" runat="server" Text="Texto:"></asp:Label>
                </strong>
            </td>
        </tr>
        <tr>
            <td class="auto-style29">&nbsp;</td>
            <td class="auto-style7">
                <asp:TextBox ID="txtMensaje" runat="server" Height="127px" Width="461px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style29">
                <strong>
                <br />
                <asp:Label ID="lblReceptores" runat="server" Text="Enviar a :"></asp:Label>
                </strong>
            </td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style29">
                <table style="width:100%;">
                    <tr>
                        <td colspan="3"><strong>
                <asp:Button ID="btnAregar" runat="server" Text="Agregar" Width="111px" OnClick="btnAregar_Click" CssClass="auto-style9" Height="21px" />
                &nbsp;<asp:TextBox ID="txtReceptores" runat="server" Width="205px"></asp:TextBox>
                </strong></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                <asp:ListBox ID="lbReceptores" runat="server" Width="328px"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td><strong><asp:Button ID="brnBorrar" runat="server" Text="Borrar" Width="121px" OnClick="brnBorrar_Click" CssClass="auto-style9" />
                </strong>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
            <td class="auto-style6">
                <table class="auto-style15">
                    <tr>
                        <td colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style23" colspan="3"><strong>FECHA DE CADUCIDAD</strong></td>
                    </tr>
                    <tr>
                        <td class="auto-style24"><strong>DATE:</strong></td>
                        <td class="auto-style25">
                <asp:TextBox ID="txtFecha" runat="server" OnTextChanged="txtFecha_TextChanged" Width="130px"></asp:TextBox>
                        </td>
                        <td class="auto-style26"></td>
                    </tr>
                    <tr>
                        <td class="auto-style16">
                <strong>
                <asp:Label ID="lblHora" runat="server" Text="TIME:"></asp:Label>
                </strong></td>
                        <td class="auto-style21">
                <asp:TextBox ID="txtHora" runat="server" OnTextChanged="txtHora_TextChanged" CssClass="auto-style22" Width="130px"></asp:TextBox>
                        </td>
                        <td class="auto-style18">&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="auto-style29">&nbsp;</td>
            <td class="auto-style8">
                &nbsp;
                </td>
        </tr>
        <tr>
            <td class="auto-style29">&nbsp;</td>
            <td class="auto-style7">
                <strong>
                <asp:Button ID="lblLimpiar" runat="server" OnClick="lblLimpiar_Click" Text="Limpiar Todo" Width="187px" CssClass="auto-style9" />
                </strong>
            </td>
        </tr>
        <tr>
            <td class="auto-style29">&nbsp;</td>
            <td class="auto-style8">
                <strong>
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" Width="212px" OnClick="btnEnviar_Click" CssClass="auto-style9" />
                </strong>
            </td>
        </tr>
        <tr>
            <td class="auto-style29">&nbsp;</td>
            <td class="auto-style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style29">&nbsp;</td>
            <td class="auto-style6">
                <asp:LinkButton ID="Volver" runat="server" PostBackUrl="~/PaginaPrincipal.aspx">Volver...</asp:LinkButton>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style29">&nbsp;</td>
            <td class="auto-style6">
                <strong>
                <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
                </strong>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

