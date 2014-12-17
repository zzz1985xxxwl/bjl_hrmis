<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetWebConfig.aspx.cs" Inherits="SEP.Performance.Pages.Config.SetWebConfig" %>

<%@ Register Src="Views/AttendanceSettingView.ascx" TagName="AttendanceSettingView"
    TagPrefix="uc7" %>

<%@ Register Src="Views/ContactSettingView.ascx" TagName="ContactSettingView" TagPrefix="uc8" %>

<%@ Register Src="Views/OtherWebConfig.ascx" TagName="OtherWebConfig" TagPrefix="uc6" %>

<%@ Register Src="Views/SMSSettingView.ascx" TagName="SMSSettingView" TagPrefix="uc5" %>

<%@ Register Src="Views/ConnectStringView.ascx" TagName="ConnectStringView" TagPrefix="uc4" %>

<%@ Register Src="Views/MailSettingView.ascx" TagName="MailSettingView" TagPrefix="uc3" %>

<%@ Register Src="Views/SubSystemSetView.ascx" TagName="SubSystemSetView" TagPrefix="uc2" %>

<%@ Register Src="Views/ClassFactoryView.ascx" TagName="ClassFactoryView" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>设置webconfig</title>
    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lbMessage" runat="server" CssClass="leftitbor fontred" style="display:none;"></asp:Label>
        <uc2:SubSystemSetView id="SubSystemSetView1" runat="server">
                    </uc2:SubSystemSetView>
        <uc4:ConnectStringView id="ConnectStringView1" runat="server">
        </uc4:ConnectStringView>
        <uc1:ClassFactoryView id="ClassFactoryView1" runat="server">
                    </uc1:ClassFactoryView>
        <uc3:MailSettingView id="MailSettingView1" runat="server">
        </uc3:MailSettingView>
        <uc5:SMSSettingView id="SMSSettingView1" runat="server">
        </uc5:SMSSettingView>
        <uc8:ContactSettingView id="ContactSettingView1" runat="server">
        </uc8:ContactSettingView>
        <uc7:attendancesettingview id="AttendanceSettingView1" runat="server">
        </uc7:attendancesettingview>
        <uc6:OtherWebConfig id="OtherWebConfig1" runat="server">
        </uc6:OtherWebConfig>
        <div class="tablebt">
                    <asp:Button ID="btnCompanyInfoConfig" runat="server" OnClick="btnCompanyInfoConfig_Click"  CssClass="inputbtcss" Text="下一步，公司信息设置" />
                   
      </div >
    </form>
</body>
</html>
