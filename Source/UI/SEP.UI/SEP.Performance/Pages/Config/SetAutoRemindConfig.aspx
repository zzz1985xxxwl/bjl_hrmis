<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetAutoRemindConfig.aspx.cs" Inherits="SEP.Performance.Pages.Config.SetAutoRemindConfig" %>

<%@ Register Src="Views/AttendanceSettingView.ascx" TagName="AttendanceSettingView"
    TagPrefix="uc6" %>

<%@ Register Src="Views/AutoRemindFunctionSetView.ascx" TagName="AutoRemindFunctionSetView"
    TagPrefix="uc5" %>

<%@ Register Src="Views/MailSettingView.ascx" TagName="MailSettingView" TagPrefix="uc4" %>

<%@ Register Src="Views/ClassFactoryView.ascx" TagName="ClassFactoryView" TagPrefix="uc3" %>

<%@ Register Src="Views/ConnectStringView.ascx" TagName="ConnectStringView" TagPrefix="uc2" %>

<%@ Register Src="Views/SubSystemSetView.ascx" TagName="SubSystemSetView" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Label ID="lbMessage" CssClass="leftitbor fontred" style="display:none;" runat="server"></asp:Label>
        <uc1:SubSystemSetView id="SubSystemSetView1" runat="server">
        </uc1:SubSystemSetView>
         <div class="leftitbor2"> AppConfig地址</div>
         <div class="edittable">
        <table style="width: 100%">
            <tr>
                <td style="width: 11%;text-align:right">
                    请选择AppConfig地址</td>
                <td style="width: 89%">
                    <input id="fAppAddress" type="file" runat="server" enableviewstate="false" class="fileupload" />
                    <asp:Button ID="btnLoadInfo" runat="server" CssClass="inputbt" OnClick="btnLoadInfo_Click" Text="加载信息" />
                    &nbsp;
                    <asp:Label ID="lbLoadMessage" CssClass="psword_f" runat="server"></asp:Label></td>
            </tr>
        </table>
        </div>
        <div class="tablebt"> <asp:Button ID="lbDBConnectionCopy" runat="server"  CssClass="inputbtcss" OnClick="lbDBConnectionCopy_Click" Text="加载网站配置信息"></asp:Button></div>
               
        <uc2:ConnectStringView id="ConnectStringView1" runat="server">
        </uc2:ConnectStringView>
           <div class="tablebt"><asp:Button ID="lbClassFactoryCopy" runat="server"  CssClass="inputbtcss" OnClick="lbClassFactoryCopy_Click" Text="加载网站配置信息"></asp:Button></div>
        
        <uc3:ClassFactoryView ID="ClassFactoryView1" runat="server" />
        <uc5:AutoRemindFunctionSetView id="AutoRemindFunctionSetView1" runat="server">
        </uc5:AutoRemindFunctionSetView>
         <div class="tablebt"> <asp:Button ID="lbMSMQMailCopy" runat="server"  CssClass="inputbtcss" OnClick="lbMSMQMailCopy_Click" Text="加载网站配置信息"></asp:Button></div>
        <uc4:MailSettingView id="MailSettingView1" runat="server">
        </uc4:MailSettingView>
        <uc6:attendancesettingview id="AttendanceSettingView1" runat="server">
        </uc6:attendancesettingview>
        <div  class="tablebt">
                    <asp:Button ID="btnBack" runat="server" CssClass="inputbtcss" OnClick="btnBack_Click" Text="上一步" />
                    <asp:Button ID="btnSave" runat="server" CssClass="inputbtcss" OnClick="btnSave_Click" Text="下一步，设置其余公司信息文件" />  
                    <asp:Button ID="btnSkip" runat="server" CssClass="inputbtcss" OnClick="btnSkip_Click" Text="跳过" />
        </div>
       
    </div>
    </form>
</body>
</html>
