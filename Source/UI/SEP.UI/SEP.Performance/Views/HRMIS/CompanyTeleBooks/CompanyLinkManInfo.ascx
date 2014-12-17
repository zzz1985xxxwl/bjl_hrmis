<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CompanyLinkManInfo.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.CompanyTeleBooks.CompanyLinkManInfo" %>
<%@ Register Src="CompanyLinkManView.ascx" TagName="CompanyLinkManView" TagPrefix="uc2" %>
<%@ Register Src="CompanyLinkManListView.ascx" TagName="CompanyLinkManListView" TagPrefix="uc1" %>
<link href="../../../Pages/CSS/style.css" rel="stylesheet" type="text/css" />
       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
            <ajaxToolKit:ModalPopupExtender id="mpeCompanyLinkMan" runat="server" Drag="true" 
            PopupDragHandleControlID="pnlCompanyLinkMan" BackgroundCssClass="modalBackground" 
            PopupControlID="pnlCompanyLinkMan" TargetControlID="btnHiddenPostButton"></ajaxToolKit:ModalPopupExtender>
            <asp:Button ID="btnHiddenPostButton" runat="Server" Style="display: none" />
            <!--小界面-->
            <div id="divMPE">
	        <asp:Panel ID="pnlCompanyLinkMan" runat="server" CssClass="modalBox" Style="display: none;" Width="600px">
		        <div style="white-space: nowrap; text-align: center;">
                    <uc2:CompanyLinkManView id="CompanyLinkManView1" runat="server">
                    </uc2:CompanyLinkManView></div>
	        </asp:Panel>
	        </div>
	        <!--大界面-->
   <uc1:CompanyLinkManListView id="CompanyLinkManListView1" runat="server">
                    </uc1:CompanyLinkManListView>
    </ContentTemplate>
    </asp:UpdatePanel>