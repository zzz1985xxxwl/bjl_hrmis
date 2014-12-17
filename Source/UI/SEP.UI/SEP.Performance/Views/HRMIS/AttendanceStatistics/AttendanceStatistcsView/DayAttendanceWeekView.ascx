<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DayAttendanceWeekView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.AttendanceStatistics.AttendanceStatistcsView.DayAttendanceWeekView" %>
<div>
		<table width="100%" border="0"  bcellpadding="0" cellspacing="0" style="text-align:center">
			<tr><td colspan="8">
			<table class="kqtop dayAttendanceWeekViewborder" 
            height="28" cellSpacing="0" cellPadding="0" width="100%" border="0">
              <TR class="dayAttendanceWeekViewtr">
                <TD width="16%">员工姓名</TD>
                <TD width="12%">星期一</TD>
                <TD width="12%">星期二</TD>
                <TD width="12%">星期三</TD>
                <TD width="12%">星期四</TD>
                <TD width="12%">星期五</TD>
                <TD width="12%"><FONT color="#cf0000">星期六</FONT></TD>
                <TD width="12%"><FONT color="#cf0000">星期日</FONT></TD></TR></table>
	  </td></tr>
	<TR style="HEIGHT: 25px" class="green1">
	<td><table width="100%" bcellpadding="0" cellspacing="0" style="text-align:center"><tr>
	<td align="center" valign="center" class="tdborder1" >
		<asp:ImageButton ID="IbtnLast" runat="server" ImageUrl="../../../../Pages/image/kqleft.png"
            OnClick="IbtnLast_Click"  />
          <asp:TextBox ID="txtYear" runat="server" CssClass="input1" Width="30px" AutoPostBack="True" OnTextChanged="txtYear_TextChanged">2008</asp:TextBox>
          年
         <asp:DropDownList ID="ddMonth" runat="server" Width="40px" autopostback="true" OnSelectedIndexChanged="ddMonth_SelectedIndexChanged">
                      <asp:ListItem>1</asp:ListItem>
                      <asp:ListItem>2</asp:ListItem>
                      <asp:ListItem>3</asp:ListItem>
                      <asp:ListItem>4</asp:ListItem>
                      <asp:ListItem>5</asp:ListItem>
                      <asp:ListItem>6</asp:ListItem>
                      <asp:ListItem>7</asp:ListItem>
                      <asp:ListItem>8</asp:ListItem>
                      <asp:ListItem>9</asp:ListItem>
                      <asp:ListItem>10</asp:ListItem>
                      <asp:ListItem>11</asp:ListItem>
                      <asp:ListItem>12</asp:ListItem>
                      </asp:DropDownList> 月
        <asp:ImageButton ID="IBtnNext" runat="server" ImageUrl="../../../../Pages/image/kqright.png"
            OnClick="IBtnNext_Click" />
            <div style=" position:absolute;"><asp:Label ID="lblValidateYear" runat="server"  CssClass="psword_f"></asp:Label></div>
        </td> 
     	<td width="12%" align="center" valign="center"  class="kqfont01 tdborder2">
				<asp:Label ID="lblMon" runat="server" Text="" /></td>
		<td width="12%" align="center" valign="center"  class="kqfont01 tdborder2">
				<asp:Label ID="lblTues" runat="server" Text="" /></td>				
		<td width="12%" align="center" valign="center"  class="kqfont01 tdborder2">
				<asp:Label ID="lblWedn" runat="server" Text="" /></td>
		<td width="12%" align="center"  valign="center"  class="kqfont01 tdborder2">
				<asp:Label ID="lblThurs" runat="server" Text="" /></td>
		<td width="12%" align="center" valign="center"  class="kqfont01 tdborder2">
				<asp:Label ID="lblFri" runat="server" Text="" /></td>
		<td width="12%" align="center"  valign="center"  class="kqfont01 tdborder2">
				<asp:Label ID="lblSat" runat="server" Text=""/></td>
		<td width="12%" align="center" valign="center"  class="kqfont01 tdborder2">
		        <asp:Label ID="lblSun" runat="server" Text="" /></td>  
		        </tr></table></td> 
    	</tr>    
    </table>
		
</div>
<asp:DataList  ID="listDayAttendanceWeek" runat="server" RepeatColumns="1" Width="100%" ItemStyle-HorizontalAlign="Left" >
<ItemStyle />
<ItemTemplate >
<div>
		<table width="100%" border="0"  cellpadding="0" cellspacing="0" style="text-align:center">
			<tr >
		<td width="16%" class="tdborder1"  height="40" align="center" valign="center" bgcolor="#FFFFFF" >
        <asp:Label ID="EmployeeName" runat="server"  Text='<%# Eval("Account.Name")%>' /></td> 
     	<td width="12%" align="center" valign="center" class="tdborder2" bgcolor='<%# Eval("EmployeeAttendance.DayAttendanceWeek.MonColor")%>'>
		<asp:LinkButton ID="btnMon" runat="server" ForeColor="#1c7711" Text='<%# Eval("EmployeeAttendance.DayAttendanceWeek.Mon")%>' OnCommand="DateSlection_Command" CommandName="Mon" CommandArgument='<%# Eval("Account.Id")+";"+ Eval("Account.Name")+";"+  Eval("EmployeeAttendance.AttendanceInAndOutStatistics.LeaveRequestAndOut")+ ";"+Eval("EmployeeAttendance.DayAttendanceWeek.Mon")%>'/></td>
		<td width="12%" align="center" valign="center" class="tdborder2"  bgcolor='<%# Eval("EmployeeAttendance.DayAttendanceWeek.TuesColor")%>' >
		<asp:LinkButton ID="btnTues" runat="server"  ForeColor="#1c7711"  Text='<%# Eval("EmployeeAttendance.DayAttendanceWeek.Tues")%>' OnCommand="DateSlection_Command" CommandName="Tues" CommandArgument='<%# Eval("Account.Id")+";"+ Eval("Account.Name")+";"+  Eval("EmployeeAttendance.AttendanceInAndOutStatistics.LeaveRequestAndOut") + ";"+Eval("EmployeeAttendance.DayAttendanceWeek.Tues")%>' /></td>				
		<td width="12%" align="center" valign="center"  class="tdborder2" bgcolor='<%# Eval("EmployeeAttendance.DayAttendanceWeek.WednColor")%>' >
		<asp:LinkButton ID="btnWed" runat="server"  ForeColor="#1c7711"  Text='<%# Eval("EmployeeAttendance.DayAttendanceWeek.Wedn")%>' OnCommand="DateSlection_Command" CommandName="Wedn" CommandArgument='<%# Eval("Account.Id")+";"+ Eval("Account.Name")+";"+  Eval("EmployeeAttendance.AttendanceInAndOutStatistics.LeaveRequestAndOut") + ";"+Eval("EmployeeAttendance.DayAttendanceWeek.Wedn")%>' /></td>
		<td width="12%" align="center" valign="center"  class="tdborder2" bgcolor='<%# Eval("EmployeeAttendance.DayAttendanceWeek.ThursColor")%>' >
		<asp:LinkButton ID="btnThurs" runat="server"  ForeColor="#1c7711"  Text='<%# Eval("EmployeeAttendance.DayAttendanceWeek.Thurs")%>' OnCommand="DateSlection_Command" CommandName="Thurs" CommandArgument='<%# Eval("Account.Id")+";"+ Eval("Account.Name")+";"+  Eval("EmployeeAttendance.AttendanceInAndOutStatistics.LeaveRequestAndOut") + ";"+Eval("EmployeeAttendance.DayAttendanceWeek.Thurs")%>' /></td>
		<td width="12%" align="center" valign="center"  class="tdborder2" bgcolor='<%# Eval("EmployeeAttendance.DayAttendanceWeek.FriColor")%>' >
		<asp:LinkButton ID="btnFri" runat="server"  ForeColor="#1c7711"  Text='<%# Eval("EmployeeAttendance.DayAttendanceWeek.Fri")%>' OnCommand="DateSlection_Command" CommandName="Fri" CommandArgument='<%# Eval("Account.Id")+";"+ Eval("Account.Name")+";"+  Eval("EmployeeAttendance.AttendanceInAndOutStatistics.LeaveRequestAndOut")+ ";"+Eval("EmployeeAttendance.DayAttendanceWeek.Fri")%>' /></td>
		<td width="12%" align="center" valign="center"  class="tdborder2" bgcolor='<%# Eval("EmployeeAttendance.DayAttendanceWeek.SatColor")%>'>
		<asp:LinkButton ID="btnSat" runat="server"  ForeColor="#1c7711"  Text='<%# Eval("EmployeeAttendance.DayAttendanceWeek.Sat")%>' OnCommand="DateSlection_Command" CommandName="Sat" CommandArgument='<%# Eval("Account.Id")+";"+ Eval("Account.Name")+";"+  Eval("EmployeeAttendance.AttendanceInAndOutStatistics.LeaveRequestAndOut") + ";"+Eval("EmployeeAttendance.DayAttendanceWeek.Sat")%>' /></td>
		<td width="12%" align="center" valign="center"  class="tdborder2" bgcolor='<%# Eval("EmployeeAttendance.DayAttendanceWeek.SunColor")%>'>
		<asp:LinkButton ID="btnSun" runat="server"  ForeColor="#1c7711"  Text='<%# Eval("EmployeeAttendance.DayAttendanceWeek.Sun")%>' OnCommand="DateSlection_Command" CommandName="Sun" CommandArgument='<%# Eval("Account.Id")+";"+ Eval("Account.Name")+";"+  Eval("EmployeeAttendance.AttendanceInAndOutStatistics.LeaveRequestAndOut")+ ";"+Eval("EmployeeAttendance.DayAttendanceWeek.Sun")%>'/></td>     	

     	</tr>
		</table>
</div>
			
</ItemTemplate>
</asp:DataList>
<div class="pages" id="tbPage" runat="server">
                              
		    共&nbsp;<asp:Label ID="lblAllPage" runat="server" Text="1" ></asp:Label>&nbsp;页&nbsp;
		    第&nbsp;<asp:Label ID="lblCurrent" runat="server" Text="1" ></asp:Label>&nbsp;页&nbsp;
		    <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CssClass="pagefirstbutton" OnCommand="Page_Command" CommandArgument="First" CommandName="Page" >
		    首页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" OnCommand="Page_Command" CommandArgument="Prev" CommandName="Page" >
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" OnCommand="Page_Command" CommandArgument="Next" CommandName="Page" >
		    下一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonLastPage" runat="server" CssClass="pagelastbutton" OnCommand="Page_Command" CommandArgument="Last" CommandName="Page"  >
		    末页</asp:LinkButton>
		    转到&nbsp;<asp:TextBox ID="txtGoPage" runat="server" CssClass="input1" Width="20px"></asp:TextBox>&nbsp;页
		    <asp:LinkButton ID="LinkButtonGoPage" runat="server" CssClass="pagegobutton" OnClick="LinkButtonGoPage_Click">GO</asp:LinkButton>   
		
               <%-- <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                                CommandArgument="Prev" CommandName="Page"  OnCommand="Page_Command">
		    上一页</asp:LinkButton> 
                <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                                CommandArgument="Next" CommandName="Page"  OnCommand="Page_Command">
		    下一页</asp:LinkButton>  --%>                         
                            
                        </div>
<asp:HiddenField ID="lblDate" runat="server" Value="0" />



