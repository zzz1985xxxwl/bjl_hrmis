<%@ Page Language="C#" AutoEventWireup="true"  
MasterPageFile="../MainPages/HRMISMaster.Master" 
CodeBehind="AddTrainApplication.aspx.cs" 
Inherits="SEP.Performance.Pages.HRMIS.TrianApplicationPages.AddTrainApplication" %>

<%@ Register Src="../../../Views/HRMIS/TrainApplication/TrainApplicationView.ascx"
    TagName="TrainApplicationView" TagPrefix="uc1" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
        <uc1:TrainApplicationView ID="TrainApplicationView1" runat="server" />
    
   </asp:Content>