<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" 
AutoEventWireup="true" CodeBehind="DetailPlanDuty.aspx.cs" 
Inherits="SEP.Performance.Pages.HRMIS.AttendancePages.DetailPlanDuty" %>

<%@ Register Src="../../../Views/HRMIS/AttendanceStatistics/PlanDutyViews/SetPlanDutyInfoView.ascx"
    TagName="SetPlanDutyInfoView" TagPrefix="uc2" %>

<%@ Register Src="../../../Views/HRMIS/AttendanceStatistics/PlanDutyViews/SetPlanDutyView.ascx"
    TagName="SetPlanDutyView" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <uc2:SetPlanDutyInfoView id="SetPlanDutyInfoView1" runat="server">
        </uc2:SetPlanDutyInfoView>
        </asp:Content>  