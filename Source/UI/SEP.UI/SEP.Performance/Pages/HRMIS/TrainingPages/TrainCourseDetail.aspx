<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="TrainCourseDetail.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.TrainingPages.TrainCourseDetail" %>

<%@ Register Src="../../../Views/HRMIS/Train/CourseView.ascx" TagName="CourseView"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:CourseView ID="CourseView1" runat="server" />
</asp:Content>  

