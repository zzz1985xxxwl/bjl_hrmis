<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InAndOutStatisticsRecord.aspx.cs" MasterPageFile="../MainPages/HRMISMaster.Master" Inherits="SEP.Performance.Pages.HRMIS.AttendancePages.InAndOutStatisticsRecord" %>

<%@ Register Src="../../../Views/HRMIS/AttendanceStatistics/AttendanceInAndOutStatistics/InAndOutStatisticsBuildView.ascx"
    TagName="InAndOutStatisticsBuildView" TagPrefix="uc1" %>

 <asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
        <uc1:InAndOutStatisticsBuildView id="InAndOutStatisticsBuildView1" runat="server">
        </uc1:InAndOutStatisticsBuildView>
</asp:Content>
      
