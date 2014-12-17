<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetCompanyInfoConfig.aspx.cs" Inherits="SEP.Performance.Pages.Config.SetCompanyInfoConfig" %>

<%@ Register Src="Views/CompanyInfoView.ascx" TagName="CompanyInfoView" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>设置公司信息</title>
    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
  
        <uc1:CompanyInfoView id="CompanyInfoView1"  runat="server">
        </uc1:CompanyInfoView>
          <div class="tablebt">
                    <asp:Button ID="btnBack" runat="server" Text="上一步" CssClass="inputbtcss" OnClick="btnBack_Click" />
                    <asp:Button ID="btnCreateInitData" runat="server" CssClass="inputbtcss" OnClick="btnCreateInitData_Click" Text="下一步，建立初始信息" />
                    <asp:Button ID="btnAutoRemindConfig" runat="server" CssClass="inputbtcss" OnClick="btnAutoRemindConfig_Click" Text="下一步，自动提醒服务设置" />
                    
          </div>
    </form>
</body>
</html>
