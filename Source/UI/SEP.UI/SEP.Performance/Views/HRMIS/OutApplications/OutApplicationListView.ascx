<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OutApplicationListView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.OutApplications.AllOutApplication" %>
<%@ Register Src="OutApplicationConfirmListView.ascx" TagName="OutApplicationConfirmListView"
    TagPrefix="uc1" %>
<%@ Register Src="OutApplicationSelfListView.ascx" TagName="OutApplicationSelfListView"
    TagPrefix="uc2" %>
    <%@ Register Src="OutApplicationConfirmHistroyView.ascx" TagName="OutApplicationSelfListView"
    TagPrefix="uc3" %>
<%@ Register Src="OperationView.ascx" TagName="OperationView"
    TagPrefix="uc4" %>
<%@ Register Src="../../Progressing.ascx" TagName="Progressing" TagPrefix="uc5" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="OutApplicationConfirmListView1" />
        <asp:AsyncPostBackTrigger ControlID="OutApplicationSelfListView1" />
        <asp:AsyncPostBackTrigger ControlID="OutApplicationConfirmHistroyView1" />
    </Triggers>
    <ContentTemplate>
                    <div class="leftitbor">
                                <span class="font14b">你共有 </span><span class="fontred">
                                    <asp:Label ID="lblOutApplicationConfirmCount" runat="server"></asp:Label></span>
                                <span class="font14b">个外出单待审核;&nbsp;&nbsp;&nbsp;</span> <span class="font14b">申请了 </span>
                                <span class="fontred">
                                    <asp:Label ID="lblOutApplicationCount" runat="server"></asp:Label></span> <span class="font14b">
                                        个外出单;&nbsp;&nbsp;&nbsp;</span> <span class="font14b">审核了 </span><span class="fontred">
                                            <asp:Label ID="lblOutApplicationHistoryCount" runat="server"></asp:Label></span>
                                <span class="font14b">个外出单</span>
                    </div>
       
        <ajaxToolKit:ModalPopupExtender ID="mpeOperation" runat="server" Drag="true" PopupDragHandleControlID="pnlOperation"
            BackgroundCssClass="modalBackground" PopupControlID="pnlOperation" TargetControlID="btnHidden">
        </ajaxToolKit:ModalPopupExtender>
        <asp:Button ID="btnHidden" runat="Server" Style="display: none" />
        <asp:HiddenField ID="Operation" runat="server" />
        <div id="divMPEMyLeaveRequest" runat="server">
            <asp:Panel ID="pnlOperation" runat="server" CssClass="modalBox" Style="display: none;"
                Width="600px">
                <div style="white-space: nowrap; text-align: center;">
                    <uc4:OperationView ID="OperationView1" runat="server"></uc4:OperationView>
                    
                </div>
            </asp:Panel>
        </div>
<uc1:OutApplicationConfirmListView ID="OutApplicationConfirmListView1" runat="server" />
<uc2:OutApplicationSelfListView ID="OutApplicationSelfListView1" runat="server" />
<uc3:OutApplicationSelfListView ID="OutApplicationConfirmHistroyView1" runat="server" />
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc5:progressing id="Progressing1" runat="server"></uc5:progressing>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </ContentTemplate>
</asp:UpdatePanel>