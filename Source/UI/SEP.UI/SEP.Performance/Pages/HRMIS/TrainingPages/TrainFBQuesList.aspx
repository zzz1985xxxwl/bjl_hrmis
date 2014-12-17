<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="TrainFBQuesList.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.TrainingPages.TrainFBQuesList" %>

<%@ Register Src="../../../Views/HRMIS/TrainFBQuesAndItem/TrainFBQuestionList.ascx"
    TagName="TrainFBQuestionList" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <uc1:TrainFBQuestionList id="TrainFBQuestionList1" runat="server">
        </uc1:TrainFBQuestionList>
</asp:Content> 

