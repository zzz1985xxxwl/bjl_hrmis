<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="DayAttendance.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AttendancePages.DayAttendance" %>

<%@ Register Src="../../../Views/HRMIS/AttendanceStatistics/AttendanceStatistcsView/DayAttendanceView.ascx"
    TagName="DayAttendanceView" TagPrefix="uc1" %>
<%@ Register Src="../../../Views/SEP/Calendar/ShowCalendarDetail.ascx" TagName="ShowCalendarDetail"
    TagPrefix="uc2" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
           
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<Triggers>
<asp:AsyncPostBackTrigger ControlID="DayAttendanceView1"/>
</Triggers>
    <ContentTemplate>
         <uc1:DayAttendanceView id="DayAttendanceView1" runat="server">
        </uc1:DayAttendanceView>

        <ajaxToolKit:ModalPopupExtender id="mpeShowCalendarDetail" runat="server" BackgroundCssClass="modalBackground"
  PopupControlID="pnlShowCalendarDetail" 
  TargetControlID="btnHidden"></ajaxToolKit:ModalPopupExtender>
                    
<asp:Button ID="btnHidden" runat="Server" Style="display: none" />      
<div id="divMPEShowCalendarDetail">              
<asp:Panel ID="pnlShowCalendarDetail" runat="server" Style="display: none" >
	<div style="white-space: nowrap; text-align: left; " >
        <uc2:ShowCalendarDetail ID="ShowCalendarDetail1" runat="server" /></div>
</asp:Panel>
</div>
        </ContentTemplate>
</asp:UpdatePanel>        
<asp:Button ID="btnExportServer" runat="server" Text="Button" OnClick="btnExportServer_Click"  style="display:none;"/>
    </asp:Content>  
