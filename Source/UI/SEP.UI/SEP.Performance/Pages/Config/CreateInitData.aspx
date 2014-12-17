<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateInitData.aspx.cs" Inherits="SEP.Performance.Pages.Config.CreateInitData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>初始化数据</title>
    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div class="leftitbor2"> 初始数据</div>
     <div class="edittable">
        <table style="width: 100%;">
            <tr>
                <td style="width: 20%; text-align:left">
                    集团名称
                </td>
                <td style="width: 80%">
                    <asp:TextBox ID="txtDepName" CssClass="input" runat="server" Width="400px"></asp:TextBox>
                    <asp:Label ID="lblDepNameMsg" CssClass="psword_f" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align:left">
                    集团负责人姓名</td>
                <td>
                    <asp:TextBox ID="txtLeaderName" CssClass="input" runat="server" Width="400px"></asp:TextBox>
                    <asp:Label ID="lblLeaderNameMsg"  CssClass="psword_f" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align:left; height: 26px;">
                    集团负责人登录名</td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtLeaderLoginName" CssClass="input" runat="server" Width="400px"></asp:TextBox>
                    <asp:Label ID="lblLeaderLoginNameMsg"  CssClass="psword_f" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align:left; height: 26px;">
                    集团负责人职位等级</td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtPosition" runat="server"  CssClass="input" Width="400px"></asp:TextBox>
                    <asp:Label ID="lblPositionMsg" CssClass="psword_f" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align:left; height: 26px;">
                    集团负责人职位名称</td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtPositionGrade" runat="server" CssClass="input" Width="400px"></asp:TextBox>
                    <asp:Label ID="lblPositionGradeMsg" CssClass="psword_f"  runat="server"></asp:Label></td>
            </tr>
        </table>
        </div>
     <div class="tablebt">
                    <asp:Button ID="btnAutoRemindConfig" runat="server" OnClick="btnAutoRemindConfig_Click" CssClass="inputbtcss" Text="下一步，自动提醒服务设置" />
         
    </div>
    </div>
    </form>
</body>
</html>
