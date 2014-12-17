<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="FBQuesTypeInfo.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.TrainingPages.FBQuesTypeInfo" %>

<%@ Register Src="../../../Views/HRMIS/FBQuesType/FBQuesTypeInfoView.ascx" TagName="FBQuesTypeInfoView"
    TagPrefix="uc1" %>

    <asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
           <uc1:FBQuesTypeInfoView id="FBQuesTypeInfoView1" runat="server">
        </uc1:FBQuesTypeInfoView>
</asp:Content>  
