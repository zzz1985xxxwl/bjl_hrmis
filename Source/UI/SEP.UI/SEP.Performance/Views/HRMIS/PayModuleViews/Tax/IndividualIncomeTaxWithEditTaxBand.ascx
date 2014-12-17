<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndividualIncomeTaxWithEditTaxBand.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.Tax.IndividualIncomeTaxWithEditTaxBand" %>
<%@ Register Src="EditTaxBand.ascx" TagName="EditTaxBand" TagPrefix="uc2" %>
<%@ Register Src="IndividualIncomeTaxView.ascx" TagName="IndividualIncomeTaxView"
    TagPrefix="uc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"> 
<ContentTemplate>
<uc1:IndividualIncomeTaxView id="IndividualIncomeTaxView1" runat="server"></uc1:IndividualIncomeTaxView>

 <ajaxToolKit:ModalPopupExtender id="mpeOperation" runat="server" 
        PopupDragHandleControlID="pnlEditTaxBand" BackgroundCssClass="modalBackground" PopupControlID="pnlEditTaxBand" 
          TargetControlID="btnHidden"></ajaxToolKit:ModalPopupExtender>
            
<asp:Button ID="btnHidden" runat="Server" Style="display: none" />
<div id="divMPE" runat="server">          
<asp:Panel ID="pnlEditTaxBand" runat="server" CssClass="modalBox" Style="display: none;" Width="500px">
    <div style="white-space: nowrap; text-align: center;">
       <uc2:EditTaxBand id="EditTaxBand1" runat="server"></uc2:EditTaxBand>  
    </div>
</asp:Panel>
</div>
</ContentTemplate>  
</asp:UpdatePanel>