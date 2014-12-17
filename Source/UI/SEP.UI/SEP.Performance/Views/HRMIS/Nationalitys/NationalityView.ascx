<%@ Control Language="C#" AutoEventWireup="true" Codebehind="NationalityView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.Nationalitys.NationalityView" %>
<div id="tbMessage" runat="server" class="leftitbor">
    <asp:Label ID="lblMessage" runat="server" CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor2">
    <asp:Label ID="lblOperation" runat="server">  </asp:Label>
    <asp:HiddenField ID="Operation" runat="server" />
    <asp:HiddenField ID="hfNationalityID" runat="server" />
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td width="2%" align="right">
            </td>
            <td width="15%" align="left">
                名&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;称&nbsp;<span class="redstar">*</span>
            </td>
            <td align="left">
                <asp:TextBox runat="server" ID="txtName" CssClass="input1"></asp:TextBox>&nbsp;&nbsp;&nbsp;
                <asp:Label runat="server" ID="lblNameMsg" CssClass="psword_f"></asp:Label>
                &nbsp;&nbsp; &nbsp; &nbsp;</td>
        </tr>
        <tr>
            <td width="2%" align="right">
            </td>
            <td width="15%" align="left" valign="top">
                说&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;明</td>
            <td align="left" colspan="3" valign="top">
                <asp:TextBox runat="server" ID="txtDescription" CssClass="input1" TextMode="MultiLine"
                    Height="97px" Width="328px"></asp:TextBox>
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button Text="确  定" ID="btnOK" OnClick="btnOK_Click" runat="server" class="inputbt" />
    <asp:Button Text="取　消" ID="btnCancel" OnClick="btnCancel_Click" runat="server" class="inputbt" />
</div>
