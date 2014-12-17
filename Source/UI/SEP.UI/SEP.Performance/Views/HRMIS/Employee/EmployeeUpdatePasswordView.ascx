<%@ Control Language="C#" AutoEventWireup="true" Codebehind="EmployeeUpdatePasswordView.ascx.cs"
    Inherits="SEP.Performance.Views.Employee.EmployeeUpdatePasswordView" %>

<script language="javascript " type="text/javascript" src="../../../Pages/Inc/UsbKey.js"></script>

<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>--%>
<div id="tbMessage" runat="server" class="leftitbor">
    <asp:Label ID="lblMessage" runat="server"></asp:Label><%--<a href="#" class="fontreda"></a>--%>
</div>
<div class="leftitbor2">
    修改密码<asp:Label ID="lblMyName" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblMyID" runat="server" Visible="False"></asp:Label>
</div>
<div class="linetabledivbg">
    <table width="100%" border="0" cellspacing="6" cellpadding="0" style="border-collapse:separate;">
        <tr>
            <td width="8%" align="right">
                员工姓名&nbsp;&nbsp;</td>
            <td width="92%" align="left">
                <asp:TextBox ID="txtEmployeeName" runat="server" ReadOnly="True" CssClass="input1"
                    Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                旧&nbsp;&nbsp;密&nbsp;&nbsp;码&nbsp;<span class="redstar">*</span></td>
            <td align="left">
                <asp:TextBox ID="txtOldPassword" runat="server" Width="200px" TextMode="Password"
                    CssClass="input1"></asp:TextBox>
                <asp:Label ID="lblOldPasswordMsg" runat="server" Width="150px" CssClass="psword_f"></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                新&nbsp;&nbsp;密&nbsp;&nbsp;码&nbsp;<span class="redstar">*</span></td>
            <td align="left">
                <asp:TextBox ID="TxtNewPassword" runat="server" CssClass="input1" Width="200px" TextMode="Password"></asp:TextBox>
                <asp:Label ID="lblValidatPasswordMsg" runat="server" Width="150px" CssClass="psword_f"></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                确认密码&nbsp;<span class="redstar">*</span></td>
            <td align="left">
                <asp:TextBox ID="TxtConfirmPassword" runat="server" CssClass="input1" Width="200px"
                    TextMode="Password"></asp:TextBox>
                <asp:Label ID="lblConfirmPasswordMsg" runat="server" Width="150px" CssClass="psword_f"></asp:Label></td>
        </tr>
        <tr>
            <td height="43">
                &nbsp;</td>
            <td align="left">
                <label>
                    <asp:Button ID="btnOK" runat="server" Text="确定" CssClass="inputbt" OnClick="btnOK_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </label>
            </td>
        </tr>
    </table>
</div>
<div id="tbResetUsbKey" runat="server">
    <div class="leftitbor2">
        重置U盾</div>
    <div class="linetabledivbg">
        <table width="100%" border="0" style="border-collapse:separate;" cellspacing="6" cellpadding="0">
            <tr>
                <td width="8%" align="right">
                    原始U盾&nbsp;&nbsp;</td>
                <td width="92%" align="left">
                    <asp:TextBox ID="tbUsbKey" runat="server" ReadOnly="True" CssClass="input1" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="43">
                    &nbsp;</td>
                <td align="left">
                    <label>
                        <asp:Button ID="btnResetUSB" runat="server" Text="重置U盾" OnClientClick='GetUsbKey();return true;'
                            CssClass="inputbt" OnClick="btnResetUSB_Click" /></label></td>
            </tr>
        </table>
    </div>
</div>
<%--</ContentTemplate>
</asp:UpdatePanel>--%>
<input id="lbUsbKeyCount" class="UsbKeyCount" type="hidden" runat="server" />
<input id="lbUsbKey" class="UsbKey" type="hidden" runat="server" />
<br />
