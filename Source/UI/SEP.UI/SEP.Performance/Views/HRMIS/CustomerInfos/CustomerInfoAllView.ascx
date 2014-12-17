<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomerInfoAllView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.CustomerInfos.CustomerInfoAllView" %>
<%@ Register Src="CustomerInfoView.ascx" TagName="CustomerInfoView" TagPrefix="uc1" %>
<%@ Register Src="CustomerInfoListView.ascx" TagName="CustomerInfoListView" TagPrefix="uc2" %>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
            <ajaxToolKit:ModalPopupExtender id="mpeInfo" runat="server" Drag="false" 
             BackgroundCssClass="modalBackground" 
            PopupControlID="pnlRule" TargetControlID="btnHiddenPostButton"></ajaxToolKit:ModalPopupExtender>
            <asp:Button ID="btnHiddenPostButton" runat="Server" Style="display: none" />
            <!--小界面-->
<div id="divMPE">
	        <asp:Panel ID="pnlRule" runat="server" CssClass="modalBox" Style="display: none;" Width="600px">
		        <div style="white-space: nowrap; text-align: center;">
                    <uc1:CustomerInfoView id="CustomerInfoView1" runat="server">
                    </uc1:CustomerInfoView></div>
	        </asp:Panel>
	        </div>
        	        <!--大界面-->
      <uc2:CustomerInfoListView id="CustomerInfoListView1" runat="server">
        </uc2:CustomerInfoListView>
    </ContentTemplate>
    </asp:UpdatePanel>