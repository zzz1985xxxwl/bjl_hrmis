<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ABCClientSetView.ascx.cs" Inherits="SEP.Performance.Pages.Config.Views.ABCClientSetView" %>
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <asp:CheckBox ID="cbOpenFunction" runat="server" Text="开启此功能"/></td>
            </tr>
            <tr>
                <td style="width: 10%;text-align:left">
                    名字</td>
                <td style="width: 90%">
                    <asp:TextBox ID="txtServerName" runat="server" Width="650px" ReadOnly ="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:left">
                    服务地址Url(A)</td>
                <td >
                    <asp:TextBox ID="txtServerAddress" runat="server" Width="650px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:left">
                    绑定(B)</td>
                <td >
                    <asp:TextBox ID="txtServerBinding" runat="server" Width="650px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:left">
                    协议(C)</td>
                <td >
                    <asp:TextBox ID="txtServerContract" runat="server" Width="650px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:left">
                    绑定配置</td>
                <td >
                    <asp:TextBox ID="txtServerBindingConfiguration" runat="server" Width="650px"></asp:TextBox></td>
            </tr>
        </table>
