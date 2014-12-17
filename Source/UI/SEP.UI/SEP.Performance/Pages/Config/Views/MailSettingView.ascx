<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MailSettingView.ascx.cs" Inherits="SEP.Performance.Pages.Config.Views.MailSettingView" %>
<%@ Register Src="ABCClientSetView.ascx" TagName="ABCClientSetView" TagPrefix="uc1" %>
        <div class="leftitbor2"> 邮件设置</div>
        <div class="edittable">
        <table style="width: 100%">
            <tr>
            <td>
                   <asp:CheckBox ID="cbOpenFunction" runat="server" Text="是否通过队列发送邮件"/>
             </td>
            </tr>
        </table>
        </div>
