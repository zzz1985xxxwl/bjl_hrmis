<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdjustRuleEditView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.AdjustRules.AdjustRuleEditView" %>
<div id="tbMessage" runat="server" class="leftitbor">
    <asp:Label ID="lblMessage" runat="server" CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor2">
    <asp:Label ID="lblOperation" runat="server">  
    </asp:Label>
    <asp:HiddenField ID="hfOperation" runat="server" />
    <asp:HiddenField ID="hfadjustRuleID" runat="server" />
</div>
<div class="edittable">
    <table width="100%" border="0">
         <tr>
            <td align="left" style="padding-left:35px;">
              �������ƣ�&nbsp; <span class="redstar" style="padding-right:55px;">*</span> <asp:TextBox runat="server" ID="txtName" CssClass="input1" Width="100px" ></asp:TextBox>
              <asp:Label ID="lblNameMessage" runat="server" CssClass="psword_f"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="padding-left:35px;">
                ��ͨ�Ӱ໻ȡ����&nbsp; <span class="redstar" style="padding-right:10px;">*</span>&nbsp;1:<asp:TextBox runat="server" ID="txtOverWorkPuTongRate" CssClass="input1" Width="40px"></asp:TextBox>
                <asp:Label ID="lblOverWorkPuTongRateMessage" runat="server" CssClass="psword_f"></asp:Label>
                </td>
        </tr>
         <tr>
            <td align="left" style="padding-left:35px;">
                 ˫�ݼӰ໻ȡ����&nbsp; <span class="redstar" style="padding-right:10px;">*</span>&nbsp;1:<asp:TextBox runat="server" ID="txtOverWorkShuangXiuRate" CssClass="input1" Width="40px"></asp:TextBox>
                 <asp:Label ID="lblOverWorkShuangXiuRateMessage" runat="server" CssClass="psword_f"></asp:Label>
                 </td>
        </tr>
         <tr>
            <td align="left" style="padding-left:35px;">
                ���ռӰ໻ȡ����&nbsp; <span class="redstar" style="padding-right:10px;">*</span>&nbsp;1:<asp:TextBox runat="server" ID="txtOverWorkJieRiRate" CssClass="input1" Width="40px"></asp:TextBox>
                <asp:Label ID="lblOverWorkJieRiRateMessage" runat="server" CssClass="psword_f"></asp:Label>
                </td>
        </tr>
         <tr style="display:none;">
            <td align="left" style="padding-left:35px;">
                ��ͨ���ȡ����&nbsp; <span class="redstar" style="padding-right:10px;">*</span>&nbsp;1:<asp:TextBox runat="server" ID="txtOutCityPuTongRate" Text="0" CssClass="input1" Width="40px"></asp:TextBox>
                <asp:Label ID="lblOutCityPuTongRateMessage" runat="server" CssClass="psword_f"></asp:Label>
                </td>
        </tr>
         <tr>
            <td align="left" style="padding-left:35px;">
                ˫�ݳ��ȡ����&nbsp; <span class="redstar" style="padding-right:10px;">*</span>&nbsp;1:<asp:TextBox runat="server" ID="txtOutCityShuangXiuRate" CssClass="input1" Width="40px"></asp:TextBox>
                <asp:Label ID="lblOutCityShuangXiuRateMessage" runat="server" CssClass="psword_f"></asp:Label>
                </td>
        </tr>
         <tr>
            <td align="left" style="padding-left:35px;">
                ���ճ��ȡ����&nbsp; <span class="redstar" style="padding-right:10px;">*</span>&nbsp;1:<asp:TextBox runat="server" ID="txtOutCityJieRiRate" CssClass="input1" Width="40px"></asp:TextBox>
                <asp:Label ID="lblOutCityJieRiRateMessage" runat="server" CssClass="psword_f"></asp:Label>
                </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button Text="ȷ  ��" ID="btnOK" OnClick="btnOK_Click" runat="server"  CssClass="inputbt" />
    <asp:Button Text="ȡ����" ID="btnCancel" runat="server" CssClass="inputbt" />
</div>