<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PersonalInAndOutInfoView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AttendanceStatistics.AttendanceInAndOutStatistics.PersonalInAndOutInfoView" %>
<%@ Register Src="PersonalInAndOutView.ascx" TagName="PersonalInAndOutView" TagPrefix="uc1" %>
<%@ Register Src="PersonalInAndOutListView.ascx" TagName="PersonalInAndOutListView"
    TagPrefix="uc2" %>
<%@ Register Src="../../../Progressing.ascx" TagName="Progressing" TagPrefix="uc6" %>
<link href="../../CSS/style.css" rel="stylesheet" type="text/css" />

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <ajaxToolKit:ModalPopupExtender ID="mpeInAndOut" runat="server" Drag="false" BackgroundCssClass="modalBackground"
            PopupControlID="pnlInAndOut" TargetControlID="btnHiddenPostButton">
        </ajaxToolKit:ModalPopupExtender>
        <asp:Button ID="btnHiddenPostButton" runat="Server" Style="display: none" />
        <!--小界面-->
        <asp:Panel ID="pnlInAndOut" runat="server" CssClass="modalBox" Style="display: none;"
            Width="600px">
            <div style="white-space: nowrap; text-align: center;">
                <uc1:PersonalInAndOutView ID="PersonalInAndOutView1" runat="server"></uc1:PersonalInAndOutView>
            </div>
        </asp:Panel>
        <uc2:PersonalInAndOutListView ID="PersonalInAndOutListView1" runat="server"></uc2:PersonalInAndOutListView>
        <!--大界面-->
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc6:Progressing id="Progressing1" runat="server">
                </uc6:Progressing>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </ContentTemplate>
</asp:UpdatePanel>
