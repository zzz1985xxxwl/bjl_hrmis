<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SetPlanDutyInfoView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.AttendanceStatistics.PlanDutyViews.SetPlanDutyInfoView" %>
<%@ Register Src="ReplaceDutyClassView.ascx" TagName="ReplaceDutyClassView" TagPrefix="uc3" %>
<%@ Register Src="SetPlanDutyView.ascx" TagName="SetPlanDutyView" TagPrefix="uc1" %>
<%@ Register Src="../../ChoseEmployee/ChoseEmployeeView.ascx" TagName="ChoseEmployeeView"
    TagPrefix="uc2" %>
    
    
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<Triggers>
<asp:AsyncPostBackTrigger ControlID="SetPlanDutyView1"/>
</Triggers>
<ContentTemplate>
<div>    
<uc1:SetPlanDutyView id="SetPlanDutyView1" runat="server">
</uc1:SetPlanDutyView>
</div> 
 <ajaxToolKit:ModalPopupExtender id="mpeChoseEmployeeView" runat="server"¡¡Drag="true" 
  PopupDragHandleControlID="pnlChoseEmployeeView"
  BackgroundCssClass="modalBackground"
  PopupControlID="pnlChoseEmployeeView" 
  TargetControlID="btnChooseEmployeeHidden"></ajaxToolKit:ModalPopupExtender>
                    
<asp:Button ID="btnChooseEmployeeHidden" runat="Server" Style="display: none" />      
            <div id="divMPEChoseEmployeeView">                 
<asp:Panel ID="pnlChoseEmployeeView" runat="server" CssClass="modalBox" Style="display: none;" Width="700px">
	<div style="white-space: nowrap; text-align: center;">
<uc2:ChoseEmployeeView id="ChoseEmployeeView1" runat="server">
</uc2:ChoseEmployeeView>
</div>
</asp:Panel>
</div>  

<ajaxToolKit:ModalPopupExtender id="mpeReplaceDutyClassView" runat="server" Drag="true" 
            PopupDragHandleControlID="pnlReplaceDutyClassView" BackgroundCssClass="modalBackground" 
            PopupControlID="pnlReplaceDutyClassView" TargetControlID="btnHiddenPostButton1"></ajaxToolKit:ModalPopupExtender>
            <asp:Button ID="btnHiddenPostButton1" runat="Server" Style="display: none" />
            <!--Ð¡½çÃæ-->
            <div id="divMPEReplaceDutyClassView">
	        <asp:Panel ID="pnlReplaceDutyClassView" runat="server" CssClass="modalBox" Style="display: none;" Width="600px">
		        <div style="white-space: nowrap; text-align: center;">
<uc3:ReplaceDutyClassView id="ReplaceDutyClassView1" runat="server">
</uc3:ReplaceDutyClassView>
		        </div>
	        </asp:Panel>
	        </div>
	                         
</ContentTemplate>   
</asp:UpdatePanel>
<script type="text/javascript">
function btnChooseMailCCClick()
{
$("#cphCenter_SetPlanDutyInfoView1_btnChooseEmployeeHidden").trigger("click");
}
 </script>

