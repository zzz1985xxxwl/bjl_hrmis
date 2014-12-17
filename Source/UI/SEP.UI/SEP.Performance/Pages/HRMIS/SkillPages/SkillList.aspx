<%@ Page Language="C#" MasterPageFile="~/Pages/HRMIS/MainPages/HRMISMaster.Master"  AutoEventWireup="true" CodeBehind="SkillList.aspx.cs" Inherits="SEP.Performance.Pages.SkillList"  %>
<%@ Register Src="../../../Views/HRMIS/Skill/SkillInfoView.ascx" TagName="SkillInfoView" TagPrefix="uc2" %>
    
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <uc2:SkillInfoView id="SkillInfoView1" runat="server">
        </uc2:SkillInfoView>
</asp:Content>        