<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ChangePasswordView.ascx.cs"
    Inherits="SEP.Performance.Views.SEP.Accounts.ChangePasswordView" %>
<div id="divMessage" runat="server" class="leftitbor">
    <asp:Label ID="lblMessage" runat="server" CssClass="fontred"></asp:Label><%--<a href="#" class="fontreda"></a>--%>
</div>
<div class="leftitbor2" >�޸�����<asp:Label ID="lblMyName" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="lblMyID" runat="server" Visible="False"></asp:Label></div>
<div class="edittable">
    <table width="98%" border="0">
        <tr>
            <td width="8%" align="right">
                ��&nbsp;&nbsp;¼&nbsp;&nbsp;��&nbsp;&nbsp;</td>
            <td width="92%" align="left">
                <asp:TextBox ID="txtEmployeeName" runat="server" ReadOnly="True" CssClass="input1"
                    Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                ��&nbsp;&nbsp;��&nbsp;&nbsp;��&nbsp;<span class="redstar">*</span></td>
            <td align="left">
                <asp:TextBox ID="txtOldPassword" runat="server" Width="200px" TextMode="Password"
                    CssClass="input1"></asp:TextBox>
                <asp:Label ID="lblOldPasswordMsg" runat="server" Width="150px" CssClass="psword_f"></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                ��&nbsp;&nbsp;��&nbsp;&nbsp;��&nbsp;<span class="redstar">*</span></td>
            <td align="left">
                <asp:TextBox ID="TxtNewPassword" runat="server" CssClass="input1" Width="200px" TextMode="Password"></asp:TextBox>
                <asp:Label ID="lblValidatPasswordMsg" runat="server" Width="150px" CssClass="psword_f"></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                ȷ������&nbsp;<span class="redstar">*</span></td>
            <td align="left">
                <asp:TextBox ID="TxtConfirmPassword" runat="server" CssClass="input1" Width="200px"
                    TextMode="Password"></asp:TextBox>
                <asp:Label ID="lblConfirmPasswordMsg" runat="server" Width="150px" CssClass="psword_f"></asp:Label></td>
        </tr>
    </table>
</div>
<div class="tablebt">  
	   <asp:Button ID="btnOK" runat="server" Text="ȷ��" CssClass="inputbt" OnClick="btnOK_Click" />
	      <asp:Button ID="btnCancle" runat="server" Text="ȡ��" CssClass="inputbt" OnClick="btnCancle_Click" />
</div>