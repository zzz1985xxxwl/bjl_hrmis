<%@ Control Language="C#" AutoEventWireup="true" Codebehind="LinkmanView.ascx.cs"
    Inherits="SEP.Performance.Views.SEP.Contacts.LinkmanView" %>
<link href="../../../Pages/CSS/style.css" rel="stylesheet" type="text/css" />
<div id="teleadd">
    <table width="100%" border="0" cellspacing="5" cellpadding="0">
        <tr>
            <td align="right" style="width: 20%"><span class = "redstar">*</span>
                <img src="../../image/phone03.gif" width="15" height="12" align="absmiddle" />����</td>
            <td align="center" style="width: 55%">
                <label>
                    <asp:TextBox runat="server" ID="txtName" CssClass="teleinput" Width="99%" MaxLength="25"></asp:TextBox>
                </label>
            </td>
            <td align="left" style="width: 25%">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 20%">
                <img src="../../image/phone04.gif" width="15" height="12" align="absmiddle" />�ֻ�</td>
            <td align="center" style="width: 55%">
                <label>
                    <asp:TextBox runat="server" ID="txtMobil" CssClass="teleinput" Width="99%"></asp:TextBox>
                </label>
            </td>
            <td align="left" style="width: 25%">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 20%">
                <img src="../../image/phone05.gif" width="15" height="12" align="absmiddle" />סլ</td>
            <td align="center" style="width: 55%">
                <label>
                    <asp:TextBox runat="server" ID="txtHome" CssClass="teleinput" Width="99%"></asp:TextBox></label>
            </td>
            <td align="left" style="width: 25%">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 20%">
                <img src="../../image/phone06.gif" width="15" height="12" align="absmiddle" />�칫</td>
            <td align="center" style="width: 55%">
                <label>
                    <asp:TextBox runat="server" ID="txtOffice" CssClass="teleinput" Width="99%"></asp:TextBox></label>
            </td>
            <td align="left" style="width: 25%">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 20%">
                <img src="../../image/phone07.gif" width="15" height="12" align="absmiddle" />�ʼ�</td>
            <td align="center" style="width: 55%">
                <label>
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="teleinput" Width="99%"></asp:TextBox></label></td>
            <td align="left" style="width: 25%">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 25%">
                &nbsp;</td>
            <td align="center" style="width: 55%">
                <table width="99%">
                    <tr>
                        <td style="width: 40%" align="right">
                            <asp:Button Text="ȷ  ��" ID="btnOK" OnClick="btnOK_Click" runat="server" CssClass="inputbt" /></td>
                        <td style="width: 20%" >
                        </td>
                        <td style="width: 40%" align="left">
                            <asp:Button Text="ȡ����" ID="btnCancel" OnClick="btnCancel_Click" runat="server" CssClass="inputbt" /></td>
                    </tr>
                </table>
            </td>
            <td align="left" style="width: 20%">
            </td>
        </tr>
    </table>
</div>
