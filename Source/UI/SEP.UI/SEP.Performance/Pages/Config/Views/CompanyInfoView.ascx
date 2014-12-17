<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CompanyInfoView.ascx.cs" Inherits="SEP.Performance.Pages.Config.Views.CompanyInfoView" %>
        <div class="leftitbor2">设置公司信息</div>
        <div class="edittable">
        <table width="100%">
            <tr style="display:none;">
                <td style="width:10%;">	默认的系统发信源Mail地址
                </td>
                <td style="width:90%;">
                    <asp:TextBox runat="server" ID="txtSYSTEMMAILADDRESS" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr style="display:none;">
                <td>	默认的系统发信源解释
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtSYSTEMMAILCOMMAND" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Notes 服务器名
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtSMTPHOST" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr style="display:none;">
                <td>用户名凭证Mail地址
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtUSERNAMEMAILADDRESS" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Mail密码
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtUSERNAMEPASSWORD" Width="650px"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>人事邮件地址
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtMAILTOHR" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>首页地址

                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtLOCALHOSTADDRESS" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>公司的联系电话
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCOMPANYTEL" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>公司的联系传真
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCOMPANYFAX" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>公司的Title
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCOMPANYTITLE" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>新建用户默认密码
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtDEFAULTPASSWORD" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>系统的标识符
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtSYSTEMID" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td> 日历显示基准
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtATTENDANCEISNORMALISINCLUDEOUTINTIME" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td > 帮助页面地址
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtHELPADDRESS" Width="650px"></asp:TextBox>
                </td>
            </tr>
        </table>
        </div>
