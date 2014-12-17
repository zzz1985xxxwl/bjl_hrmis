<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MasterPage.Master" CodeBehind="PositionGradeManage.aspx.cs" Inherits="SEP.Performance.Pages.SEP.PositionPages.PositionGradeManage" %>

<%@ Register Src="../../../Views/SEP/Positions/PositionGradeView.ascx" TagName="PositionGradeView"
    TagPrefix="uc1" %>

<asp:Content ID="PositionManageContent" ContentPlaceHolderID="cphCenter" Runat="Server">
    <uc1:PositionGradeView id="PositionGradeView1" runat="server">
    </uc1:PositionGradeView>
</asp:Content>
