<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SMSSettingView.ascx.cs" Inherits="SEP.Performance.Pages.Config.Views.SMSSettingView" %>
<%@ Register Src="ABCClientSetView.ascx" TagName="ABCClientSetView" TagPrefix="uc1" %>
          <div class="leftitbor2"> ���Ż�����</div>
          <div class="edittable">
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <uc1:ABCClientSetView id="ABCClientSetView1" runat="server">
                    </uc1:ABCClientSetView></td>
            </tr>
            <tr>
                <td style="width: 10%; text-align:left;">
                    ����ҵ������ط����ʱ��</td>
                <td style="width: 90%">
                    <asp:TextBox ID="txtTimeSpan" runat="server" Width="50px"></asp:TextBox>(��λ��Сʱ)
                    <asp:Label ID="lblTimeSpanMsg" runat="server" CssClass="psword_f"></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align:left;">
                    ���Ǳ���������������Ҫ�ڴ����ñ��ؼ�����ַ</td>
                <td >
                    <asp:TextBox ID="txtClientListenAddress" runat="server" Width="650px"></asp:TextBox></td>
            </tr>
        </table>
        </div>
