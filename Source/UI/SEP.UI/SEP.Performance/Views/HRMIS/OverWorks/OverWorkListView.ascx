<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OverWorkListView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.OverWorks.AllOverWork" %>
<%@ Register Src="OverWorkConfirmListView.ascx" TagName="OverWorkConfirmListView"
    TagPrefix="uc1" %>
<%@ Register Src="OverWorkSelfListView.ascx" TagName="OverWorkSelfListView"
    TagPrefix="uc2" %>
    <%@ Register Src="OverWorkConfirmHistroyView.ascx" TagName="OverWorkSelfListView"
    TagPrefix="uc3" %>
<%@ Register Src="OverWorkOperationView.ascx" TagName="OverWorkOperationView"
    TagPrefix="uc4" %>
<%@ Register Src="../../Progressing.ascx" TagName="Progressing" TagPrefix="uc5" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="OverWorkConfirmListView1" />
        <asp:AsyncPostBackTrigger ControlID="OverWorkSelfListView1" />
        <asp:AsyncPostBackTrigger ControlID="OverWorkConfirmHistroyView1" />
    </Triggers>
    <ContentTemplate>
                    <div width="98%" class="leftitbor">
                                <span class="font14b">你共有 </span><span class="fontred">
                                    <asp:Label ID="lblOverWorkConfirmCount" runat="server"></asp:Label></span>
                                <span class="font14b">个加班单待审核;&nbsp;&nbsp;&nbsp;</span> <span class="font14b">申请了 </span>
                                <span class="fontred">
                                    <asp:Label ID="lblOverWorkCount" runat="server"></asp:Label></span> <span class="font14b">
                                        个加班单;&nbsp;&nbsp;&nbsp;</span> <span class="font14b">审核了 </span><span class="fontred">
                                            <asp:Label ID="lblOverWorkHistoryCount" runat="server"></asp:Label></span>
                                <span class="font14b">个加班单</span> 
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
                    <uc4:OverWorkOperationView ID="OverOperationView1" runat="server"></uc4:OverWorkOperationView>
                    
                </div>
            </asp:Panel>
        </div>
<uc1:OverWorkConfirmListView ID="OverWorkConfirmListView1" runat="server" />
<uc2:OverWorkSelfListView ID="OverWorkSelfListView1" runat="server" />
<uc3:OverWorkSelfListView ID="OverWorkConfirmHistroyView1" runat="server" />
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc5:progressing id="Progressing1" runat="server"></uc5:progressing>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </ContentTemplate>
</asp:UpdatePanel>
<div style="margin-bottom:5px;"/>