<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="DetailTrainApplication.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.TrianApplicationPages.DetailTrainApplication" %>

<%@ Register Src="../../../Views/HRMIS/TrainApplication/TrainApplicationFlowListView.ascx"
    TagName="TrainApplicationFlowListView" TagPrefix="uc2" %>

<%@ Register Src="../../../Views/HRMIS/TrainApplication/TrainApplicationView.ascx"
    TagName="TrainApplicationView" TagPrefix="uc1" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
        <uc1:TrainApplicationView ID="TrainApplicationView1" runat="server" />
    <uc2:TrainApplicationFlowListView id="TrainApplicationFlowListView1" runat="server">
    </uc2:TrainApplicationFlowListView>
    
   </asp:Content>
