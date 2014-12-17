<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PositionInfoView.ascx.cs"
    Inherits="SEP.Performance.Views.SEP.Positions.PositionInfoView" %>
<%@ Register Src="PositionListView.ascx" TagName="PositionListView" TagPrefix="uc1" %>
<%@ Register Src="PositionView.ascx" TagName="PositionView" TagPrefix="uc2" %>
<%@ Register Src="../../Progressing.ascx" TagName="Progressing" TagPrefix="uc3" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <ajaxToolKit:ModalPopupExtender ID="mpePosition" runat="server" Drag="true" PopupDragHandleControlID="pnlPosition"
            BackgroundCssClass="modalBackground" PopupControlID="pnlPosition" TargetControlID="btnHiddenPostButton">
        </ajaxToolKit:ModalPopupExtender>
        <asp:Button ID="btnHiddenPostButton" runat="Server" Style="display: none" />
        <!--小界面-->
        <div id="divMPEPosition" runat="server">
            <asp:Panel ID="pnlPosition" runat="server" CssClass="modalBox" Style="display: none;"
                Width="600px">
                <div style="white-space: nowrap; text-align: center;">
                    <uc2:PositionView ID="PositionView1" runat="server" />
                </div>
            </asp:Panel>
        </div>
        <!--大界面-->
        <uc1:PositionListView ID="PositionListView1" runat="server" />
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc3:Progressing id="Progressing1" runat="server">
                </uc3:Progressing>
            </ProgressTemplate>
        </asp:UpdateProgress> 
    </ContentTemplate>
</asp:UpdatePanel>
