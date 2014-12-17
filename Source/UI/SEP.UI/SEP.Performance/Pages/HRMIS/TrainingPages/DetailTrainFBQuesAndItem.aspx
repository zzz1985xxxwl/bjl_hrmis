<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="DetailTrainFBQuesAndItem.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.TrainingPages.DetailTrainFBQuesAndItem" Title="无标题页" %>

<%@ Register Src="../../../Views/HRMIS/TrainFBQuesAndItem/TrainFBQuesAndItemView.ascx"
    TagName="TrainFBQuesAndItemView" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphCenter" runat="server">
    <uc1:TrainFBQuesAndItemView ID="TrainFBQuesAndItemView1" runat="server" />
</asp:Content>
