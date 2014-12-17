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
              规则名称：&nbsp; <span class="redstar" style="padding-right:55px;">*</span> <asp:TextBox runat="server" ID="txtName" CssClass="input1" Width="100px" ></asp:TextBox>
              <asp:Label ID="lblNameMessage" runat="server" CssClass="psword_f"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="padding-left:35px;">
                普通加班换取调休&nbsp; <span class="redstar" style="padding-right:10px;">*</span>&nbsp;1:<asp:TextBox runat="server" ID="txtOverWorkPuTongRate" CssClass="input1" Width="40px"></asp:TextBox>
                <asp:Label ID="lblOverWorkPuTongRateMessage" runat="server" CssClass="psword_f"></asp:Label>
                </td>
        </tr>
         <tr>
            <td align="left" style="padding-left:35px;">
                 双休加班换取调休&nbsp; <span class="redstar" style="padding-right:10px;">*</span>&nbsp;1:<asp:TextBox runat="server" ID="txtOverWorkShuangXiuRate" CssClass="input1" Width="40px"></asp:TextBox>
                 <asp:Label ID="lblOverWorkShuangXiuRateMessage" runat="server" CssClass="psword_f"></asp:Label>
                 </td>
        </tr>
         <tr>
            <td align="left" style="padding-left:35px;">
                节日加班换取调休&nbsp; <span class="redstar" style="padding-right:10px;">*</span>&nbsp;1:<asp:TextBox runat="server" ID="txtOverWorkJieRiRate" CssClass="input1" Width="40px"></asp:TextBox>
                <asp:Label ID="lblOverWorkJieRiRateMessage" runat="server" CssClass="psword_f"></asp:Label>
                </td>
        </tr>
         <tr style="display:none;">
            <td align="left" style="padding-left:35px;">
                普通出差换取调休&nbsp; <span class="redstar" style="padding-right:10px;">*</span>&nbsp;1:<asp:TextBox runat="server" ID="txtOutCityPuTongRate" Text="0" CssClass="input1" Width="40px"></asp:TextBox>
                <asp:Label ID="lblOutCityPuTongRateMessage" runat="server" CssClass="psword_f"></asp:Label>
                </td>
        </tr>
         <tr>
            <td align="left" style="padding-left:35px;">
                双休出差换取调休&nbsp; <span class="redstar" style="padding-right:10px;">*</span>&nbsp;1:<asp:TextBox runat="server" ID="txtOutCityShuangXiuRate" CssClass="input1" Width="40px"></asp:TextBox>
                <asp:Label ID="lblOutCityShuangXiuRateMessage" runat="server" CssClass="psword_f"></asp:Label>
                </td>
        </tr>
         <tr>
            <td align="left" style="padding-left:35px;">
                节日出差换取调休&nbsp; <span class="redstar" style="padding-right:10px;">*</span>&nbsp;1:<asp:TextBox runat="server" ID="txtOutCityJieRiRate" CssClass="input1" Width="40px"></asp:TextBox>
                <asp:Label ID="lblOutCityJieRiRateMessage" runat="server" CssClass="psword_f"></asp:Label>
                </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button Text="确  定" ID="btnOK" OnClick="btnOK_Click" runat="server"  CssClass="inputbt" />
    <asp:Button Text="取　消" ID="btnCancel" runat="server" CssClass="inputbt" />
</div>