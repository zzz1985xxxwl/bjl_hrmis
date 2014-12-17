<%@ Page Language="C#"  MasterPageFile="../MainPages/HRMISMaster.Master"  AutoEventWireup="true" CodeBehind="EmployeeMyDetail.aspx.cs" Inherits="SEP.Performance.Pages.EmployeeMyDetail" %>
<%@ Register Src="../../../Views/HRMIS/EmployeeInformation/EmployeeView.ascx" TagName="EmployeeView"
    TagPrefix="uc4" %>
    
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
 
        <uc4:EmployeeView id="EmployeeView1" runat="server"></uc4:EmployeeView>
       
</asp:Content>

