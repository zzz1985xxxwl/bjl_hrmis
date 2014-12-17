<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ApplyAssessConditionView.ascx.cs"
    Inherits="SEP.Performance.Views.Employee.ApplyAssessConditionView" %>
<asp:HiddenField ID="hfConditionID" runat="server" />
<div class="leftitbor" runat="server" id="tbMessage">
    <asp:Label ID="lblMessage" runat="server" CssClass="fontred"></asp:Label><%--<a href="#" class="fontreda"></a>--%>
</div>
<div class="leftitbor2">
    <asp:Label ID="lblTitle" runat="server"></asp:Label></div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td width="20%" align="left">
                发起时间&nbsp;<span class="redstar">*</span>&nbsp;</td>
            <td width="80%" align="left">
                <ajaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="dtpApplyDate"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <asp:TextBox ID="dtpApplyDate" runat="server" CssClass="input1" Width="150px"></asp:TextBox>
                <asp:Label ID="lblApplyDate" runat="server" CssClass="psword_f"></asp:Label></td>
        </tr>
        <tr>
            <td align="left">
                绩效考核性质</td>
            <td align="left">
                <asp:DropDownList ID="ddlCharacter" runat="server" Width="162px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="left">
                绩效考核时间段&nbsp;<span class="redstar">*</span>&nbsp;</td>
            <td align="left">
                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtpScopeFrom"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <asp:TextBox ID="dtpScopeFrom" runat="server" CssClass="input1" Width="150px"></asp:TextBox>
                ---
                <asp:TextBox ID="dtpScopeTo" runat="server" CssClass="input1" Width="150px"></asp:TextBox>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="dtpScopeTo"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <asp:Label ID="lblScopeMsg" runat="server" CssClass="psword_f"></asp:Label></td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnOK" runat="server" Text="确　定" CssClass="inputbt" OnClick="btnOK_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="取　消" CssClass="inputbt" OnClick="btnCancel_Click" />
</div>
