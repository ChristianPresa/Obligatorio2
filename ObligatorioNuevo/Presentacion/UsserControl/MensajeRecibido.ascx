<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MensajeRecibido.ascx.cs" Inherits="UsserControl_MensajeRecibido" %>
<style type="text/css">
    .auto-style1 {
        text-align: center;
    }
    .auto-style2 {
        text-align: left;
    }
</style>
<table class="auto-style1">
    <tr>
        <td class="auto-style2">Fecha:</td>
        <td class="auto-style2">
            <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Asunto:</td>
        <td class="auto-style2">
            <asp:TextBox ID="txtAsunto" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Envia:</td>
        <td class="auto-style2">
            <asp:TextBox ID="txtEnviar" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Recibe:</td>
        <td class="auto-style2">
            <asp:ListBox ID="lbRecibe" runat="server" Width="123px"></asp:ListBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Mensaje :</td>
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
        <td class="auto-style1" colspan="2">
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