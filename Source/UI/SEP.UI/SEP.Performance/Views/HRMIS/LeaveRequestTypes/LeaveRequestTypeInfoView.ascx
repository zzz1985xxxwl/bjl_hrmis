<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeaveRequestTypeInfoView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.LeaveRequestTypes.LeaveRequestTypeInfoView" %>
<%@ Register Src="LeaveRequestTypeListView.ascx" TagName="LeaveRequestTypeListView" TagPrefix="uc1" %>
<%@ Register Src="LeaveRequestTypeView.ascx" TagName="LeaveRequestTypeView" TagPrefix="uc2" %>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
            <ajaxToolKit:ModalPopupExtender id="mpeLeaveRequestType" runat="server" Drag="true" 
            PopupDragHandleControlID="pnlLeaveRequestType" BackgroundCssClass="modalBackground" 
            PopupControlID="pnlLeaveRequestType" TargetControlID="btnHiddenPostButton"></ajaxToolKit:ModalPopupExtender>
            <asp:Button ID="btnHiddenPostButton" runat="Server" Style="display: none" />
            <!--小界面-->
            <div id="divMPE">
	        <asp:Panel ID="pnlLeaveRequestType" runat="server" CssClass="modalBox" Style="display: none;" Width="700px">
		        <div style="white-space: nowrap; text-align: center;">
                   <uc2:LeaveRequestTypeView ID="LeaveRequestTypeView1" runat="server" />
		        </div>
	        </asp:Panel>
	        </div>
	        <!--大界面-->
          <uc1:LeaveRequestTypeListView ID="LeaveRequestTypeListView1" runat="server" />
    </ContentTemplate>
    </asp:UpdatePanel>