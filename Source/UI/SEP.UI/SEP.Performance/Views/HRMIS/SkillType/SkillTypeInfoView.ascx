<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SkillTypeInfoView.ascx.cs" Inherits="SEP.Performance.Views.SkillType.SkillTypeInfoView" %>
<%@ Register Src="SkillTypeListView.ascx" TagName="SkillTypeListView" TagPrefix="uc1" %>
<%@ Register Src="SkillTypeView.ascx" TagName="SkillTypeView" TagPrefix="uc2" %>

       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
            <ajaxToolKit:ModalPopupExtender id="mpeSkillType" runat="server" Drag="true" 
            PopupDragHandleControlID="pnlSkillType" BackgroundCssClass="modalBackground" 
            PopupControlID="pnlSkillType" TargetControlID="btnHiddenPostButton"></ajaxToolKit:ModalPopupExtender>
            <asp:Button ID="btnHiddenPostButton" runat="Server" Style="display: none" />
            <!--小界面-->
             <div id="divSkillType">
	        <asp:Panel ID="pnlSkillType" runat="server" CssClass="modalBox" Style="display: none;" Width="600px">
		        <div style="white-space: nowrap; text-align: center;">
                   <uc2:SkillTypeView ID="SkillTypeView1" runat="server" />
		        </div>
	        </asp:Panel>
	        <!--大界面-->
	         </div>
          <uc1:SkillTypeListView ID="SkillTypeListView1" runat="server" />
    </ContentTemplate>
    </asp:UpdatePanel>