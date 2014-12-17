<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FBQuesTypeInfoView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.FBQuesType.FBQuesTypeInfoView" %>
<%@ Register Src="FBQuesTypeListView.ascx" TagName="FBQuesTypeListView" TagPrefix="uc1" %>
<%@ Register Src="FBQuesTypeView.ascx" TagName="FBQuesTypeView" TagPrefix="uc2" %>

   <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
      <ajaxToolKit:ModalPopupExtender id="mpeFBQuesType" runat="server" Drag="true" 
            PopupDragHandleControlID="pnlFBQuesType" BackgroundCssClass="modalBackground" 
            PopupControlID="pnlFBQuesType" TargetControlID="btnHiddenPostButton"></ajaxToolKit:ModalPopupExtender>
            <asp:Button ID="btnHiddenPostButton" runat="Server" Style="display: none" />
             <div id="divMPE">
           <asp:Panel ID="pnlFBQuesType" runat="server" CssClass="modalBox" Style="display: none;" Width="600px">
		        <div style="white-space: nowrap; text-align: center;">
                   <uc2:FBQuesTypeView ID="FBQuesTypeView1" runat="server" />
		        </div>
	        </asp:Panel> 
	        </div>
<uc1:FBQuesTypeListView ID="FBQuesTypeListView1" runat="server" />
  </ContentTemplate>
    </asp:UpdatePanel>