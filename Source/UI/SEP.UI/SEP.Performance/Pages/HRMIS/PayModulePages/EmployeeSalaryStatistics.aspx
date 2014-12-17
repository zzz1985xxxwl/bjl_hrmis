<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeSalaryStatistics.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.PayModulePages.EmployeeSalaryStatistics" %>

<%@ Register Src="../../../Views/HRMIS/PayModuleViews/EmployeeSalaryStatistics/CommonEmployeeSalaryStatisticsView.ascx"
    TagName="CommonEmployeeSalaryStatisticsView" TagPrefix="uc1" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <script language= "javascript " type="text/javascript" src="../Inc/BaseScript.js"></script>
    <uc1:CommonEmployeeSalaryStatisticsView id="CommonEmployeeSalaryStatisticsView1"
        runat="server">
    </uc1:CommonEmployeeSalaryStatisticsView>
</asp:Content>

