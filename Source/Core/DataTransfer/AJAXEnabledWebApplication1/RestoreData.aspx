<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RestoreData.aspx.cs" Inherits="AJAXEnabledWebApplication1.RestoreData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Label ID="Label1" runat="server" Text="请将主系统的数据文件上传"></asp:Label><br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="上传" />
            <asp:Label ID="lblUploadMessage" runat="server"></asp:Label><br />
            <br />
            <asp:Label ID="lblReadContent" runat="server" Text="读取到的内容为："></asp:Label>
            <br />
            <asp:Label ID="lblRuleName" runat="server" Text="规则名字："></asp:Label>
            <asp:Label ID="lblRuleNameValue" runat="server"></asp:Label>&nbsp;&nbsp;
            <asp:Label ID="lblParameter" runat="server" Text="时间参数："></asp:Label>
            <asp:Label ID="lblParameterValue" runat="server"></asp:Label><br />
            <br />
            <asp:Button ID="btnRestore" runat="server" Text="开始导入" OnClick="btnRestore_Click" />
            <asp:Label ID="lblRestoreMessage" runat="server"></asp:Label><br />
            <asp:Label ID="Label7" runat="server" Text="运行状态："></asp:Label><asp:Label ID="lblRunningStatus" runat="server"></asp:Label><br />
            <asp:Label ID="Label8" runat="server" Text="运行详情："></asp:Label><br />
            <asp:TextBox ID="txtRunningDetails" runat="server" Height="416px" TextMode="MultiLine" Width="1110px"></asp:TextBox>     
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" />
            <asp:PostBackTrigger  ControlID="btnUpload" />
        </Triggers>
    </asp:UpdatePanel>
        <asp:Timer ID="Timer1" runat="server" Interval="3000" OnTick="Timer1_Tick"></asp:Timer>
   </div>
    </form>
</body>
</html>
