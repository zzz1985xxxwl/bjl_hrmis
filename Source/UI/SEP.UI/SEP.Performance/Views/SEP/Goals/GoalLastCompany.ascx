<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoalLastCompany.ascx.cs" Inherits="SEP.Performance.Views.GoalLastCompany" %>

    
    <div class="companygoal">
    <table width="100%"  cellpadding="10" cellspacing="0" >
      <tr >
		<td width="58%" align="left" class="ggline">
		<strong style="font-size:14px;">公司目标：<asp:LinkButton ID="lbtnCompanyGoal" runat="server" OnCommand="lbtnCompanyGoal_Command" ></asp:LinkButton></strong>
		<asp:Label ID="lblResultMessage" runat="server" CssClass="fontred"></asp:Label>
		</td>
		<td align="left" class="fontgray"><span class="fontblue1">发布于</span><asp:Label ID="lblCGSetTime" runat="server"></asp:Label></td>
      </tr>
    </table>
    </div>

