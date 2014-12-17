<%@ Page Language="C#" MasterPageFile="~/Pages/HRMIS/MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="BackUpData.aspx.cs" Inherits="AJAXEnabledWebApplication1._Default" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
--%>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <div class="leftitbor" ID="Message" runat="server"><asp:Label ID="lblMessage" runat="server"></asp:Label></div>
            <div class="leftitbor2">数据导出</div>
            <div class="edittable">
                <table width="100%" >
                <tr align="left" ><td>                
                请选择规则</td>
                <td  width="20%" >
                <asp:DropDownList ID="ddlAllRules" runat="server" Width="204px" OnSelectedIndexChanged="ddlAllRules_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
                </td>
                <td> 
                <asp:Label ID="lblStartTime" runat="server" Text="开始时间"></asp:Label>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtStartTime" Format="yyyy-MM-dd"></ajaxToolKit:CalendarExtender>
                <asp:TextBox ID="txtStartTime"  CssClass="input1" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td><asp:Label ID="lblEndTime" runat="server" Text="结束时间"></asp:Label>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEndTime" Format="yyyy-MM-dd"></ajaxToolKit:CalendarExtender>
                <asp:TextBox ID="txtEndTime"  CssClass="input1" runat="server" Width="100px"></asp:TextBox><br />
                 </td>
                </tr>
                <tr align="left">
                <td>
                <asp:Button ID="btnReset" runat="server"  CssClass="inputbt" OnClick="btnReset_Click" Text="重新读取" /></td>
                <td><asp:Button ID="btnRuleToString" runat="server"  CssClass="inputbt" OnClick="btnRuleToString_Click" Text="规则详情" /></td>
                </tr>
                <tr align="left"><td> 
                <asp:Button ID="btnBackUp" runat="server"  CssClass="inputbtlong" Text="开始备份数据" OnClick="btnBackUp_Click" />
                </td>
                <td>
                </td>
                <td><asp:Label ID="lblRunningStatus" runat="server"></asp:Label>
                </td>
                <td><asp:Label ID="lblDownloadFile" runat="server" Text="下载地址："></asp:Label>
                <asp:HyperLink ID="hlDownloadFile" runat="server" EnableTheming="True" ForeColor="#00C000">数据文件</asp:HyperLink>
                </td></tr>
                <tr align="left" width="20%"><td>运行详情
                 </td>
                 <td colspan="3" width="80%">
                <asp:TextBox ID="txtRunningDetails" runat="server"  CssClass="grayborder" Height="200px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                </td></tr>
                </table></div>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:Timer ID="Timer1" runat="server" Interval="3000" OnTick="Timer1_Tick"></asp:Timer>
    </div>
</asp:Content>
