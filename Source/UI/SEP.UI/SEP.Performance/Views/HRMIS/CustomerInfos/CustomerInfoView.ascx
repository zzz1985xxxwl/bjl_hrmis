<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomerInfoView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.CustomerInfos.CustomerInfoView" %>
<div id="tbMessage" runat="server" class="leftitbor">
    <asp:Label ID="lblMessage" runat="server" CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor2">
    <asp:Label ID="lblOperation" runat="server">  
    </asp:Label>
    <asp:HiddenField ID="hfOperation" runat="server" />
    <asp:HiddenField ID="hfCustomerInfoID" runat="server" />
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left">
                客户名称&nbsp; <span class="redstar" style="padding-right: 10px">*</span>
            </td>
            <td align="left">
                <asp:TextBox runat="server" ID="txtName" CssClass="input1" style="width:350px;"></asp:TextBox>
                <asp:Label ID="lblNameMessage" runat="server" CssClass="psword_f"></asp:Label>
                <p>格式：SAP编号 +空格+客户名称</p>
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button Text="确  定" ID="btnOK" OnClick="btnOK_Click" runat="server" CssClass="inputbt" />
    <asp:Button Text="取　消" ID="btnCancel" runat="server" CssClass="inputbt" />
</div>
