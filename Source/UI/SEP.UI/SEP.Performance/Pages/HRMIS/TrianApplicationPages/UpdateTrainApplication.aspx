﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="UpdateTrainApplication.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.TrianApplicationPages.UpdateTrainApplication" %>

<%@ Register Src="../../../Views/HRMIS/TrainApplication/TrainApplicationView.ascx"
    TagName="TrainApplicationView" TagPrefix="uc1" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
        <uc1:TrainApplicationView ID="TrainApplicationView1" runat="server" />
    
   </asp:Content>