<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyTrainApplicationInfoView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.TrainApplication.MyTrainApplicationInfoView" %>
<%@ Register Src="TrainApplicationOperationView.ascx" TagName="TrainApplicationOperationView"
    TagPrefix="uc5" %>
<%@ Register Src="TrainApplicationConfirmListView.ascx" TagName="TrainApplicationConfirmListView"
    TagPrefix="uc1" %>
<%@ Register Src="MyTrainApplicationView.ascx" TagName="MyTrainApplicationView" TagPrefix="uc2" %>
<%@ Register Src="TrainApplicationConfirmHistoryView.ascx" TagName="TrainApplicationConfirmHistoryView"
    TagPrefix="uc3" %>
    <%@ Register Src="../../Progressing.ascx" TagName="Progressing" TagPrefix="uc4" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <Triggers>
<asp:AsyncPostBackTrigger ControlID="TrainApplicationConfirmListView1" />
        <asp:AsyncPostBackTrigger ControlID="TrainApplicationOperationView1" />
        <asp:AsyncPostBackTrigger ControlID="MyTrainApplicationView1" />
    </Triggers>
    <ContentTemplate>
  <div id="divResultMessage" runat="server" style="display:none;" class="leftitbor">
 <asp:Label ID="lbResultMessage" runat="server" CssClass="fontred"></asp:Label>
</div>
 <div class="leftitbor" align="left">             
<span class="font14b">你共有 </span><span class="fontred">
    <asp:Label ID="lblConfirmCount" runat="server"></asp:Label></span>
<span class="font14b">个培训申请单待审核;&nbsp;&nbsp;&nbsp;</span> <span class="font14b">申请了 </span>
<span class="fontred">
    <asp:Label ID="lblMyTrainApplicationCount" runat="server"></asp:Label></span> <span class="font14b">
        个培训;&nbsp;&nbsp;&nbsp;</span> <span class="font14b">审核了 </span><span class="fontred">
            <asp:Label ID="lblMyConfirmHistory" runat="server"></asp:Label></span>
<span class="font14b">个培训申请&nbsp;&nbsp;&nbsp;</span>
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
                    <uc5:TrainApplicationOperationView id="TrainApplicationOperationView1" runat="server">
                    </uc5:TrainApplicationOperationView></div>
            </asp:Panel>
        </div>
         <uc1:TrainApplicationConfirmListView ID="TrainApplicationConfirmListView1" runat="server" />
        <uc2:MyTrainApplicationView ID="MyTrainApplicationView1" runat="server" />
        <uc3:TrainApplicationConfirmHistoryView ID="TrainApplicationConfirmHistoryView1"
            runat="server" />
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc4:Progressing ID="Progressing1" runat="server"></uc4:Progressing>
            </ProgressTemplate>
        </asp:UpdateProgress>
  
    </ContentTemplate>
</asp:UpdatePanel>