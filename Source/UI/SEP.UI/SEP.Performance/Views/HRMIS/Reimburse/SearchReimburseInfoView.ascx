<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchReimburseInfoView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.Reimburse.SearchReimburseInfoView" %>
<%@ Register Src="SearchReimburseView.ascx" TagName="SearchReimburseView" TagPrefix="uc2" %>
<%@ Register Src="BillingTimeDetail.ascx" TagName="BillingTimeDetail" TagPrefix="uc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <ajaxToolKit:ModalPopupExtender ID="mpeSearchReimburse" runat="server" BackgroundCssClass="modalBackground"
            Drag="true" PopupControlID="pnlBillingTimeDetail" PopupDragHandleControlID="pnlBillingTimeDetail"
            TargetControlID="btnHiddenPostButton">
        </ajaxToolKit:ModalPopupExtender>
        <asp:Button ID="btnHiddenPostButton" runat="Server" Style="display: none" />
        <!--小界面-->
        <div id="divPaper">
            <asp:Panel ID="pnlBillingTimeDetail" runat="server" CssClass="modalBox" Style="display: none;"
                Width="615px">
                <div style="white-space: nowrap; text-align: center;">
                    <uc1:BillingTimeDetail id="BillingTimeDetail1" runat="server">
</uc1:BillingTimeDetail>
                </div>
                </asp:Panel>
        </div>
        <!--大界面-->
        <uc2:SearchReimburseView id="SearchReimburseView1" runat="server">
</uc2:SearchReimburseView>
    </ContentTemplate>
</asp:UpdatePanel> 







