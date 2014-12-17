<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master"  CodeBehind="AddTrainCourse.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.TrainingPages.AddTrainCourse" %>

<%@ Register Src="../../../Views/HRMIS/Train/CourseView.ascx" TagName="CourseView"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
                 <uc1:CourseView id="CourseView1" runat="server">
                </uc1:CourseView>  
</asp:Content>  

