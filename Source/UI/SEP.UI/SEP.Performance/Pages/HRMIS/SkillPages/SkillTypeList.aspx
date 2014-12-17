<%@ Page Language="C#" MasterPageFile="~/Pages/HRMIS/MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="SkillTypeList.aspx.cs" Inherits="SEP.Performance.Pages.SkillTypeList"  %>

<%@ Register Src="../../../Views/HRMIS/SkillType/SkillTypeInfoView.ascx" TagName="SkillTypeInfoView"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
       <uc1:SkillTypeInfoView ID="SkillTypeInfoView1" runat="server" />
</asp:Content>               