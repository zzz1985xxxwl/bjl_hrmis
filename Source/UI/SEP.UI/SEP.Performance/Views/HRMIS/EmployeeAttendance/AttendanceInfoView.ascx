<%@ Control Language="C#" AutoEventWireup="true" Codebehind="AttendanceInfoView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.EmployeeAttendance.AttendanceInfoView" %>
<%@ Register Src="AttendanceSearchView.ascx" TagName="AttendanceSearchView" TagPrefix="uc1" %>
<%@ Register Src="RecordAttendanceView.ascx" TagName="RecordAttendanceView" TagPrefix="uc2" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <ajaxToolKit:ModalPopupExtender ID="mpeAttendance" runat="server" Drag="false" BackgroundCssClass="modalBackground"
            PopupControlID="pnlAttendance" TargetControlID="btnHiddenPostButton">
        </ajaxToolKit:ModalPopupExtender>
        <asp:Button ID="btnHiddenPostButton" runat="Server" Style="display: none" />
        <!--小界面-->
        <div id="divMPERecordAttendanceView">
            <asp:Panel ID="pnlAttendance" runat="server" CssClass="modalBox" Style="display: none;"
                Width="600px">
                <div style="white-space: nowrap; text-align: center;">
                    <uc2:RecordAttendanceView ID="RecordAttendanceView1" runat="server" />
                </div>
            </asp:Panel>
        </div>
        <!--大界面-->
        <uc1:AttendanceSearchView ID="AttendanceSearchView1" runat="server" />
    </ContentTemplate>
</asp:UpdatePanel>
