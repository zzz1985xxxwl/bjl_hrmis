<%@ Control Language="C#" AutoEventWireup="true" Codebehind="AssessBasicInfoView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AssessActivity.AssessBasicInfoView" %>


<div class="marginepx">
    <table width="100%" class="assessbasicinfoborder" height="43" cellpadding="7" cellspacing="0">
        <tr>
            <td class="assessbasicinfobg" align="center">
                <table id="tbAssessTable" runat="server" width="98%" border="0" cellspacing="0" cellpadding="0">
                    <%--<tr>
                        <td align="left" width="25%">
                            <asp:Button ID="lbHRResult" runat="server" Enabled="false" CssClass="assessflowlb"
                                Text="HR�������"></asp:Button>
                        </td>
                        <td align="left" width="25%">
                            <asp:Button ID="lbPersonalResult" runat="server" Enabled="false" CssClass="assessflowlb"
                                Text="��������"></asp:Button>
                        </td>
                        <td align="left" width="25%">
                            <asp:Button ID="lbManagerResult" runat="server" Enabled="false" CssClass="assessflowlb"
                                Text="���ܿ������"></asp:Button>
                        </td>
                        <td align="left" width="25%">
                            <asp:Button ID="lbCEOResult" runat="server" Enabled="false" CssClass="assessflowlb"
                                Text="�������"></asp:Button>
                        </td>
                        <td align="left" width="25%">
                            <asp:Button ID="lbSummaryResult" runat="server" Enabled="false" CssClass="assessflowlb"
                                Text="�ս�����"></asp:Button>
                        </td>
                    </tr>--%>
                </table>
            </td>
        </tr>
    </table>
</div>
<div id="tbMessage" runat="server" class="leftitbor">
    <span class="fontred">
        <asp:Label ID="lblMessage" runat="server"></asp:Label></span><a href="#" class="fontreda"></a>
</div>
<div class="leftitbor2">
    ���˻������Ϣ</div>
<div class="linetablediv">
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
        <tr class="tittdbagbg">
            <td width="5%" height="28" align="left">
                &nbsp;&nbsp;</td>
            <td width="16%" align="left">
                <strong>Ա������</strong></td>
            <td width="19%" align="left">
                <strong>�� ��</strong></td>
            <td width="19%" align="left">
                <strong>��Ч��������</strong></td>
            <td width="18%" align="left">
                <strong>ֱ������</strong></td>
            <td width="23%" align="left">
                <strong>��Ч����ʱ���</strong></td>
        </tr>
        <tr>
            <td height="28">
                &nbsp;</td>
            <td align="left">
                <asp:Label ID="lblEmployeeName" runat="server"></asp:Label></td>
            <td align="left">
                <asp:Label ID="lblDepartment" runat="server"></asp:Label></td>
            <td align="left">
                <asp:Label ID="lblCharacter" runat="server"></asp:Label></td>
            <td align="left">
                <asp:Label ID="lblManager" runat="server"></asp:Label></td>
            <td align="left">
                <asp:Label ID="lblScopeFrom" runat="server"></asp:Label>---
                <asp:Label ID="lblScopeTo" runat="server"></asp:Label></td>
        </tr>
    </table>
</div>
