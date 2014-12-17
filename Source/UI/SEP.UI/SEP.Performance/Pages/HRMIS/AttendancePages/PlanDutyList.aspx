<%@ Page Language="C#"  MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="PlanDutyList.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AttendancePages.PlanDutyList" %>

<%@ Register Src="../../../Views/HRMIS/AttendanceStatistics/PlanDutyViews/PlanDutyListView.ascx"
    TagName="PlanDutyListView" TagPrefix="uc1" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
        <uc1:PlanDutyListView id="PlanDutyListView1" runat="server">
        </uc1:PlanDutyListView>
</asp:Content>


