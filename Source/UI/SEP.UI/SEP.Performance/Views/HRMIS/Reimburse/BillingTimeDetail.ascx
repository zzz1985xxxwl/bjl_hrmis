<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BillingTimeDetail.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.Reimburse.BillingTimeDetail" %>
<div id="tbMessage" runat="server" class="leftitbor">
    <asp:Label ID="lblResultMessage" runat="server" CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor2">
    <asp:Label ID="lblOperationInfo" runat="server">  
    </asp:Label>
    <asp:HiddenField ID="lblOperation" runat="server" />
    <asp:HiddenField ID="hfLevelId" runat="server" />
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
                             <td style="width: 10%;" align="left">
                                    ����ʱ��&nbsp;</td>
                                    <asp:Label
                                        ID="lblReimburseId" runat="server" Visible = "false" ></asp:Label>
                                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtBillingTime"
                                    Format="yyyy-MM-dd">
                                </ajaxToolKit:CalendarExtender>
                                <td style="width: 22%;" align="left">
                                    <asp:TextBox ID="txtBillingTime" runat="server" CssClass="input1"></asp:TextBox>&nbsp;&nbsp;<asp:Label
                                        ID="MsgBillingTime" runat="server" CssClass="psword_f"></asp:Label></td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button Text="ȷ  ��" ID="btnOK" runat="server" class="inputbt" OnClick="btnOK_Click"   OnClientClick= "return confirm('����ʱ���Ƿ���ȷ�����󣿱���󽫲��ɸ��ģ�'); "/>&nbsp;&nbsp;&nbsp;
    <asp:Button Text="ȡ����" ID="btnCancle" runat="server" class="inputbt" />&nbsp;&nbsp;&nbsp;
</div>