<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SkillInfoView.ascx.cs" Inherits="SEP.Performance.Views.Skill.SkillInfoView" %>
<%@ Register Src="SkillListView.ascx" TagName="SkillListView" TagPrefix="uc1" %>
<%@ Register Src="SkillView.ascx" TagName="SkillView" TagPrefix="uc2" %>

       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
            <ajaxToolKit:ModalPopupExtender id="mpeSkill" runat="server" Drag="true" 
            PopupDragHandleControlID="pnlSkill" BackgroundCssClass="modalBackground" 
            PopupControlID="pnlSkill" TargetControlID="btnHiddenPostButton"></ajaxToolKit:ModalPopupExtender>
            <asp:Button ID="btnHiddenPostButton" runat="Server" Style="display: none" />
            <!--小界面-->
            <div id="divSkill">
	        <asp:Panel ID="pnlSkill" runat="server" CssClass="modalBox" Style="display: none;" Width="600px">
		        <div style="white-space: nowrap; text-align: center;">
                   <uc2:SkillView ID="SkillView1" runat="server" />
		        </div>
	        </asp:Panel>
	        </div>
	        <!--大界面-->
          <uc1:SkillListView ID="SkillListView1" runat="server" />
    </ContentTemplate>
    </asp:UpdatePanel>