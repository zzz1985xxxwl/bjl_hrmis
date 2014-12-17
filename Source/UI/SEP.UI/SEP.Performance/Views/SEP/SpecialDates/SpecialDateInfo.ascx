<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SpecialDateInfo.ascx.cs"
            Inherits="SEP.Performance.Views.SEP.SpecialDates.SpecialDateInfo" %>
<%@ Register Src="SpecialDateEditView.ascx" TagName="SpecialDateEditView" TagPrefix="uc2" %>
<%@ Register Src="SetSpecialDateView.ascx" TagName="SetSpecialDateView" TagPrefix="uc1" %>
<%--
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <triggers>
        <asp:AsyncPostBackTrigger ControlID="SetSpecialDateView1"/>
    </triggers>
    <contenttemplate>
        <div>
            <uc1:SetSpecialDateView ID="SetSpecialDateView1" runat="server" />
        </div> 
        <ajaxToolKit:ModalPopupExtender id="mpespecialDateEdit" runat="server" Drag="true" 
                                        PopupDragHandleControlID="pnlspecialDateEdit"
                                        BackgroundCssClass="modalBackground"
                                        PopupControlID="pnlspecialDateEdit" 
                                        TargetControlID="btnHidden"></ajaxToolKit:ModalPopupExtender>
                    
        <asp:Button ID="btnHidden" runat="Server" Style="display: none" />      
        <div id="divMPESpecialDateEditView">                 
            <asp:Panel ID="pnlspecialDateEdit" runat="server" CssClass="modalBox" Style="display: none;" Width="500px">
                <div style="white-space: nowrap; text-align: center;">
                    <uc2:SpecialDateEditView id="SpecialDateEditView1" runat="server" />
                </div>
            </asp:Panel>
        </div>

                   
    </contenttemplate>
</asp:UpdatePanel>