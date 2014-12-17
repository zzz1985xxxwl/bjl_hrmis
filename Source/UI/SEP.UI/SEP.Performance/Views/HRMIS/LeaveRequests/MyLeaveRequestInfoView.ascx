<%@ Control Language="C#" AutoEventWireup="true" Codebehind="MyLeaveRequestInfoView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.LeaveRequests.MyLeaveRequestInfoView" %>
<%@ Register Src="MyLeaveRequestConfirmHistoryListView.ascx" TagName="MyLeaveRequestConfirmHistoryListView"
    TagPrefix="uc5" %>
<%@ Register Src="MyLeaveRequestConfirmListView.ascx" TagName="MyLeaveRequestConfirmListView"
    TagPrefix="uc4" %>
<%@ Register Src="MyLeaveRequestListView.ascx" TagName="MyLeaveRequestListView" TagPrefix="uc1" %>
<%@ Register Src="LeaveRequestOperationView.ascx" TagName="LeaveRequestOperationView"
    TagPrefix="uc2" %>
<%@ Register Src="../../Progressing.ascx" TagName="Progressing" TagPrefix="uc3" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="MyLeaveRequestConfirmListView1" />
        <asp:AsyncPostBackTrigger ControlID="LeaveRequestOperationView1" />
        <asp:AsyncPostBackTrigger ControlID="MyLeaveRequestListView1" />
    </Triggers>
    <ContentTemplate>
  <div id="divResultMessage" runat="server" style="display:none;" class="leftitbor">
 <asp:Label ID="lbResultMessage" runat="server" CssClass="fontred"></asp:Label>
</div>
 <div class="leftitbor" align="left">             
<span class="font14b">你共有 </span><span class="fontred">
    <asp:Label ID="lblLeaveRequestConfirmCount" runat="server"></asp:Label></span>
<span class="font14b">个请假单待审核;&nbsp;&nbsp;&nbsp;</span> <span class="font14b">申请了 </span>
<span class="fontred">
    <asp:Label ID="lblMyLeaveRequestCount" runat="server"></asp:Label></span> <span class="font14b">
        个请假单;&nbsp;&nbsp;&nbsp;</span> <span class="font14b">审核了 </span><span class="fontred">
            <asp:Label ID="lblMyLeaveRequestConfirmHistory" runat="server"></asp:Label></span>
<span class="font14b">个请假单&nbsp;&nbsp;&nbsp;</span>
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
                    <uc2:LeaveRequestOperationView ID="LeaveRequestOperationView1" runat="server"></uc2:LeaveRequestOperationView>
                </div>
            </asp:Panel>
        </div>
        <uc4:MyLeaveRequestConfirmListView ID="MyLeaveRequestConfirmListView1" runat="server" />
        <uc1:MyLeaveRequestListView ID="MyLeaveRequestListView1" runat="server"></uc1:MyLeaveRequestListView>
        <uc5:MyLeaveRequestConfirmHistoryListView ID="MyLeaveRequestConfirmHistoryListView1"
            runat="server" />
        <%--<uc3:MyLeaveRequestConfirmHistoryListView ID="MyLeaveRequestConfirmHistoryListView1"
                runat="server" />--%>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc3:Progressing ID="Progressing1" runat="server"></uc3:Progressing>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </ContentTemplate>
</asp:UpdatePanel>
