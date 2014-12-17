<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CompanyLinkManView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.CompanyTeleBooks.CompanyLinkManView" %>
<link href="../../../Pages/CSS/style.css" rel="stylesheet" type="text/css" />
<div id="tbMessage" runat="server" class="leftitbor" >
<asp:Label ID="lblMessage" runat="server" CssClass = "fontred"></asp:Label>
</div>
<div class="leftitbor2" >
  <asp:Label ID="lblOperation" runat="server" >  
 </asp:Label>
<asp:HiddenField ID="Operation" runat="server" />        
</div>
<div id="teleadd">
    <table width="100%" border="0" cellspacing="5" cellpadding="0">
        <tr>
            <td align="right" style="width: 20%"><span class = "redstar">*</span>
                <img src="../../image/phone03.gif" width="15" height="12" align="absmiddle" />姓名</td>
            <td align="center" style="width: 55%">
                <label>
                    <asp:TextBox runat="server" ID="txtName" CssClass="input1" Width="99%" MaxLength="25"></asp:TextBox>
                </label>
            </td>
            <td align="left" style="width: 25%">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 20%">
                <img src="../../image/phone04.gif" width="15" height="12" align="absmiddle" />手机</td>
            <td align="center" style="width: 55%">
                <label>
                    <asp:TextBox runat="server" ID="txtMobil" CssClass="input1" Width="99%"></asp:TextBox>
                </label>
            </td>
            <td align="left" style="width: 25%">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 20%">
                <img src="../../image/phone05.gif" width="15" height="12" align="absmiddle" />住宅</td>
            <td align="center" style="width: 55%">
                <label>
                    <asp:TextBox runat="server" ID="txtHome" CssClass="input1" Width="99%"></asp:TextBox></label>
            </td>
            <td align="left" style="width: 25%">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 20%">
                <img src="../../image/phone06.gif" width="15" height="12" align="absmiddle" />办公</td>
            <td align="center" style="width: 55%">
                <label>
                    <asp:TextBox runat="server" ID="txtOffice" CssClass="input1" Width="99%"></asp:TextBox></label>
            </td>
            <td align="left" style="width: 25%">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 20%">
                <img src="../../image/phone07.gif" width="15" height="12" align="absmiddle" />邮件</td>
            <td align="center" style="width: 55%">
                <label>
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="input1" Width="99%"></asp:TextBox></label></td>
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
                            <asp:Button Text="确  定" ID="btnOK" OnClick="btnOK_Click" runat="server" CssClass="inputbt" /></td>
                        <td style="width: 20%" >
                        </td>
                        <td style="width: 40%" align="left">
                            <asp:Button Text="取　消" ID="btnCancel" OnClick="btnCancel_Click" runat="server" CssClass="inputbt" /></td>
                    </tr>
                </table>
            </td>
            <td align="left" style="width: 20%">
            </td>
        </tr>
    </table>
</div>