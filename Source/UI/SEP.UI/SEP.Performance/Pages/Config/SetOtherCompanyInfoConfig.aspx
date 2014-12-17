<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetOtherCompanyInfoConfig.aspx.cs" Inherits="SEP.Performance.Pages.Config.SetOtherCompanyInfoConfig" %>

<%@ Register Src="Views/CompanyInfoView.ascx" TagName="CompanyInfoView" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>设置公司信息</title>
    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <asp:Label ID="lbMessage" runat="server" CssClass="leftitbor fontred" style="display:none;"></asp:Label>
    <div>
     <div class="leftitbor2"> CompanyConfig地址</div>
     <div  class="edittable">
        <table style="width: 100%">
            <tr>
                <td style="text-align:left;width:20%;">
                    请选择CompanyConfig地址</td>
                <td style="text-align:left;width:80%;">
                    <input id="fAppAddress" type="file" runat="server" enableviewstate="false" class="fileupload" />
                    <asp:Button ID="btnLoadInfo" runat="server" OnClick="btnLoadInfo_Click"   CssClass="inputbt" Text="加载信息" />
                    &nbsp;
                    <asp:Label ID="lbLoadMessage" CssClass="psword_f" runat="server"></asp:Label></td>
            </tr>
        </table>
        </div>
        <div class="tablebt">
        <asp:Button ID="lbCompanyInfoCopy" runat="server"  CssClass="inputbtcss" OnClick="lbCompanyInfoCopy_Click" Text="加载网站配置信息" /> 
        </div>      
        <uc1:CompanyInfoView ID="CompanyInfoView1" runat="server" />
       <div class="tablebt">
                    <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" CssClass="inputbtcss" Text="上一步" />
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="inputbtcss" Text="下一步，完成" />
                    <asp:Button ID="btnSkip" runat="server" OnClick="btnSkip_Click" CssClass="inputbtcss" Text="跳  过" />
        </div>
    </div>
    </form>
</body>
</html>
