<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReimburseStatistics.aspx.cs" 
MasterPageFile="../MainPages/HRMISMaster.Master" Inherits="SEP.Performance.Pages.HRMIS.ReimbursePages.ReimburseStatistics" %>

<%@ Register Src="../../../Views/HRMIS/Reimburse/ReimburseStatistics/CommonReimburseStatisticsView.ascx"
    TagName="CommonReimburseStatisticsView" TagPrefix="uc1" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:CommonReimburseStatisticsView id="CommonReimburseStatisticsView1" runat="server">
    </uc1:CommonReimburseStatisticsView>
    <script language= "javascript " type="text/javascript" src="../Inc/BaseScript.js"></script>
    
    </asp:Content>
