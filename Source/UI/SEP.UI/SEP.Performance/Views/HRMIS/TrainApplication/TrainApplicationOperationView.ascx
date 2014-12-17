<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TrainApplicationOperationView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.TrainApplication.TrainApplicationOperationView" %>
<div id="tbResultMessage" runat="server" class="leftitbor">
    <asp:Label ID="lbResultMessage" runat="server"></asp:Label>
</div>
<div class="leftitbor2">
    <asp:Label ID="lbOperationType" runat="server"></asp:Label>
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td width="5%" align="right">
            </td>
            <td width="8%" align="left"></td>
            <td width="30%" align="left">
                <asp:TextBox runat="server" ID="tbID" CssClass="input1" Visible="false"></asp:TextBox>
            </td>
            <td width="15%" align="left"></td>
            <td align="left">
                <asp:TextBox ID="tbLeaveRequestID" runat="server" CssClass="input1" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                操作者</td>
            <td align="left">
                <asp:TextBox runat="server" ID="tbName" CssClass="input1" ReadOnly="True"></asp:TextBox></td>
            <td align="left">
                操作结果</td>
            <td align="left">
                <asp:DropDownList ID="ddlStatus" runat="server" Width="160px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left" valign="top">
                备&nbsp;&nbsp;&nbsp;&nbsp;注&nbsp;<span class="redstar">*</span></td>
            <td align="left" colspan="3" valign="top">
                <asp:TextBox runat="server" ID="tbRemark" CssClass="grayborder" Height="100px" TextMode="MultiLine"
                    Width="390px"></asp:TextBox>
                <asp:Label ID="lbRemarkMessage" runat="server" CssClass="psword_f"></asp:Label></td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button Text="确  定" ID="BtnOK" OnClick="btnOK_Click" runat="server" CssClass="inputbt" />
    <asp:Button Text="取　消" ID="BtnSubmit" OnClick="btnCancel_Click" runat="server" CssClass="inputbt" />
</div>