<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConnectStringView.ascx.cs" Inherits="SEP.Performance.Pages.Config.Views.ConnectStringView" %>
        <div class="leftitbor2"> ���ݿ���������</div>
        <div class="edittable">
        <table style="width: 100%;">
            <tr>
                <td style="width: 10%; text-align:left">
                    SEP���ݿ�����</td>
                <td style="width: 90%">
                    <asp:TextBox ID="txtConnectionString" runat="server" Width="650px"></asp:TextBox>
                    <asp:Button ID="btnSEPCheck" runat="server" Text="��  ��"  CssClass="inputbt"  OnClick="btnSEPCheck_Click" />
                    <asp:Label ID="lbSEPMsg" runat="server" CssClass="psword_f"></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align:left">
                    HRMIS���ݿ�����</td>
                <td>
                    <asp:TextBox ID="txtHRMISConnectionString" runat="server" Width="650px"></asp:TextBox>
                    <asp:Button ID="btnHRMISCheck" runat="server" Text="��  ��"  CssClass="inputbt" OnClick="btnHRMISCheck_Click" />
                    <asp:Label ID="lbHRMISMsg" runat="server" CssClass="psword_f"></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align:left">
                    CRM���ݿ�����</td>
                <td>
                    <asp:TextBox ID="txtCrmConnectionString" runat="server" Width="650px"></asp:TextBox>
                    <asp:Button ID="btnCRMCheck" runat="server" Text="��  ��"  CssClass="inputbt"  OnClick="btnCRMCheck_Click" />
                    <asp:Label ID="lbCRMMsg" runat="server" CssClass="psword_f"></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align:left">
                    MYCMMI���ݿ�����</td>
                <td >
                    <asp:TextBox ID="txtMyCMMIConnectionString" runat="server" Width="650px"></asp:TextBox>
                    <asp:Button ID="btnMYCMMI" runat="server" Text="��  ��"  CssClass="inputbt"  OnClick="btnMYCMMICheck_Click" />
                    <asp:Label ID="lbMYCMMIMsg" runat="server" CssClass="psword_f"></asp:Label></td>
            </tr>
            <tr id="trWebPart" runat="server">
                <td style="text-align:left">
                    WebPart���ݿ�����</td>
                <td>
                    <asp:TextBox ID="txtLocalSqlServer" runat="server" Width="650px"></asp:TextBox>
                    <asp:Button ID="btnWebPart" runat="server" Text="����"  CssClass="inputbt"  OnClick="btnWebPartCheck_Click" />
                    <asp:Label ID="lbWebPartMsg" runat="server" CssClass="psword_f"></asp:Label></td>
            </tr>
        </table>
        </div>
