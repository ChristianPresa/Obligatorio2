<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MensajeEnviado.ascx.cs" Inherits="UsserControl_MensajeEnviado" %>
<style type="text/css">
    .auto-style1 {
        width: 19%;
        margin-right: 0px;
        height: 416px;
    }
    .auto-style2 {
        width: 483px;
    }
    .auto-style5 {
        height: 302px;
    }
    .auto-style6 {
        width: 66px;
    }
    .auto-style7 {
        text-align: center;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style6">Fecha:</td>
        <td class="auto-style2">
            <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style6">Asunto:</td>
        <td class="auto-style2">
            <asp:TextBox ID="txtAsunto" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style6">Envia:</td>
        <td class="auto-style2">
            <asp:TextBox ID="txtEnviar" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style6">Recibe:</td>
        <td class="auto-style2">
            <asp:ListBox ID="lbRecibe" runat="server" Width="123px"></asp:ListBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style6">Mensaje :</td>
        <td class="auto-style2">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5" colspan="2">
            <asp:TextBox ID="txtMensaje" runat="server" Height="147px" Width="253px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style6">&nbsp;</td>
        <td class="auto-style2">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style7" colspan="2">
            <strong>
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            </strong>
        </td>
    </tr>
    <tr>
        <td class="auto-style6">&nbsp;</td>
        <td class="auto-style2">&nbsp;</td>
    </tr>
</table>

