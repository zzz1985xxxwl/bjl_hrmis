<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master"  CodeBehind="CompanyTeleBook.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.CompanyTeleBooksPages.CompanyTeleBook" %>

<%@ Register Src="../../../Views/HRMIS/CompanyTeleBooks/CompanyLinkManInfo.ascx"
    TagName="CompanyLinkManInfo" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:CompanyLinkManInfo id="CompanyLinkManInfo1" runat="server">
    </uc1:CompanyLinkManInfo>

        </asp:Content>  
