<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BackUpData.aspx.cs" Inherits="AJAXEnabledWebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="Label1" runat="server" Text="所有规则"></asp:Label>
                &nbsp;&nbsp;
                <asp:Button ID="btnReset" runat="server" Text="重新读取" OnClick="btnReset_Click" /><br />
                <asp:DropDownList ID="ddlAllRules" runat="server" Width="204px" OnSelectedIndexChanged="ddlAllRules_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>&nbsp;
                <asp:Label ID="lblStartTime" runat="server" Text="开始时间"></asp:Label>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtStartTime" Format="yyyy-MM-dd"></ajaxToolKit:CalendarExtender>
                <asp:TextBox ID="txtStartTime" runat="server" Width="101px"></asp:TextBox>
                <asp:Label ID="lblEndTime" runat="server" Text="结束时间"></asp:Label>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEndTime" Format="yyyy-MM-dd"></ajaxToolKit:CalendarExtender>
                <asp:TextBox ID="txtEndTime" runat="server" Width="100px"></asp:TextBox><br />
                <asp:Button ID="btnBackUp" runat="server" Text="开始备份数据" OnClick="btnBackUp_Click" />
                <asp:Label ID="lblMessage" runat="server"></asp:Label><br />
                <br />
                <asp:Label ID="Label5" runat="server" Text="运行状态："></asp:Label><asp:Label ID="lblRunningStatus" runat="server"></asp:Label>&nbsp;&nbsp;
                <asp:Label ID="lblDownloadFile" runat="server" Text="下载地址："></asp:Label>
                <asp:HyperLink ID="hlDownloadFile" runat="server" EnableTheming="True">数据文件</asp:HyperLink><br /><br />
                <asp:Label ID="Label4" runat="server" Text="运行详情："></asp:Label><br />
                <asp:TextBox ID="txtRunningDetails" runat="server" Height="416px" TextMode="MultiLine" Width="1110px"></asp:TextBox>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:Timer ID="Timer1" runat="server" Interval="3000" OnTick="Timer1_Tick"></asp:Timer>
    </div>
    </form>
</body>
</html>
