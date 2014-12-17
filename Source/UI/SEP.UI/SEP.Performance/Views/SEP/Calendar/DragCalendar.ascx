<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DragCalendar.ascx.cs" Inherits="SEP.Performance.Views.SEP.Calendar.DragCalendar" %>
<%@ Register Src="ShowCalendarDetail.ascx" TagName="ShowCalendarDetail"    TagPrefix="uc2" %>
<%@ Register Src="IndexDayAttendance.ascx" TagName="IndexDayAttendance"    TagPrefix="uc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">

    <ContentTemplate>
        <uc1:IndexDayAttendance ID="IndexDayAttendance1" runat="server" />
        <ajaxToolKit:ModalPopupExtender id="mpespecialDateEdit" runat="server" BackgroundCssClass="modalBackground"
  PopupControlID="pnlspecialDateEdit" 
  TargetControlID="btnHidden"></ajaxToolKit:ModalPopupExtender>
                    
<asp:Button ID="btnHidden" runat="Server" Style="display: none" />      
<div id="divMPEShowCalendarDetail">                 
<asp:Panel ID="pnlspecialDateEdit" runat="server" Style="display: none" >
	<div style="white-space: nowrap; text-align: left; " >
        <uc2:ShowCalendarDetail id="ShowCalendarDetail1" runat="server">
        </uc2:ShowCalendarDetail></div>
</asp:Panel>
</div>       

        </ContentTemplate>
</asp:UpdatePanel>