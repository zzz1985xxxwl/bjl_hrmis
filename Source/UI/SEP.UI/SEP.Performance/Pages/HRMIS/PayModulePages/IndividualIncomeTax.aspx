<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndividualIncomeTax.aspx.cs" MasterPageFile="../MainPages/HRMISMaster.Master" Inherits="SEP.Performance.Pages.HRMIS.PayModulePages.IndividualIncomeTax" %>

<%@ Register Src="../../../Views/HRMIS/PayModuleViews/Tax/IndividualIncomeTaxWithEditTaxBand.ascx"
    TagName="IndividualIncomeTaxWithEditTaxBand" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
 <script language= "javascript " type="text/javascript" src="../Inc/BaseScript.js"> 
</script> 
<%--     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
 
<uc1:IndividualIncomeTaxWithEditTaxBand ID="IndividualIncomeTaxWithEditTaxBand1" runat="server" />

</asp:Content>


