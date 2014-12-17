<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="MyTrainApplication.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.TrianApplicationPages.MyTrainApplication" %>

<%@ Register Src="../../../Views/HRMIS/TrainApplication/MyTrainApplicationInfoView.ascx"
    TagName="MyTrainApplicationInfoView" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:MyTrainApplicationInfoView ID="MyTrainApplicationInfoView1" runat="server" />

</asp:Content>  
