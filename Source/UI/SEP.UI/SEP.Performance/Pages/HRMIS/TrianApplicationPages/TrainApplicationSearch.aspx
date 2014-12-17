<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="TrainApplicationSearch.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.TrianApplicationPages.TrainApplicationSearch" %>

<%@ Register Src="../../../Views/HRMIS/TrainApplication/SearchTrainApplicationView.ascx"
    TagName="SearchTrainApplicationView" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:SearchTrainApplicationView id="SearchTrainApplicationView1" runat="server">
    </uc1:SearchTrainApplicationView>

</asp:Content>  
