<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConnectStringView.ascx.cs" Inherits="SEP.Performance.Pages.Config.Views.ConnectStringView" %>
        <div class="leftitbor2"> 数据库连接设置</div>
        <div class="edittable">
        <table style="width: 100%;">
            <tr>
                <td style="width: 10%; text-align:left">
                    SEP数据库连接</td>
                <td style="width: 90%">
                    <asp:TextBox ID="txtConnectionString" runat="server" Width="650px"></asp:TextBox>
                    <asp:Button ID="btnSEPCheck" runat="server" Text="测  试"  CssClass="inputbt"  OnClick="btnSEPCheck_Click" />
                    <asp:Label ID="lbSEPMsg" runat="server" CssClass="psword_f"></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align:left">
                    HRMIS数据库连接</td>
                <td>
                    <asp:TextBox ID="txtHRMISConnectionString" runat="server" Width="650px"></asp:TextBox>
                    <asp:Button ID="btnHRMISCheck" runat="server" Text="测  试"  CssClass="inputbt" OnClick="btnHRMISCheck_Click" />
                    <asp:Label ID="lbHRMISMsg" runat="server" CssClass="psword_f"></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align:left">
                    CRM数据库连接</td>
                <td>
                    <asp:TextBox ID="txtCrmConnectionString" runat="server" Width="650px"></asp:TextBox>
                    <asp:Button ID="btnCRMCheck" runat="server" Text="测  试"  CssClass="inputbt"  OnClick="btnCRMCheck_Click" />
                    <asp:Label ID="lbCRMMsg" runat="server" CssClass="psword_f"></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align:left">
                    MYCMMI数据库连接</td>
                <td >
                    <asp:TextBox ID="txtMyCMMIConnectionString" runat="server" Width="650px"></asp:TextBox>
                    <asp:Button ID="btnMYCMMI" runat="server" Text="测  试"  CssClass="inputbt"  OnClick="btnMYCMMICheck_Click" />
                    <asp:Label ID="lbMYCMMIMsg" runat="server" CssClass="psword_f"></asp:Label></td>
            </tr>
            <tr id="trWebPart" runat="server">
                <td style="text-align:left">
                    WebPart数据库连接</td>
                <td>
                    <asp:TextBox ID="txtLocalSqlServer" runat="server" Width="650px"></asp:TextBox>
                    <asp:Button ID="btnWebPart" runat="server" Text="测试"  CssClass="inputbt"  OnClick="btnWebPartCheck_Click" />
                    <asp:Label ID="lbWebPartMsg" runat="server" CssClass="psword_f"></asp:Label></td>
            </tr>
        </table>
        </div>
