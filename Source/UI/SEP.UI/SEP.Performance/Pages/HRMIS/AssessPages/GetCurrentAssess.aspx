<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="GetCurrentAssess.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AssessPages.GetCurrentAssess" %>

<%@ Register Src="../../../Views/HRMIS/AssessActivity/GetCurrentAssess.ascx" TagName="GetCurrentAssess"
    TagPrefix="uc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="cphCenter" Runat="Server">
    <uc1:GetCurrentAssess id="GetCurrentAssess1" runat="server">
    </uc1:GetCurrentAssess>
</asp:Content>

