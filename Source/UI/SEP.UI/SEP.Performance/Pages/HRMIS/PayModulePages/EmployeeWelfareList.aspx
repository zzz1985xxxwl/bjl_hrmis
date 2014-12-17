<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeWelfareList.aspx.cs" MasterPageFile="../MainPages/HRMISMaster.Master" Inherits="SEP.Performance.Pages.HRMIS.PayModulePages.EmployeeWelfareList" %>

<%@ Register Src="../../../Views/HRMIS/PayModuleViews/EmployeeWelfares/EmployeeWelfareSearchList.ascx"
    TagName="EmployeeWelfareSearchList" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:EmployeeWelfareSearchList id="EmployeeWelfareSearchList1" runat="server">
        </uc1:EmployeeWelfareSearchList>
</asp:Content>