<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditWelcomeMailView.ascx.cs"
    Inherits="SEP.Performance.Views.SEP.WelcomeMails.EditWelcomeMailView" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<div id="tbMessage" runat="server" class="leftitbor">
    <asp:Label ID="MsgMessage" runat="server" CssClass="fontred"></asp:Label></div>
<div class="leftitbor2">
    <asp:Label ID="lblTitle" runat="server"></asp:Label></div>
<div class="edittable">
    <table width="100%" border="0">
         <colgroup>
            <col style="width:2%"/>
            <col style="width:15%"/>
            <col style="width:83%"/>
        </colgroup>
        <tbody>
            <tr>
                <td align="right" style="height: 24px;">
                </td>
                <td align="left" style="height: 24px;">
                    �ʼ�����
                </td>
                <td align="left" valign="middle" style="height: 24px;">
                    <asp:DropDownList ID="ddlMailType" runat="server" Width="173px" OnSelectedIndexChanged="ddlMailType_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                    &nbsp; &nbsp; &nbsp; &nbsp;<asp:CheckBox ID="cbAutoSend" runat="server" Text="�����Զ����͹���" />
                </td>
            </tr>
            <tr id="trWelcome" runat="server">
                <td align="right" style="height: 38px;">
                </td>
                <td align="left">
                </td>
                <td align="left" valign="middle">
                    &nbsp;ע�⣺���������м���"#Name#",���ڷ���ʱ�滻���û�������
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 584px;">
                </td>
                <td align="left" valign="top">
                    &nbsp;&nbsp;��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��
                </td>
                <td align="left" valign="middle">
                    <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" Height="580px" Width="579px">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
        </tbody>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnOK" runat="server" Text="��  ��" CssClass="inputbt" OnClick="btnOK_Click">
    </asp:Button></div>
