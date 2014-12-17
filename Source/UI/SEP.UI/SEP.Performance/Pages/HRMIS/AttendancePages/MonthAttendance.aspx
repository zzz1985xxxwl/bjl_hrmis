﻿<%@ Page Language="C#" MasterPageFile ="../MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="MonthAttendance.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AttendancePages.MonthAttendance" %>
<%@ Register Src="../../../Views/SEP/Calendar/ShowCalendarDetail.ascx" TagName="ShowCalendarDetail"
    TagPrefix="uc3" %>

<%@ Register Src="../../../Views/SEP/Calendar/MyDayAttendance.ascx" TagName="MyDayAttendance"
    TagPrefix="uc2" %>

<%@ Register Src="../../../Views/HRMIS/AttendanceStatistics/AttendanceStatistcsView/MonthAttendanceView.ascx" TagName="MonthAttendanceView"
    TagPrefix="uc1" %>
<%@ Register Src="../../../Views/Progressing.ascx" TagName="Progressing" TagPrefix="uc6" %>

<asp:Content ID="cphPage" ContentPlaceHolderID="cphCenter" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<Triggers>
<asp:AsyncPostBackTrigger ControlID="MonthAttendanceView1"/>
<asp:AsyncPostBackTrigger ControlID="MyDayAttendance1"/>
</Triggers>
            <ContentTemplate>
                    <!--日历界面 -->
                    <ajaxToolKit:ModalPopupExtender id="mpeMyDayAttendance" runat="server" Drag="true" 
                    PopupDragHandleControlID="pnlMyDayAttendance" BackgroundCssClass="modalBackground" PopupControlID="pnlMyDayAttendance" 
                    TargetControlID="btnHidden"></ajaxToolKit:ModalPopupExtender>
                    
                    <asp:Button ID="btnHidden" runat="Server" Style="display: none" />
                    <div id="divMPEMyDayAttendance" runat="server">                         
			        <asp:Panel ID="pnlMyDayAttendance" runat="server" CssClass="modalBox" Style="display: none;" Width="700px">
				        <div style="white-space: nowrap; text-align: center;">

                            <uc2:MyDayAttendance ID="MyDayAttendance1" runat="server" />

				        </div>
			        </asp:Panel>
			        </div>
                                <!--详情界面 -->
                                <ajaxToolKit:ModalPopupExtender id="mpeMyDayAttendanceDetail" runat="server" Drag="true" 
                                PopupDragHandleControlID="pnlMyDayAttendanceDetail" BackgroundCssClass="modalBackground" PopupControlID="pnlMyDayAttendanceDetail" 
                                TargetControlID="btnHidden2"></ajaxToolKit:ModalPopupExtender>
                                
                                <asp:Button ID="btnHidden2" runat="Server" Style="display: none" />
                                <div id="divMPEShowCalendarDetail">                         
                                <asp:Panel ID="pnlMyDayAttendanceDetail" runat="server" Style="display: none;">
                                    <div style="white-space: nowrap; text-align: center;">

                                        <uc3:ShowCalendarDetail ID="ShowCalendarDetail1" runat="server" />

                                    </div>
                                </asp:Panel>
                                </div>    
                    <uc1:MonthAttendanceView id="MonthAttendanceView1" runat="server">
                    </uc1:MonthAttendanceView>
                    
        <!--Loading界面 -->
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc6:Progressing id="Progressing1" runat="server">
                </uc6:Progressing>
            </ProgressTemplate>
        </asp:UpdateProgress>

            </ContentTemplate>
   
</asp:UpdatePanel>
<asp:Button ID="btnExportServer" runat="server" Text="Button" OnClick="btnExportServer_Click" style="display:none;"/>

</asp:Content>
