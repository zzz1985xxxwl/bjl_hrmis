<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ABCClientSetView.ascx.cs" Inherits="SEP.Performance.Pages.Config.Views.ABCClientSetView" %>
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <asp:CheckBox ID="cbOpenFunction" runat="server" Text="�����˹���"/></td>
            </tr>
            <tr>
                <td style="width: 10%;text-align:left">
                    ����</td>
                <td style="width: 90%">
                    <asp:TextBox ID="txtServerName" runat="server" Width="650px" ReadOnly ="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:left">
                    �����ַUrl(A)</td>
                <td >
                    <asp:TextBox ID="txtServerAddress" runat="server" Width="650px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:left">
                    ��(B)</td>
                <td >
                    <asp:TextBox ID="txtServerBinding" runat="server" Width="650px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:left">
                    Э��(C)</td>
                <td >
                    <asp:TextBox ID="txtServerContract" runat="server" Width="650px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:left">
                    ������</td>
                <td >
                    <asp:TextBox ID="txtServerBindingConfiguration" runat="server" Width="650px"></asp:TextBox></td>
            </tr>
        </table>
