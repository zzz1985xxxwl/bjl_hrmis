<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="AddTrainFBQuesAndItem.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.TrainingPages.AddTrainFBQuesAndItem" Title="无标题页" %>

<%@ Register Src="../../../Views/HRMIS/TrainFBQuesAndItem/TrainFBQuesAndItemView.ascx"
    TagName="TrainFBQuesAndItemView" TagPrefix="uc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="cphCenter" runat="server">
    <uc1:TrainFBQuesAndItemView id="TrainFBQuesAndItemView1" runat="server">
    </uc1:TrainFBQuesAndItemView>
</asp:Content>
