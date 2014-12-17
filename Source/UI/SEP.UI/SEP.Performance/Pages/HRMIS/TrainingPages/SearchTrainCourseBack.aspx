<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="SearchTrainCourseBack.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.TrainingPages.SearchTrainCourseBack" %>

<%@ Register Src="../../../Views/HRMIS/Train/TrainCourseBackSearch.ascx" TagName="TrainCourseBackSearch"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>  
        <uc1:TrainCourseBackSearch ID="TrainCourseBackSearch1" runat="server" /> 
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
