<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ConfirmAssessView.ascx.cs"
    Inherits="MyCmmiWebSite.Performance.Views.AssessActivity.ConfirmAssessView" %>
<div id="tbMessage" runat="server" class="leftitbor">
        <asp:Label ID="lblMessage" runat="server" CssClass="fontred"></asp:Label><%--<a href="#" class="fontreda"></a>--%>
</div><asp:HiddenField ID="hfSubmitID" runat="server" />
<div  class="edittable">
<table width="100%" border="0">
        <tr>
            <td width="22%" align="left">
                期望员工自评截止时间&nbsp;<span class="redstar">*</span>&nbsp;</td>
            <td width="78%" align="left">
                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtpPersonalExpectedFinish"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <asp:TextBox ID="dtpPersonalExpectedFinish" runat="server" CssClass="input1" Width="155px"></asp:TextBox>
                &nbsp;&nbsp;<asp:Label ID="lblPersonalExpectedTimeMsg" runat="server" CssClass="psword_f"></asp:Label></td>
        </tr>
        <tr>
            <td width="22%" align="left">
                期望主管评定截止时间&nbsp;<span class="redstar">*</span>&nbsp;</td>
            <td width="78%" align="left">
                <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="dtpManagerExpectedFinish"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <asp:TextBox ID="dtpManagerExpectedFinish" runat="server" CssClass="input1" Width="155px"></asp:TextBox>
                &nbsp;&nbsp;<asp:Label ID="lblManagerExpectedTimeMsg" runat="server" CssClass="psword_f"></asp:Label></td>
        </tr>
        <tr>
            <td width="22%" align="left">
                选择绩效考核模板&nbsp;<span class="redstar">*</span>&nbsp;</td>
            <td width="78%" align="left">
                <asp:DropDownList ID="ddlTemplatePaper" runat="server" Width="60%">
                </asp:DropDownList></td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnConfirm" runat="server" Text="确  定" CssClass="inputbt" OnClick="btnConfirm_Click" />
</div>
