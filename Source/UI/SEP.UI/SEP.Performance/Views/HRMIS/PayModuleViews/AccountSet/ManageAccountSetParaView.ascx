<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageAccountSetParaView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.ManageAccountSetParaView" %>
<%@ Register Src="AccountSetParaView.ascx" TagName="AccountSetParaView" TagPrefix="uc2" %>
<%@ Register Src="AccountSetParaListView.ascx" TagName="AccountSetParaListView" TagPrefix="uc1" %>

<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
<%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>  --%>
   <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
      <ajaxToolKit:ModalPopupExtender id="mpeAccountSetPara" runat="server" Drag="true" 
            PopupDragHandleControlID="pnlAccountSetPara" BackgroundCssClass="modalBackground" 
            PopupControlID="pnlAccountSetPara" TargetControlID="btnHiddenPostButton"></ajaxToolKit:ModalPopupExtender>
            <asp:Button ID="btnHiddenPostButton" runat="Server" Style="display: none" />
           <div id="divMPEAccountSetParaView">
           <asp:Panel ID="pnlAccountSetPara" runat="server" CssClass="modalBox" Style="display: none;" Width="600px">
		        <div style="white-space: nowrap; text-align: center;">
                    <uc2:AccountSetParaView id="AccountSetParaView1" runat="server">
                    </uc2:AccountSetParaView></div>
	        </asp:Panel> 
	        </div>
<uc1:AccountSetParaListView id="AccountSetParaListView1" runat="server">
                    </uc1:AccountSetParaListView>
  </ContentTemplate>
    </asp:UpdatePanel>
