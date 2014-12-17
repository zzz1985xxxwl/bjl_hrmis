<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" 
AutoEventWireup="true" CodeBehind="AddPlanDuty.aspx.cs" 
Inherits="SEP.Performance.Pages.HRMIS.AttendancePages.AddPlanDuty" %>

<%@ Register Src="../../../Views/HRMIS/AttendanceStatistics/PlanDutyViews/SetPlanDutyInfoView.ascx"
    TagName="SetPlanDutyInfoView" TagPrefix="uc2" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <uc2:SetPlanDutyInfoView id="SetPlanDutyInfoView1" runat="server">
        </uc2:SetPlanDutyInfoView>
        </asp:Content>  