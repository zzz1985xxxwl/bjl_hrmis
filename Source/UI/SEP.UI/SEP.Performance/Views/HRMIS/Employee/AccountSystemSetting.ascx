<%@ Control Language="C#" AutoEventWireup="true" Codebehind="AccountSystemSetting.ascx.cs"
    Inherits="SEP.Performance.Views.Employee.AccountSystemSetting" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="tbMessage" runat="server" class="leftitbor">
            <asp:Label ID="lblMessage" runat="server"></asp:Label></span><%--<a href="#" class="fontreda"></a>--%>
        </div>
        <div class="leftitbor2">
            ϵͳ����<asp:HiddenField ID="hfEmployeeID" runat="server" />
        </div>
        <div class="linetabledivbg">
            <table width="100%" border="0" cellspacing="6" cellpadding="0" style="border-collapse:separate;">
                <tr>
                    <td align="right" style="width: 10%">
                        �Ƿ���ն���&nbsp;&nbsp;</td>
                    <td align="left" style="width: 90%">
                        <asp:RadioButtonList ID="rblIfReceiveMessage" runat="server" RepeatDirection="Horizontal"
                            Width="160px">
                            <asp:ListItem Value="0">��</asp:ListItem>
                            <asp:ListItem Value="1" Selected="True">��</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
            </table>
        </div>
        <div class="tablebt">
            <asp:Button ID="btnOK" runat="server" Text="ȷ��" CssClass="inputbt" OnClick="btnOK_Click" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
