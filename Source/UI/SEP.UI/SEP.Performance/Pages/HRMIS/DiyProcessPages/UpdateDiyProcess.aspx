﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateDiyProcess.aspx.cs" MasterPageFile="../MainPages/HRMISMaster.Master"
Inherits="SEP.Performance.Pages.HRMIS.DiyProcessPages.UpdateDiyProcess" %>

<%@ Register Src="../../../Views/HRMIS/DiyProcesses/DiyProcessView.ascx" TagName="DiyProcessView"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <uc1:DiyProcessView id="DiyProcessView1" runat="server">
        </uc1:DiyProcessView>
</asp:Content>
