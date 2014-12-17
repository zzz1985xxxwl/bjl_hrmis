<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeAdvanceSearch.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AdvanceSearchPages.EmployeeAdvanceSearch" %>

<%@ Register Src="../../../Views/HRMIS/AdvanceSearch/EmployeeAdvanceSearchList.ascx"
    TagName="EmployeeAdvanceSearchList" TagPrefix="uc2" %>
<%@ Register Src="../../../Views/Progressing.ascx" TagName="Progressing" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCenter" Runat="Server">
    <uc2:EmployeeAdvanceSearchList id="EmployeeAdvanceSearchList1" runat="server">
    </uc2:EmployeeAdvanceSearchList>

</asp:Content>