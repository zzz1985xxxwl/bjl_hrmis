<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="ContractAdvanceSearch.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AdvanceSearchPages.ContractAdvanceSearch" %>

<%@ Register Src="../../../Views/HRMIS/AdvanceSearch/ContractAdvanceSearchList.ascx"
    TagName="ContractAdvanceSearchList" TagPrefix="uc2" %>
<%@ Register Src="../../../Views/Progressing.ascx" TagName="Progressing" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCenter" Runat="Server">
    <uc2:ContractAdvanceSearchList id="ContractAdvanceSearchList1" runat="server">
    </uc2:ContractAdvanceSearchList>

</asp:Content>