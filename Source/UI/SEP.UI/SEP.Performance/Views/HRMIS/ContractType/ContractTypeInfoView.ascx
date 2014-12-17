<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContractTypeInfoView.ascx.cs" Inherits="SEP.Performance.Views.ContractType.ContractTypeInfoView" %>
<%@ Register Src="ContractTypeListView.ascx" TagName="ContractTypeListView" TagPrefix="uc1" %>
<%@ Register Src="ContractTypeView.ascx" TagName="ContractTypeView" TagPrefix="uc2" %>

       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
            <ajaxToolKit:ModalPopupExtender id="mpeContractType" runat="server" Drag="true" 
            PopupDragHandleControlID="pnlContractType" BackgroundCssClass="modalBackground" 
            PopupControlID="pnlContractType" TargetControlID="btnHiddenPostButton"></ajaxToolKit:ModalPopupExtender>
            <asp:Button ID="btnHiddenPostButton" runat="Server" Style="display: none" />
            <!--小界面-->
            <div id="divMPE">
   	        <asp:Panel ID="pnlContractType" runat="server" CssClass="modalBox" Style="display: none;" Width="600px">
		        <div style="white-space: nowrap; text-align: center;">
                   <uc2:ContractTypeView ID="ContractTypeView1" runat="server" />
		        </div>
	        </asp:Panel>
	        </div>
	        <!--大界面-->
          <uc1:ContractTypeListView ID="ContractTypeListView1" runat="server" />
    </ContentTemplate>
           <Triggers>
               <asp:PostBackTrigger ControlID="ContractTypeView1" />
               <asp:PostBackTrigger ControlID="ContractTypeListView1" />
           </Triggers>
    </asp:UpdatePanel>
    <br />
