<%@ Control Language="C#" AutoEventWireup="true" Codebehind="SearchSettingView.ascx.cs"
    Inherits="SEP.Performance.Views.SEP.Contacts.SearchSettingView" %>
<%--<link href="../../Pages/CSS/style.css" rel="stylesheet" type="text/css" />--%>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td align="right">
            <table width="100%" height="28px" class="linetablepart" cellpadding="0" cellspacing="0"
                style="background-color: White">
                <tr>
                    <td class="headerstyleblue" colspan="2" style="text-align: center">
                        ���ò�ѯ����</td>
                </tr>
            </table>
            <table width="100%" class="linetable" cellpadding="0" cellspacing="10" style="background-color: White;border-collapse:separate;">
                <tr>
                    <td style="width: 23%" align="right">
                        <img src="../../image/phone08.jpg" width="20" height="13" style="text-align: center" />
                        ����</td>
                    <td style="width: 77%" align="left">
                        <label>
                            <%--<input name="textfield" type="text" class="teleinput" size="30" />--%>
                            <asp:TextBox ID="txtName" runat="server" ></asp:TextBox>
                        </label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td align="left">
                        <label>
                            <%--<input name="Submit" type="submit" class="inputbt" value="�ѡ���" />--%>
                            <asp:Button ID="btnSearch" runat="server" Text="�ѡ���" CssClass="inputbt"  OnClick="btnSearch_Click" />
                        </label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
