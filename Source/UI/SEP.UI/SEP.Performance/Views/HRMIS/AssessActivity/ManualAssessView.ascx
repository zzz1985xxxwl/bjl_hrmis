<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ManualAssessView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AssessActivity.ManualAssessView" %>
<%@ Register Src="../../Progressing.ascx" TagName="Progressing" TagPrefix="uc6" %>
<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div width="100%" id="tbMessage" runat="server" class="leftitbor">
            <asp:Label ID="lblMessage" runat="server" CssClass="fontred"></asp:Label><%--<a href="#" class="fontreda"></a>--%>
        </div>
        <div class="leftitbor2">
            申请绩效考核</div>
        <%--<div class="linetabledivbg">
      <table width="100%" border="0" cellspacing="10" style="border-collapse:separate;" cellpadding="7">--%>
        <div class="edittable">
            <table width="100%" border="0">
                <tr>
                    <td width="10%" align="left">
                        员 工 姓 名</td>
                    <td width="90%" align="left">
                        <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="input1" Width="240px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td width="10%" align="left">
                        绩效考核性质</td>
                    <td width="90%" align="left">
                        <asp:DropDownList ID="ddlCharacter" runat="server" Width="252px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td width="10%" align="left">
                        绩效考核时间段&nbsp;<span class="redstar">*</span>&nbsp;</td>
                    <td width="90%" align="left">
                        <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtpScopeFrom"
                            Format="yyyy-MM-dd">
                        </ajaxToolKit:CalendarExtender>
                        <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="dtpScopeTo"
                            Format="yyyy-MM-dd">
                        </ajaxToolKit:CalendarExtender>
                        <asp:TextBox ID="dtpScopeFrom" runat="server" CssClass="input1" Width="240px"></asp:TextBox>
                        ---
                        <asp:TextBox ID="dtpScopeTo" runat="server" CssClass="input1" Width="240px"></asp:TextBox>
                        <asp:Label ID="lblScopeMsg" runat="server" CssClass="psword_f"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left" valign="top">
                        发 起 原 因&nbsp;<span class="redstar">*</span>&nbsp;</td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtReason" runat="server" CssClass="grayborder" Width="513px" Height="100px"
                            TextMode="MultiLine"></asp:TextBox>
                        <asp:Label ID="lblReasonMsg" runat="server" CssClass="psword_f"></asp:Label></td>
                </tr>
            </table>
        </div>
        <div class="tablebt">
            <asp:Button ID="btnApply" runat="server" Text="申　请" CssClass="inputbt" OnClick="btnApply_Click" />
            <input name="Submit2" type="reset" onclick="javascript :history.back(-1)" class="inputbt"
                value="返　回" />
        </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc6:Progressing ID="Progressing1" runat="server"></uc6:Progressing>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </ContentTemplate>
</asp:UpdatePanel>
