<%@ Import namespace="SEP.HRMIS.Model"%>
<%@ Import namespace="ShiXin.Security"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeCardView.ascx.cs" Inherits="SEP.Performance.Views.Employee.EmployeeCardView" %>
<div  runat="server" id="tbEmployeeCard" class="marginepx">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
   <tr>
   <td align="left">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
		  <tr>
		  <td>
		<asp:DataList ID="listEmployee" runat="server" RepeatColumns="3" Width="40%" ItemStyle-HorizontalAlign="Left"  >
            <ItemTemplate>
          <div class="ygcen">
		 <table width="100%" height="186" border="0" cellpadding="0" cellspacing="0">
			<tr>
		<td width="31%" height="25" align="center">
           <asp:LinkButton ID="btnUpdate" runat="server" Width="100%" Text="查看历史" CausesValidation="false" 
            CommandArgument='<%# Eval("Account.Id") %>' OnCommand="EmplyeeHistoryCommand" ToolTip="查看历史"/>
        </td>
        <td width="31%" align="center">
           <asp:LinkButton ID="btnVacation" runat="server" Width="100%" Text="年假管理" CausesValidation="false" 
            CommandArgument='<%# Eval("Account.Id") %>' OnCommand="Vacation_Command" ToolTip="年假管理"/>
        </td>
        <td width="31%" align="center">
           <asp:LinkButton ID="btnContract" runat="server" Width="100%" Text="合同管理" CausesValidation="false" 
            CommandArgument='<%# Eval("Account.Id") %>' OnCommand="Contract_Command" ToolTip="合同管理" />
        </td>
		</tr>
		<tr>
		<td height="161" align="center" class="ygcenf" valign="top">
		<a href='GetEmployeePhoto.aspx?id=<%# Eval("Account.Id")%>' title='<%# Eval("Account.Name")%>'><img  src="../../image/touxiang.jpg" onload="loadphoto(this);" accountid='<%# Eval("Account.Id")%>' width="61px" height="85px" class="employeePhoto" /></a><br /><asp:LinkButton ID="btnName" runat="server"  Text='<%# Eval("Account.Name")%>' href='<%# string.Format("EmployeeUpdate.aspx?employeeID={0}", SecurityUtil.DECEncrypt(Eval("Account.Id").ToString())) %>' /></td>
	    <td class="ygcenf2" colspan="2" >
	    <asp:Label ID="lblCompany" runat="server" Text='<%# Eval("EmployeeDetails.Work.Company.Name")%>'></asp:Label><br />
	    <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("Account.Dept.Name")%>'></asp:Label><br />
	    <asp:Label ID="lblPosition" runat="server" Text='<%# Eval("Account.Position.Name")%>'></asp:Label>
	    &nbsp;&nbsp;&nbsp;&nbsp;
	    ( <asp:Label ID="lblType" runat="server" Text='<%# EmployeeTypeUtility.EmployeeTypeDisplay((EmployeeTypeEnum)Eval("EmployeeType"))%>'></asp:Label> )<br />
	    <asp:Label ID="lblPhone" runat="server" Text='<%# Eval("Account.MobileNum") %>'></asp:Label><br />
	    入职时间&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
	    <font color="#db0000"><asp:Label ID="lblComeTime"   runat="server" Text='<%# string.Format("{0:yyyy-MM-dd}", Eval("EmployeeDetails.Work.ComeDate")).Equals("0001-01-01")? string.Empty: string.Format("{0:yyyy-MM-dd}",Eval("EmployeeDetails.Work.ComeDate"))%>'></asp:Label></font><br />
	    </td>
		</tr>
		</table>
			</div>
		  </ItemTemplate>
        </asp:DataList>
        </td>
</tr>
</table>
</td>
</tr>
<tr>
<td>
<div class="pages"  id="tbPage" runat="server" >       
<asp:Label ID="lblCurrent" runat="server" Text="0" Visible="false"></asp:Label>
            共&nbsp;<asp:Label ID="lblPageCount" runat="server"></asp:Label>&nbsp;页&nbsp;
		    第&nbsp;<asp:Label ID="lblPageIndex" runat="server"></asp:Label>&nbsp;页&nbsp;
		    <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CssClass="pagefirstbutton"  OnCommand="Page_Command" CommandArgument="First">
		    首页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"  OnCommand="Page_Command" CommandArgument="Prev">
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"  OnCommand="Page_Command" CommandArgument="Next">
		    下一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonLastPage" runat="server" CssClass="pagelastbutton"  OnCommand="Page_Command" CommandArgument="Last">
		    末页</asp:LinkButton>
		    转到&nbsp;<asp:TextBox ID="txtGoPage" runat="server" CssClass="input1" Width="20px"></asp:TextBox>&nbsp;页
		    <asp:LinkButton ID="LinkButtonGoPage" runat="server" CssClass="pagegobutton" OnClick="LinkButtonGoPage_Click">GO</asp:LinkButton>
</div> 
</td>
</tr>
</table>

</div>  
