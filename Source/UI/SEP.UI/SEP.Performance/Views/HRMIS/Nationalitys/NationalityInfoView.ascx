<%@ Control Language="C#" AutoEventWireup="true" Codebehind="NationalityInfoView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.Nationalitys.NationalityInfoView" %>
<%@ Register Src="NationalityListView.ascx" TagName="NationalityListView" TagPrefix="uc1" %>
<%@ Register Src="NationalityView.ascx" TagName="NationalityView" TagPrefix="uc2" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <ajaxToolKit:ModalPopupExtender ID="mpeNationality" runat="server" Drag="true" PopupDragHandleControlID="pnlNationality"
            BackgroundCssClass="modalBackground" PopupControlID="pnlNationality" TargetControlID="btnHiddenPostButton">
        </ajaxToolKit:ModalPopupExtender>
        <asp:Button ID="btnHiddenPostButton" runat="Server" Style="display: none" />
        <!--小界面-->
        <div id="divMPE">
            <asp:Panel ID="pnlNationality" runat="server" CssClass="modalBox" Style="display: none;"
                Width="600px">
                <div style="white-space: nowrap; text-align: center;">
                    <uc2:NationalityView id="NationalityView1" runat="server">
                    </uc2:NationalityView>
                </div>
            </asp:Panel>
        </div>
        <!--大界面-->
        <uc1:NationalityListView id="NationalityListView1" runat="server">
        </uc1:NationalityListView>
    </ContentTemplate>
</asp:UpdatePanel>
