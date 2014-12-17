<%@ Control Language="C#" AutoEventWireup="true" Codebehind="LinkmanListView.ascx.cs"
    Inherits="SEP.Performance.Views.SEP.Contacts.LinkmanListView" %>
<link href="../../../Pages/CSS/style.css" rel="stylesheet" type="text/css" />

<div id="telelist">
<ul>
        <asp:DataList ID="listLinkMan" RepeatColumns="3" runat="server" DataKeyField="Id"
            Height="15%" Width="95%" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" ItemStyle-Wrap="true">
            <ItemTemplate>
                <table style="height:7px; width:100px" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <li><a>
                            <td style="width:20px" >
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="right" ImageUrl="~/Pages/image/phone03.gif" /></td>
                        </a>
                        <a><td style="width:10px" ></td></a>
                        <a>
                            <td style="width:90px">
                                <asp:LinkButton ID="btnName" runat="server" Width="99%" Text='<%# Eval("Name").ToString().Length > 5 ? Eval("Name").ToString().Substring(0,4) + "..." : Eval("Name")%>' OnCommand="Update_Command"
                                    CommandArgument='<%# Eval("Id")%>' />
                            </td>
                        </a><a>
                            <td>
                                <asp:ImageButton ID="Btndelete" runat="server" ImageAlign="Left" ImageUrl="~/Pages/image/deleicon.gif"
                                    OnCommand="Delete_Command" CommandArgument='<%# Eval("Id")%>' /></td>
                        </a></li>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </ul>
    <div class="pages" id="tbPage" runat="server" >
		     <asp:LinkButton ID="lbtPrevPage" runat="server" CommandArgument="Prev" CssClass="pageprevbutton"
                            CommandName="Page" OnCommand="Page_Command">上一页
                        </asp:LinkButton>
            <%--            <img src="../../image/nextbt.jpg" style="vertical-align: middle" />--%>
                        <asp:LinkButton ID="lbtNextPage" runat="server" CommandArgument="Next" CommandName="Page" CssClass="pagenextbutton"
                            OnCommand="Page_Command">下一页
                        </asp:LinkButton>
		</div>   
   
</div>
