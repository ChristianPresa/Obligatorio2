<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PaginaPrincipal.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style6 {
        text-align: center;
    }
    .auto-style7 {
        font-size: large;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style6"><strong>
            <asp:Label ID="BIENVENIDOS" runat="server" CssClass="auto-style7" Text="BIENVENIDOS!!"></asp:Label>
            </strong></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style6">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style6">
                    <strong>
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                    </strong>
                </td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>

