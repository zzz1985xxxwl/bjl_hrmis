<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TemplatePaperInfoView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.AssessManagement.TemplatePaperInfoView" %>
<%@ Register Src="TemplatePaperListView.ascx" TagName="TemplatePaperListView" TagPrefix="uc1" %>
<%@ Register Src="TemplatePaperView.ascx" TagName="TemplatePaperView" TagPrefix="uc2" %>

   
       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
            <ajaxToolKit:ModalPopupExtender id="mpeTemplatePaper" runat="server" Drag="true" 
            PopupDragHandleControlID="pnlTemplatePaper" BackgroundCssClass="modalBackground" 
            PopupControlID="pnlTemplatePaper" TargetControlID="btnHiddenPostButton"></ajaxToolKit:ModalPopupExtender>
            <asp:Button ID="btnHiddenPostButton" runat="Server" Style="display: none" />
            
            <!--小界面-->
            <div id="divPaper">
	        <asp:Panel ID="pnlTemplatePaper" runat="server" CssClass="modalBox" Style="display: none;" Width="600px">
		        <div style="white-space: nowrap; text-align: center;">
                   <uc2:TemplatePaperView ID="TemplatePaperView1" runat="server" />
		       
	        </asp:Panel>
	        </div>
	        <!--大界面-->
          <uc1:TemplatePaperListView ID="TemplatePaperListView1" runat="server" />
    </ContentTemplate>
    </asp:UpdatePanel>