<%@ Page Language="C#"  MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="DutyClassList.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AttendancePages.DutyClassList" %>

<%@ Register Src="../../../Views/HRMIS/AttendanceStatistics/PlanDutyViews/DutyClassInfoView.ascx"
    TagName="DutyClassInfoView" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
                <uc1:DutyClassInfoView id="DutyClassInfoView1" runat="server">
        </uc1:DutyClassInfoView>
</asp:Content>    

