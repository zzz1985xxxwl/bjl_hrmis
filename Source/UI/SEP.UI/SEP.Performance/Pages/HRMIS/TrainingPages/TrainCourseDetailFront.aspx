﻿<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="TrainCourseDetailFront.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.TrainingPages.TrainCourseDetailFront" %>

<%@ Register Src="../../../Views/HRMIS/Train/CourseView.ascx" TagName="CourseView"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:CourseView ID="CourseView1" runat="server" />
</asp:Content>  
