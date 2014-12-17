<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DutyClassInfoView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.AttendanceStatistics.PlanDutyViews.DutyClassInfoView1" %>
<%@ Register Src="DutyClassView.ascx" TagName="DutyClassView" TagPrefix="uc1" %>
<%@ Register Src="DutyClassListView.ascx" TagName="DutyClassListView" TagPrefix="uc2" %>

       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
            <ajaxToolKit:ModalPopupExtender id="mpeDutyClass" runat="server" Drag="true" 
            PopupDragHandleControlID="pnlRule" BackgroundCssClass="modalBackground" 
            PopupControlID="pnlRule" TargetControlID="btnHiddenPostButton"></ajaxToolKit:ModalPopupExtender>
            <asp:Button ID="btnHiddenPostButton" runat="Server" Style="display: none" />
            <!--小界面-->
                        <div id="divMPE">
	        <asp:Panel ID="pnlRule" runat="server" CssClass="modalBox" Style="display: none;" Width="700px">
		        <div style="white-space: nowrap; text-align: center;">
<uc1:DutyClassView id="DutyClassView1" runat="server">
</uc1:DutyClassView></div>
	        </asp:Panel>
	        </div>
        	        <!--大界面-->
<uc2:DutyClassListView id="DutyClassListView1" runat="server">
</uc2:DutyClassListView>
    </ContentTemplate>
    </asp:UpdatePanel>