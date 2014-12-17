<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowCalendarDetail.ascx.cs" Inherits="SEP.Performance.Views.SEP.Calendar.ShowCalendarDetail" %>
<%@ Register Src="ShowDetailViewAttendance.ascx" TagName="ShowDetailViewAttendance"
    TagPrefix="uc1" %>
<%@ Register Src="ShowDetailView.ascx" TagName="ShowDetailView" TagPrefix="uc2" %>
<link href="../CSS/style.css" rel="stylesheet" type="text/css" />

<div class="infoborder">
  <div class="infoicon" style="text-align:left">
		<div class="closebt">
		<asp:ImageButton ImageUrl="../../../Pages/image/closebt.jpg" ID="ImageButton1" runat="server" OnClick="ImageButton1_Click"  />
		</div>
	    <img src="../../image/infoicon.gif" width="20" height="20" align="absmiddle" /> 查看信息 <asp:Label ID="lblResultMessage" runat="server"  CssClass="fontred"></asp:Label>
      <asp:HiddenField ID="selectdate" runat="server" />
      <asp:HiddenField ID="lblEmployeeID" runat="server" />
      <asp:LinkButton ID="btnViewInOut" runat="server"  OnClick="btnViewInOut_Click" Font-Size="10pt" ForeColor="Blue">查看打卡信息</asp:LinkButton>&nbsp;
      <asp:LinkButton ID="btnSendEmail" runat="server" OnCommand="btnSendEmail_Click" Text="发送考勤信息"  Font-Size="10pt" ForeColor="Blue"></asp:LinkButton>
      <asp:LinkButton ID="btnViewRemind" Visible="false" runat="server"  OnClick="btnViewRemind_Click" Font-Size="10pt" ForeColor="Blue">查看详细提醒信息</asp:LinkButton>&nbsp;
      <asp:LinkButton ID="btnViewCalendar" Visible="false" runat="server"  OnClick="btnViewCalendar_Click" Font-Size="10pt" ForeColor="Blue">查看详细日程信息</asp:LinkButton>

    </div>
	<div id="ShowMenu"  runat="server" class="infotitlelist" style="text-align:left; height:28px; " >
	   <asp:ImageButton ID="IBAttendance" runat="server" OnClick="IBAttendance_Click"/><asp:ImageButton ID="IBLeaveRequest" runat="server" OnClick="IBLeaveRequest_Click"/><asp:ImageButton ID="IBOutApplication" runat="server" OnClick="IBOutApplication_Click" /><asp:ImageButton ID="IBOverWork" runat="server" OnClick="IBOverWork_Click" /><asp:ImageButton ID="IBLate" runat="server" OnClick="IBLate_Click" /><asp:ImageButton ID="IBEarlyLeave" runat="server" OnClick="IBEarlyLeave_Click" /><asp:ImageButton ID="IBAbsent" runat="server" OnClick="IBAbsent_Click" /><asp:ImageButton ID="IBRemind" runat="server" OnClick="IBRemind_Click" /><asp:ImageButton ID="IBCalendarEvent" runat="server" OnClick="IBCalendarEvent_Click" /></div>
	<div style="height:300px">
	         <div  runat="server" id="TabAttendance">
                 <uc1:ShowDetailViewAttendance id="ShowDetailViewAttendance" runat="server">
                 </uc1:ShowDetailViewAttendance>
             </div>
             <div runat="server" id="TabLeaveRequest">
                <uc2:ShowDetailView ID="ShowDetailViewLeaveRequest" runat="server" />
             </div>
             <div runat="server" id="TabOutApplication">
                 <uc2:ShowDetailView ID="ShowDetailViewOutApplication" runat="server" />
             </div>
             <div runat="server" id="TabOverWork">
                 <uc2:ShowDetailView ID="ShowDetailViewOverWork" runat="server" />
             </div>
             <div runat="server" id="TabLate">
                 <uc2:ShowDetailView ID="ShowDetailViewLate" runat="server" />
             </div>
             <div runat="server" id="TabEarlyLeave">
                 <uc2:ShowDetailView ID="ShowDetailViewEarlyLeave" runat="server" />
             </div>
             <div runat="server" id="TabAbsent" >
                 <uc2:ShowDetailView ID="ShowDetailViewAbsent" runat="server" />
             </div> 
             <div runat="server" id="TabRemind">
                 <uc2:ShowDetailView ID="ShowDetailViewRemind" runat="server" />
             </div>
             <div runat="server" id="TabCalendarEvent" >
                 <uc2:ShowDetailView ID="ShowDetailViewCalendarEvent" runat="server" />
             </div>
           </div>                             
</div>

