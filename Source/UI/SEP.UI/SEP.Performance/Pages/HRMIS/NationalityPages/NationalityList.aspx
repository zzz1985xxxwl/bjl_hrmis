<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" 
CodeBehind="NationalityList.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.NationalityPages.NationalityList" %>

<%@ Register Src="../../../Views/HRMIS/Nationalitys/NationalityInfoView.ascx" TagName="NationalityInfoView"
    TagPrefix="uc2" %>

<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
    <uc2:NationalityInfoView id="NationalityInfoView1" runat="server">
    </uc2:NationalityInfoView>
</asp:Content>
