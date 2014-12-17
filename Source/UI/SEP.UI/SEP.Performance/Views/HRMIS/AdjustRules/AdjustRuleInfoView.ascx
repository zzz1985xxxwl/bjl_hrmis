<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdjustRuleInfoView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.AdjustRules.AdjustRuleInfoView" %>
<%@ Register Src="AdjustRuleEditView.ascx" TagName="AdjustRuleEditView" TagPrefix="uc1" %>
<%@ Register Src="AdjustRuleListView.ascx" TagName="AdjustRuleListView" TagPrefix="uc2" %>

       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
            <ajaxToolKit:ModalPopupExtender id="mpeAdjustRule" runat="server" Drag="false" 
             BackgroundCssClass="modalBackground" 
            PopupControlID="pnlRule" TargetControlID="btnHiddenPostButton"></ajaxToolKit:ModalPopupExtender>
            <asp:Button ID="btnHiddenPostButton" runat="Server" Style="display: none" />
            <!--小界面-->
<div id="divMPE">
	        <asp:Panel ID="pnlRule" runat="server" CssClass="modalBox" Style="display: none;" Width="400px">
		        <div style="white-space: nowrap; text-align: center;">
<uc1:AdjustRuleEditView id="AdjustRuleEditView1" runat="server">
</uc1:AdjustRuleEditView></div>
	        </asp:Panel>
	        </div>
        	        <!--大界面-->
<uc2:AdjustRuleListView ID="AdjustRuleListView1" runat="server" />
    </ContentTemplate>
    </asp:UpdatePanel>
