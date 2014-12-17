<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContractWithConditionView.ascx.cs" Inherits="SEP.Performance.Views.Employee.ContractWithConditionView" %>
<%--<%@ Register Src="../Work/ContractView.ascx" TagName="ContractView" TagPrefix="uc3" %>--%>
<%@ Register Src="ApplyAssessConditionView.ascx" TagName="ApplyAssessConditionView"
    TagPrefix="uc2" %>
<%@ Register Src="EmployeeContractView.ascx" TagName="EmployeeContractView" TagPrefix="uc1" %>
<link href="../../CSS/style.css" rel="stylesheet" type="text/css" />

<asp:UpdatePanel ID="UpdatePanelWork" runat="server" UpdateMode="Conditional">
<Triggers>
<asp:AsyncPostBackTrigger ControlID="EmployeeContractView1"/>
</Triggers>
            <ContentTemplate>
                    <ajaxToolKit:ModalPopupExtender id="mpeAssessCondition" runat="server" Drag="true" 
                    PopupDragHandleControlID="pnlContract" BackgroundCssClass="modalBackground" PopupControlID="pnlContract" 
                    TargetControlID="btnHidden"></ajaxToolKit:ModalPopupExtender>
                    
                    <asp:Button ID="btnHidden" runat="Server" Style="display: none" />
                    
                    <asp:HiddenField ID="Operation" runat="server" />
                    <div id="divMPE" runat="server"> 
			        <asp:Panel ID="pnlContract" runat="server" CssClass="modalBox" Style="display: none;" Width="650px">
				        <div style="white-space: nowrap; text-align: center;">
                            <uc2:ApplyAssessConditionView ID="ApplyAssessConditionView1" runat="server" />
				        </div>
			        </asp:Panel></div>
                    <uc1:EmployeeContractView ID="EmployeeContractView1" runat="server" />                  
            </ContentTemplate>
   
</asp:UpdatePanel>
