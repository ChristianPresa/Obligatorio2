<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MensajeComunMP.aspx.cs" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            width: 481px;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            width: 481px;
        }
        .auto-style4 {
            height: 23px;
            width: 481px;
        }
        .auto-style5 {
            width: 335px;
        }
        .auto-style6 {
            height: 23px;
            width: 335px;
        }
        .auto-style7 {
            width: 335px;
            height: 59px;
            text-align: center;
        }
        .auto-style8 {
            text-align: center;
            width: 541px;
            height: 59px;
        }
        .auto-style9 {
            height: 59px;
        }
        .auto-style10 {
            margin-left: 0px;
        }
        .auto-style11 {
            height: 23px;
            width: 541px;
            font-weight: bold;
            text-align: center;
        }
        .auto-style12 {
            width: 541px;
            text-align: center;
        }
        .auto-style13 {
            width: 596px;
            text-align: left;
        }
    .auto-style14 {
        width: 596px;
        text-align: center;
        height: 23px;
    }
    .auto-style15 {
        width: 541px;
        text-align: center;
        height: 23px;
    }
    .auto-style16 {
        height: 23px;
    }
        .auto-style17 {
            font-weight: bold;
        }
        .auto-style18 {
            font-size: x-large;
        }
        .auto-style19 {
            text-align: center;
            height: 23px;
        }
        .auto-style20 {
            width: 596px;
            text-align: center;
            height: 50px;
        }
        .auto-style21 {
            width: 541px;
            text-align: center;
            height: 50px;
        }
        .auto-style22 {
            height: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="auto-style19" colspan="3">
                <strong>
                <asp:Label ID="Label1" runat="server" Text="Mensajes Comunes" CssClass="auto-style18"></asp:Label>
                </strong>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style12">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style12"><strong>
                <asp:Label ID="Label2" runat="server" Text="Asunto:"></asp:Label>
                </strong></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">
                &nbsp;</td>
            <td class="auto-style11">
                <asp:TextBox ID="txtAsunto" runat="server" Width="463px"></asp:TextBox>
            </td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td class="auto-style13">
                &nbsp;</td>
            <td class="auto-style12">
                <strong>
                <asp:Label ID="Label3" runat="server" Text="Texto:"></asp:Label>
                </strong>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style12">
                <asp:TextBox ID="txtMensaje" runat="server" Height="127px" Width="461px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">
                <br />
                <strong>
                <br />
                </strong>
            </td>
            <td class="auto-style8">
            </td>
            <td class="auto-style9"></td>
        </tr>
        <tr>
            <td class="auto-style5">
                <strong>
                <asp:Label ID="Label4" runat="server" Text="Enviar a :"></asp:Label>
                </strong>
            </td>
            <td class="auto-style12">
                <strong><asp:Label ID="Label5" runat="server" Text="Tipo:"></asp:Label>
                </strong>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">
                <strong>
                <asp:Button ID="btnAgregar" runat="server" CssClass="auto-style17" OnClick="btnAgregar_Click" Text="Agregar" Width="89px" />
                &nbsp;</strong><asp:TextBox ID="txtReceptor" runat="server" Width="205px"></asp:TextBox>
            </td>
            <td class="auto-style12">
                <asp:DropDownList ID="ddlTipo" runat="server" CssClass="auto-style10" Height="18px" Width="287px" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:ListBox ID="lbReceptores" runat="server" Width="306px" OnSelectedIndexChanged="lbReceptores_SelectedIndexChanged" style="height: 70px"></asp:ListBox>
            </td>
            <td class="auto-style12">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style14"><strong>
                <asp:Button ID="btnBorrar" runat="server" CssClass="auto-style17" OnClick="btnBorrar_Click" Text="Borrar" Width="100px" />
                </strong>
            </td>
            <td class="auto-style15">
                <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar Todo" />
            </td>
            <td class="auto-style16"></td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style12">
                <em><strong>
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" Width="212px" OnClick="btnEnviar_Click" CssClass="auto-style17" />
                </strong></em>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style20"></td>
            <td class="auto-style21">
                <asp:LinkButton ID="Volver" runat="server" PostBackUrl="~/PaginaPrincipal.aspx">Volver...</asp:LinkButton>
            </td>
            <td class="auto-style22"></td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style12">
                <strong>
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                </strong>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
</asp:Content>

