<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ComeAndLeaveTableView.ascx.cs" Inherits="SEP.Performance.Views.EmployeeStatistics.ComeAndLeaveTableView" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr id="trSearch" runat="server">
    <td height="68" align="center">
        <table width="100%" bcellpadding="0" cellspacing="0">
	        <tr><td>
	            <table cellpadding="0"  cellspacing="0" class="linetablepart" border="0" width="100%" height="28">
		          <tr class="tittdbagbg">
		            <td class="kqtop">
                        人员流动概况表</td>
		          </tr>
		        </table>
	        </td></tr>
            <tr>
                <td>
                    <asp:Table ID="tbComeAndLeaveList" runat="server" CssClass="linetablepart" Cellpadding="10" Cellspacing="0" Width="100%">
                    </asp:Table></td>
            </tr>
        </table>
     </td>
  </tr>
</table>
