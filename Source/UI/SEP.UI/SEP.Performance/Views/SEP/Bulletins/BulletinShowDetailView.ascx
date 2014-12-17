<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BulletinShowDetailView.ascx.cs"
    Inherits="SEP.Performance.Views.SEP.Bulletins.BulletinShowDetailView" %>
<div class="edittable">
    <table width="98%" border="0">
        <tr>
            <td align="left">
                <br />
                &nbsp;&nbsp;&nbsp;
                <img src="../../../Pages/image/icon01.gif" align="absmiddle" />
                <span class="fontred">公告内容</span>
                <table width="100%" border="0">
                    <tr>
                        <td width="3%" height="33" align="left">
                            &nbsp;
                        </td>
                        <td width="2%" align="left">
                            &nbsp;
                        </td>
                        <td width="52%" align="left">
                            <strong style="font-size: 14px;">标题：<asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></strong>
                        </td>
                        <td width="43%" align="left" class="fontgray">
                            <span class="fontblue1">发布于</span>
                            <asp:Label ID="lblTime" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="3%" height="43" align="left">
                            &nbsp;
                        </td>
                        <td width="2%" align="left">
                            &nbsp;
                        </td>
                        <td width="52%" align="left" colspan="2" class="ggline">
                            <br />
                            <asp:Label ID="lblContent" runat="server" Text="" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
<div id="ShowAppendix" runat="server">
    <div class="leftitbor2">
        附件下载<asp:Label ID="lblAppendixMessage" runat="server" CssClass="psword_f" Text=""></asp:Label>
    </div>
    <div class="linetablediv">
        <asp:GridView ID="gvAppendixList" runat="server" Width="100%" AutoGenerateColumns="False"
            GridLines="None" OnRowDataBound="gvAppendixList_RowDataBound" AllowPaging="false"
            ShowHeader="false">
            <HeaderStyle Height="28px" CssClass="headerstyleblue" />
            <RowStyle Height="28px" CssClass="GridViewRowLink" />
            <AlternatingRowStyle CssClass="table_g" />
            <SelectedRowStyle BackColor="#F7F3FF" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnHiddenPostButton" runat="server" Text="" Style="display: none;" />
                    </ItemTemplate>
                    <ItemStyle Height="28px" Width="2%" />
                </asp:TemplateField>
                <asp:BoundField DataField="Title" HeaderText="附件列表">
                    <ControlStyle Width="200px" />
                    <ItemStyle Width="60%" HorizontalAlign="Left" />
                    <FooterStyle HorizontalAlign="Left" />
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="操&#160;&#160;作">
                    <ItemTemplate>
                        <img alt="" src="../../../Pages/image/dow.gif" style="vertical-align: middle" />
                        <asp:LinkButton ID="btnDownload" runat="server" Width="70px" Text=" 下 载" CausesValidation="false"
                            CommandArgument='<%# Eval("Title") %>' CommandName='<%# Eval("Directory") %>'
                            OnCommand="Download_Command" ToolTip="Download" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</div>
